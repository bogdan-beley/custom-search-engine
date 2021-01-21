using CustomSearchEngine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomSearchEngine.Services;
using System;
using System.Collections.Generic;

namespace CustomSearchEngine.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGoogleWebSearchApiClient _googleCustomSearchService;
        private readonly IBingWebSearchApiClient _bingCustomSearchService;
        private readonly ISearchResultsService _searchResultService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IGoogleWebSearchApiClient googleCustomSearchService, 
            ISearchResultsService searchResultsService, 
            IBingWebSearchApiClient bingCustomSearchService,
            ILogger<HomeController> logger)
        {
            _googleCustomSearchService = googleCustomSearchService;
            _bingCustomSearchService = bingCustomSearchService;
            _searchResultService = searchResultsService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchResultsFromAPI(string searchQuery)
        {
            try
            {
                var searchResultsFromGoogle = _googleCustomSearchService.GetSearchResultsAsync(searchQuery);
                var searchResultsFromBing = _bingCustomSearchService.GetSearchResultsAsync(searchQuery);

                var tasksList = new List<Task<SearchResult>>
                {
                    searchResultsFromGoogle,
                    searchResultsFromBing
                };

                // TODO: Add CancellationToken
                var firstCompletedTask = await Task.WhenAny(tasksList);
                var searchResults = await firstCompletedTask;

                if (searchResults != null)
                    await _searchResultService.WriteToDbAsync(searchResults);

                return View(searchResults);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public IActionResult SearchFromDb()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchResultsFromDb(string searchQuery)
        {
            return View(await _searchResultService.FindByTitle(searchQuery));
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
