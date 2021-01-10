namespace CustomSearchEngine.Models
{
    public class SearchResultItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Snippet { get; set; }
        public int SearchResultId { get; set; }
        public SearchResult SearchResult { get; set; }
    }
}