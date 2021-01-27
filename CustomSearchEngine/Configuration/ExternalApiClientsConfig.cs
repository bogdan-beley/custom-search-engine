
namespace CustomSearchEngine.Configuration
{
    public class ExternalApiClientsConfig
    {
        public const string BingWebSearchApiClient = "BingWebSearchApiClient";
        public const string GoogleWebSearchApiClient = "GoogleWebSearchApiClient";

        public string Url { get; set; }
        public string ApiKey { get; set; }
        public string ApiKeyName { get; set; }
        public string SearchEngineId { get; set; }
    }
}
