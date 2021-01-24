using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomSearchEngine.Configuration
{
    public class ExternalApiClientsConfig
    {
        public const string BingWebSearchApiClient = "BingWebSearchApiClient";
        public const string GoogleWebSearchApiClient = "GoogleWebSearchApiClient";

        public string Url { get; set; }
        public string ApiKey { get; set; }
    }
}
