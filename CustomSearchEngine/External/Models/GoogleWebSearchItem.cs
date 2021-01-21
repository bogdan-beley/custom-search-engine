namespace CustomSearchEngine.Models
{
    public class GoogleWebSearchItem
    {
        public string Title { get; set; }
        public string DisplayLink { get; set; }
        public string Snippet { get; set; }
        public int GoogleCustomSearchRootObjectId { get; set; }
        public GoogleWebSearchApiResult GoogleCustomSearchRootObjects { get; set; }
    }
}
