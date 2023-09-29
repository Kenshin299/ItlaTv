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
            var seriesList = await _seriesService.GetAllViewModel();
            return View(seriesList);
        }

        public async Task<IActionResult> Details(int id)
        {
            var seriesDetails = await _seriesService.GetByIdSaveViewModel(id);
            return View("Details", seriesDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string searchTerm)
        {
            var searchResults = await _seriesService.SearchByName(searchTerm);
            return View("Index", searchResults);
        }

        [HttpPost]
        public async Task<IActionResult> FilterByProducer(int[] producerIds)
        {
            var filteredSeries = await _seriesService.FilterByProducers(producerIds);
            return View("Index", filteredSeries);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}