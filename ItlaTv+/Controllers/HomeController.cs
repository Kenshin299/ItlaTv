using Application.Services;
using ItlaTv_.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ItlaTv_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SeriesService _seriesService;

        public HomeController(ILogger<HomeController> logger, SeriesService seriesService)
        {
            _logger = logger;
            _seriesService = seriesService;

        }

        public async Task<IActionResult> Index()
        {
            // Get a list of all series from the service
            var seriesList = await _seriesService.GetAllViewModel();
            return View(seriesList);
        }

        public async Task<IActionResult> Details(int id)
        {
            // Get details of a specific series by ID
            var seriesDetails = await _seriesService.GetByIdSaveViewModel(id);
            return View(seriesDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string searchTerm)
        {
            // Perform a search for series by name
            var searchResults = await _seriesService.SearchByName(searchTerm);
            return View("Index", searchResults);
        }

        [HttpPost]
        public async Task<IActionResult> FilterByProducer(int producerId)
        {
            var filteredSeries = await _seriesService.FilterByProducer(producerId);
            return View("Index", filteredSeries);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}