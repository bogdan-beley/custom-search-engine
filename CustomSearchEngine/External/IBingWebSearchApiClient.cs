using CustomSearchEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomSearchEngine.Services
{
    public interface IBingWebSearchApiClient
    {
        Task<SearchResult> GetSearchResultsAsync(string searchQuery);
    }
}
