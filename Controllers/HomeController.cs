using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bandsintown_app.Models;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace bandsintown_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
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

            string searchArtistUrl = _configuration.GetSection("AppSettings").GetSection("SearchArtistUrl").Value;
            string searchUrl = String.Format("{0}{1}",searchArtistUrl,searchTerm);


            var client = new RestClient(searchUrl);
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "7a7e6970-2778-a03a-090e-1ea03e0e40cc");
            request.AddHeader("cache-control", "no-cache");
            IRestResponse response = client.Execute(request);

            //var model = JsonConvert.DeserializeObject<List<ArtistData>>(response.Content);

            dynamic data = JObject.Parse(response.Content);
            //var model = JsonConvert.DeserializeObject<List<ArtistData>>(data.artists);

            List<ArtistDataSearch> test = data.artists.ToObject<List<ArtistDataSearch>>();

            

            return View(test);
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
