namespace CustomSearchEngine.Models
{
    public class GoogleCustomSearchItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Snippet { get; set; }
        public int GoogleCustomSearchRootObjectId { get; set; }
        public GoogleCustomSearchRootObject GoogleCustomSearchRootObjects { get; set; }
    }
}
