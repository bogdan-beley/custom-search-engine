using CustomSearchEngine.Configuration;
using CustomSearchEngine.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CustomSearchEngine.Services
{
    public sealed class BingWebSearchApiClient : IBingWebSearchApiClient
    {
        private readonly HttpClient _httpClient;

        public BingWebSearchApiClient(
            HttpClient httpClient,
            IConfiguration configuration,
            IOptionsMonitor<ExternalApiClientsConfig> options)
        {
            var externalApiClientConfig = options.Get(ExternalApiClientsConfig.BingWebSearchApiClient);
            var apiKey = configuration["BingCustomSearch:Ocp-Apim-Subscription-Key"]; // user-secrets
            
            httpClient.BaseAddress = new Uri(externalApiClientConfig.Url);
            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);

            _httpClient = httpClient;
        }

        public async Task<SearchResult> GetSearchResultsAsync(string searchQuery)
        {
            var results = await _httpClient
                .GetFromJsonAsync<BingWebSearchApiResult>(_httpClient.BaseAddress + searchQuery);

            var searhResultItems = new List<SearchResultItem>();
            foreach (var item in results.WebPages.Value)
            {
                searhResultItems.Add(new SearchResultItem()
                {
                    Title = item.Name,
                    Link = item.DisplayUrl,
                    Snippet = item.Snippet
                });
            }

            var searchResult = new SearchResult()
            {
                SearchResultItems = searhResultItems,
                SearchQuery = searchQuery,
                SearchEngine = "Bing"
            };

            return searchResult;
        }
    }
}
