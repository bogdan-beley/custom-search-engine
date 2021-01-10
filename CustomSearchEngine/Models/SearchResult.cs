using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomSearchEngine.Models
{
    public class SearchResult
    {
        public int Id { get; set; }
        public string SearchQuery { get; set; }
        public List<SearchResultItem> SearchResultItems { get; set; }
    }
}
