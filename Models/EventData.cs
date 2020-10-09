using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bandsintown_app.Models
{
    public class EventData
    {
        public string id { get; set; }
        public string artist_id { get; set; }
        public string url { get; set; }
        public string on_sale_datetime { get; set; }
        public string datetime { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public VenueData venue { get; set; }
        public List<OfferData> offers { get; set; }
        public List<string> lineup { get; set; }
    }
}
