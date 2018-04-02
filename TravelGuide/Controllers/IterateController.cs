using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelGuide.Models.DataLayer;
using TravelGuide.Models.Properties.SearchModel;
using TravelGuide.Models.Properties.TouristplaceModel;

namespace TravelGuide.Controllers
{
    public class IterateController : Controller
    {
        [HttpGet]
        public ActionResult Index(Search objSearch)
        {
            IterateDataLayer objIterateDataLayer = new IterateDataLayer();

            SearchResult getLatandLog = objIterateDataLayer.GetLatandLog(objSearch);

            List<Touristplace> objListTouristplace = objIterateDataLayer.ListPlaces(getLatandLog);

            return View(objListTouristplace);
        }
    }
}