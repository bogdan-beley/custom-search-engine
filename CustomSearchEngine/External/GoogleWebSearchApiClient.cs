using CustomSearchEngine.Configuration;
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
    public sealed class GoogleWebSearchApiClient : IGoogleWebSearchApiClient
    {
        private readonly HttpClient _httpClient;

        public GoogleWebSearchApiClient(
            HttpClient httpClient, 
            IConfiguration configuration, 
            IOptionsMonitor<ExternalApiClientsConfig> options)
        {
            var externalApiClientConfig = options.Get(ExternalApiClientsConfig.GoogleWebSearchApiClient);
            var apiKey = configuration["GoogleCustomSearch:ApiKey"]; // user-secrets
            var searchEngineId = configuration["GoogleCustomSearch:SearchEngineId"]; // user-secrets

            httpClient.BaseAddress = new Uri(externalApiClientConfig.Url + "?key=" + apiKey + "&cx=" + searchEngineId + "&q=");

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
