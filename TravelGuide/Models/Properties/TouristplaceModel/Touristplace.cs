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

        public long Latitude { get; set; }

        public long Longitude { get; set; }

        public int CountryId { get; set; }

        public string PhotoPath { get; set; }

        public string Description { get; set; }
    }
}