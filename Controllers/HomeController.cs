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

namespace bandsintown_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string searchTerm)
        {
            var client = new RestClient("https://www.bandsintown.com/searchSuggestions?searchTerm="+searchTerm);
            var request = new RestRequest(Method.GET);
            
            IRestResponse response = client.Execute(request);

            //var model = JsonConvert.DeserializeObject<List<ArtistData>>(response.Content);

            dynamic data = JObject.Parse(response.Content);
            var model = JsonConvert.DeserializeObject<List<ArtistData>>(data.artists);

            if (viewpage == "1")
            {
                ViewBag.Page = "1";
            }
            else if (viewpage == "2")
            {
                ViewBag.Page = "2";
            }

            return PartialView(response.Content);
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
