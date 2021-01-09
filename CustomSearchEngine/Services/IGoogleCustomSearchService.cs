using CustomSearchEngine.Models;
using System.Threading.Tasks;

namespace CustomSearchEngine.Services
{
    public interface IGoogleCustomSearchService
    {
        Task<GoogleCustomSearchModel> GetSearchResultsAsync(string searchQuery);
    }
}
