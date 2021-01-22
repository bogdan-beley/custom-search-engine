using CustomSearchEngine.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomSearchEngine.Services
{
    public interface ISearchResultsService
    {
        Task<List<SearchResultItem>> FindByTitle(string searchQuery);
        Task WriteToDbAsync(SearchResult searchResult);
    }
}
