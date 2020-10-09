using bandsintown_app.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;

namespace bandsintown_app.Helper
{
    public class Helper
    {
        private IConfiguration _configuration;

        private string searchArtistUrl;
        private string SearchArtistDataUrl;

        public Helper(IConfiguration configuration)
        {
            _configuration = configuration;

            searchArtistUrl = _configuration.GetSection("AppSettings").GetSection("SearchArtistUrl").Value;
            SearchArtistDataUrl = _configuration.GetSection("AppSettings").GetSection("SearchArtistDataUrl").Value;
        }
        public IRestResponse MakeRequest(string url)
        {
            try
            {
                string app_id = _configuration.GetSection("AppSettings").GetSection("app_id").Value;
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET).AddParameter("app_id", app_id);
                return client.Execute(request);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ArtistDataSearch> SearchArtistsByName(string searchTerm)
        {
            List<ArtistDataSearch> listArtistDataSearch = new List<ArtistDataSearch>();

            var client = new RestClient(searchArtistUrl);
            var request = new RestRequest(Method.GET).AddParameter("searchTerm", searchTerm);
            IRestResponse response = client.Execute(request);

            dynamic data = JObject.Parse(response.Content);

            foreach (ArtistDataSearch item in data.artists.ToObject<List<ArtistDataSearch>>())
            {
                string url = String.Format("{0}{1}", SearchArtistDataUrl, item.name);
                IRestResponse rsp = MakeRequest(url);

                ArtistData artistData = JsonConvert.DeserializeObject<ArtistData>(rsp.Content);

                item.artistData = artistData;

                listArtistDataSearch.Add(item);
            }
            return listArtistDataSearch;
        }
    }
}
