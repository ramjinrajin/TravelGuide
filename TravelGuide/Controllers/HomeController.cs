using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelGuide.Models.Properties.SearchModel;
 

namespace TravelGuide.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection frmCollection)
        {

            Search objSearch = new Search
            {
                Source = frmCollection["Source"].ToString(),
                Designation = frmCollection["Designation"].ToString()
            };





            return RedirectToAction("Index", "Iterate", objSearch);
        }
    }
}