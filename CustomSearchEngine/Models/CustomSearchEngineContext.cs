using Microsoft.EntityFrameworkCore;

namespace CustomSearchEngine.Models
{
    public class CustomSearchEngineContext : DbContext
    {
        public CustomSearchEngineContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<GoogleCustomSearchRootObject> GoogleCustomSearchRootObjects { get; set; }
        public DbSet<GoogleCustomSearchItem> GoogleCustomSearchItems { get; set; }
    }
}
