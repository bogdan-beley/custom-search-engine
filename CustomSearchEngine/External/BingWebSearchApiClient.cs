using CustomSearchEngine.Configuration;
using CustomSearchEngine.External.Models;
using CustomSearchEngine.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CustomSearchEngine.Services
{
    public sealed class BingWebSearchApiClient : IExternalWebSearchApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ExternalApiClientsConfig _externalApiClientConfig;
        private readonly ILogger<BingWebSearchApiClient> _logger;

        public BingWebSearchApiClient(HttpClient httpClient, 
            IOptionsMonitor<ExternalApiClientsConfig> options,
            ILogger<BingWebSearchApiClient> logger)
        {
            _externalApiClientConfig = options.Get(ExternalApiClientsConfig.BingWebSearchApiClient);
            
            httpClient.BaseAddress = new Uri(_externalApiClientConfig.Url);
            httpClient.DefaultRequestHeaders.Add(_externalApiClientConfig.ApiKeyName, _externalApiClientConfig.ApiKey);

            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<SearchResult> GetSearchResultsAsync(string searchQuery, CancellationTokenSource cts)
        {
            var searchResult = new SearchResult();

            try
            {
                var results = await _httpClient
                .GetFromJsonAsync<BingWebSearchApiResult>(_httpClient.BaseAddress + searchQuery, cts.Token);

                var searhResultItems = new List<SearchResultItem>();

                if (results != null)
                {
                    foreach (var item in results.WebPages.Value)
                    {
                        searhResultItems.Add(new SearchResultItem()
                        {
                            Title = item.Name,
                            Link = item.DisplayUrl,
                            Snippet = item.Snippet
                        });
                    }
                }

                searchResult = new SearchResult()
                {
                    SearchResultItems = searhResultItems,
                    SearchQuery = searchQuery,
                    SearchEngine = "Bing"
                };

                return searchResult;
            }
            catch (TaskCanceledException ex)
            {
                _logger.LogInformation("The task was canceled because the server " +
                    "had already received a response from another client. Message: " + ex.Message);

                return searchResult;
            } 
        }
    }
}
