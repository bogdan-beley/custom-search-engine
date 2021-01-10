using CustomSearchEngine.Models;
using System.Threading.Tasks;

namespace CustomSearchEngine.Services
{
    public interface ISearchResultsService
    {
        Task WriteToDbAsync(SearchResult searchResult);
    }
}
