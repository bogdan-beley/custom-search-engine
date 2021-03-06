﻿using CustomSearchEngine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using CustomSearchEngine.Services;
using System;
using System.Collections.Generic;
using CustomSearchEngine.External.Models;
using System.Threading;
using System.Linq;

namespace CustomSearchEngine.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEnumerable<IExternalWebSearchApiClient> _externalWebSearchApiClients;
        private readonly ISearchResultsService _searchResultService;
        private readonly ILogger<HomeController> _logger;
        private readonly List<Task<SearchResult>> _taskList;

        public HomeController(IEnumerable<IExternalWebSearchApiClient> externalWebSearchApiClients,
            ISearchResultsService searchResultsService, 
            ILogger<HomeController> logger)
        {
            _externalWebSearchApiClients = externalWebSearchApiClients;
            _searchResultService = searchResultsService;
            _logger = logger;
            _taskList = new List<Task<SearchResult>>();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchResultsFromAPI(string searchQuery, CancellationTokenSource cts)
        {
            try
            {
                _taskList.AddRange(_externalWebSearchApiClients
                    .Select(client => client.GetSearchResultsAsync(searchQuery, cts)));

                var firstCompletedTask = await Task.WhenAny(_taskList);

                cts.Cancel();

                var searchResults = await firstCompletedTask;
                await _searchResultService.WriteToDbAsync(searchResults);

                return View(searchResults);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
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

        public IActionResult About()
        {
            return View();
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
