using CustomSearchEngine.Configuration;
using CustomSearchEngine.External.Models;
using CustomSearchEngine.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CustomSearchEngine.Services
{
    public sealed class GoogleWebSearchApiClient : IExternalWebSearchApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ExternalApiClientsConfig _externalApiClientConfig;

        public GoogleWebSearchApiClient(
            HttpClient httpClient, IOptionsMonitor<ExternalApiClientsConfig> options)
        {
            _externalApiClientConfig = options.Get(ExternalApiClientsConfig.GoogleWebSearchApiClient);

            httpClient.BaseAddress = new Uri(_externalApiClientConfig.Url 
                + "?key=" + _externalApiClientConfig.ApiKey 
                + "&cx=" + _externalApiClientConfig.SearchEngineId 
                + "&q=");

            _httpClient = httpClient;
        }

        public async Task<SearchResult> GetSearchResultsAsync(string searchQuery)
        {
            var results = await _httpClient
                .GetFromJsonAsync<GoogleWebSearchApiResult>(_httpClient.BaseAddress + searchQuery);

            var searhResultItems = new List<SearchResultItem>();
            foreach (var item in results.Items)
            {
                searhResultItems.Add(new SearchResultItem()
                {
                    Title = item.Title,
                    Link = item.DisplayLink,
                    Snippet = item.Snippet
                });
            }

            var searchResult = new SearchResult()
            {
                SearchResultItems = searhResultItems,
                SearchQuery = searchQuery,
                SearchEngine = "Google"
            };

            return searchResult;
        }
    }
}
