using CustomSearchEngine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace CustomSearchEngine.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _googleCustomSearch;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IHttpClientFactory factory, ILogger<HomeController> logger)
        {
            _googleCustomSearch = factory.CreateClient("GoogleCustomSearch");
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        private async Task<GoogleCustomSearchModel> GoogleCustomSearchService(string query)
        {
            return await _googleCustomSearch
                .GetFromJsonAsync<GoogleCustomSearchModel>(_googleCustomSearch.BaseAddress + query);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
