using Microsoft.EntityFrameworkCore;

namespace CustomSearchEngine.Models
{
    public class CustomSearchEngineContext : DbContext
    {
        public CustomSearchEngineContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<SearchResult> SearchResults { get; set; }
        public DbSet<SearchResultItem> SearchResultItems { get; set; }
    }
}
