using CustomSearchEngine.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CustomSearchEngine.Services
{
    public sealed class GoogleCustomSearchService : IGoogleCustomSearchService
    {
        private readonly HttpClient _httpClient;

        public GoogleCustomSearchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SearchResult> GetSearchResultsAsync(string searchQuery)
        {
            var results = await _httpClient
                .GetFromJsonAsync<GoogleCustomSearchRootObject>(_httpClient.BaseAddress + searchQuery);

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
