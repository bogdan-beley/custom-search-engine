using System.Collections.Generic;

namespace CustomSearchEngine.Models
{
    public class SearchResult
    {
        public int Id { get; set; }
        public string SearchQuery { get; set; }
        public string SearchEngine { get; set; }
        public List<SearchResultItem> SearchResultItems { get; set; }
    }
}
