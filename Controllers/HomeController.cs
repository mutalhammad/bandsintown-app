using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bandsintown_app.Models;
using RestSharp;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace bandsintown_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _configuration;
        private Helper.Helper _helper;
        private string SearchArtistDataUrl;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _helper = new Helper.Helper(_configuration);

            SearchArtistDataUrl = _configuration.GetSection("AppSettings").GetSection("SearchArtistDataUrl").Value;
        }

        public IActionResult Index()
        {
            ViewBag.page = "1";
            return View();
        }

        [HttpPost]
        public IActionResult Index(string searchTerm)
        {
            ViewBag.page = "1";
            ViewBag.searchedTerm = searchTerm;

            List<ArtistDataSearch> listArtistDataSearch = _helper.SearchArtistsByName(searchTerm);

            return View(listArtistDataSearch);
        }

        public IActionResult ArtistEventDetails(string selectedArtistName)
        {
            ArtistAndEvents artistAndEvents = new ArtistAndEvents();
            List<EventData> listEventData = new List<EventData>();

            List<ArtistDataSearch> listArtistDataSearch = _helper.SearchArtistsByName(selectedArtistName);

            foreach (var item in listArtistDataSearch)
            {
                if (item.name.Equals(selectedArtistName))
                {
                    string url = String.Format("{0}{1}/events/", SearchArtistDataUrl, item.name);
                    IRestResponse restResponse = _helper.MakeRequest(url);

                    listEventData = JsonConvert.DeserializeObject<List<EventData>>(restResponse.Content);

                    artistAndEvents.artistData = item.artistData;
                    artistAndEvents.listEventsData = listEventData;
                }
            }

            return View(artistAndEvents);
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
