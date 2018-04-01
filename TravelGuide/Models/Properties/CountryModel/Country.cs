using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelGuide.Models.Properties.CountryModel
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}