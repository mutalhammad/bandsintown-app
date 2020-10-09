using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bandsintown_app.Models
{
    public class ArtistAndEvents
    {
        public ArtistData  artistData { get; set; }
        public List<EventData>  listEventsData { get; set; }

    }
}
