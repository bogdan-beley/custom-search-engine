using CustomSearchEngine.Models;
using System.Threading.Tasks;

namespace CustomSearchEngine.Services
{
    public interface IGoogleWebSearchApiClient
    {
        Task<SearchResult> GetSearchResultsAsync(string searchQuery);
    }
}
