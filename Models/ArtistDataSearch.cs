using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bandsintown_app.Models
{
    public class ArtistDataSearch
    {
        public string name { get; set; }
        public string trackerText { get; set; }
        public string imageSrc { get; set; }
        public string verifiedSrc { get; set; }
        public string href { get; set; }
        public ArtistData artistData { get; set; }

    }
}
