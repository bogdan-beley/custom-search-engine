using CustomSearchEngine.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CustomSearchEngine.Services
{
    public class SearchResultsService : ISearchResultsService
    {
        private readonly CustomSearchEngineContext _dbContext;

        public SearchResultsService(CustomSearchEngineContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SearchResultItem>> FindByTitle(string searchQuery)
        {
            return await _dbContext.SearchResultItems.Where(x => x.Title.Contains(searchQuery)).ToListAsync();
        }

        public async Task WriteToDbAsync(SearchResult searchResult)
        {
            await _dbContext.SearchResults.AddAsync(searchResult);
            await _dbContext.SaveChangesAsync();
        }
    }
}
