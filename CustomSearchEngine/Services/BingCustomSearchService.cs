using CustomSearchEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CustomSearchEngine.Services
{
    public sealed class BingCustomSearchService : IBingCustomSearchService
    {
        private readonly HttpClient _httpClient;

        public BingCustomSearchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SearchResult> GetSearchResultsAsync(string searchQuery)
        {
            var results = await _httpClient
                .GetFromJsonAsync<BingCustomSearchRootObject>(_httpClient.BaseAddress + searchQuery);

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
