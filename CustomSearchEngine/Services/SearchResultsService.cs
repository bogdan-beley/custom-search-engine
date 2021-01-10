using CustomSearchEngine.Models;
using System.Threading.Tasks;

namespace CustomSearchEngine.Services
{
    public class SearchResultsService : ISearchResultsService
    {
        private readonly CustomSearchEngineContext _dbContext;

        public SearchResultsService(CustomSearchEngineContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task WriteToDbAsync(SearchResult searchResult)
        {
            await _dbContext.SearchResults.AddAsync(searchResult);
            await _dbContext.SaveChangesAsync();
        }
    }
}
