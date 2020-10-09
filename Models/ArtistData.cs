using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bandsintown_app.Models
{
    public class ArtistData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string image_url { get; set; }
        public string thumb_url { get; set; }
        public string facebook_page_url { get; set; }
        public string mbid { get; set; }
        public int tracker_count { get; set; }
        public int upcoming_event_count { get; set; }
    }
}
