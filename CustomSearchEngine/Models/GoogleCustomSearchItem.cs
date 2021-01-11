namespace CustomSearchEngine.Models
{
    public class GoogleCustomSearchItem
    {
        public string Title { get; set; }
        public string DisplayLink { get; set; }
        public string Snippet { get; set; }
        public int GoogleCustomSearchRootObjectId { get; set; }
        public GoogleCustomSearchRootObject GoogleCustomSearchRootObjects { get; set; }
    }
}
