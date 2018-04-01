using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelGuide.Models.Properties.TouristplaceModel
{
    public class Touristplace
    {
        public int TouristplaceId { get; set; }

        public string PlaceName { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int CountryId { get; set; }
    }
}