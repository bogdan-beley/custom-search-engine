using CustomSearchEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomSearchEngine.External.Models
{
    public interface IExternalWebSearchApiClient
    {
        Task<SearchResult> GetSearchResultsAsync(string searchQuery);
    }
}
