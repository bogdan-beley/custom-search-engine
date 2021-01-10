using CustomSearchEngine.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CustomSearchEngine.Services
{
    public sealed class GoogleCustomSearchService : IGoogleCustomSearchService
    {
        private HttpClient _httpClient;

        public GoogleCustomSearchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GoogleCustomSearchRootObject> GetSearchResultsAsync(string searchQuery)
        {
            return await _httpClient
                .GetFromJsonAsync<GoogleCustomSearchRootObject>(_httpClient.BaseAddress + searchQuery);
        }
    }
}
