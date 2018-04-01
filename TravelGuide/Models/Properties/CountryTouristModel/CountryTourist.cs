using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelGuide.Models.Properties.CountryModel;
using TravelGuide.Models.Properties.TouristplaceModel;

namespace TravelGuide.Models.Properties.CountryTouristModel
{
    public class CountryTourist
    {
        public Country _Country { get; set; }

        public Touristplace _Touristplace { get; set; }
    }
}