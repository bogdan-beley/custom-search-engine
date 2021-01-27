using CustomSearchEngine.Models;
using System.Threading;
using System.Threading.Tasks;

namespace CustomSearchEngine.External.Models
{
    public interface IExternalWebSearchApiClient
    {
        Task<SearchResult> GetSearchResultsAsync(string searchQuery, CancellationTokenSource cts);
    }
}
