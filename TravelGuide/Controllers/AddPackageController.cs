using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelGuide.infrastructure;
using TravelGuide.Models.DataLayer;
using TravelGuide.Models.Properties.CountryModel;
using TravelGuide.Models.Properties.CountryTouristModel;
using TravelGuide.Models.Properties.TouristplaceModel;

namespace TravelGuide.Controllers
{
    public class AddPackageController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection frmCollection, HttpPostedFileBase files)
        {
            AddPackageDataLayer objAddPackageDataLayer = new AddPackageDataLayer();

            Country objCountry = new Country
            {
                CountryName = frmCollection["Country"].ToString(),
                Latitude = Convert.ToInt64(frmCollection["Countrylatitude"].ToString().Replace(".","").Substring(0,6)),
                Longitude = Convert.ToInt64(frmCollection["Countrylongitude"].ToString().Replace(".", "").Substring(0, 6)),
            };

            Touristplace objTouristplace = new Touristplace
            {
                PlaceName = frmCollection["TouristPlace"].ToString(),
                Latitude = Convert.ToInt64(frmCollection["Placelatitude"].ToString().Replace(".", "").Substring(0, 6)),
                Longitude = Convert.ToInt64(frmCollection["Placelongitude"].ToString().Replace(".", "").Substring(0, 6)),
                Description = frmCollection["Description"].ToString(),
                PhotoPath = SaveImageToServer(files)

            };


            CountryTourist objCountryTourist = new CountryTourist
            {
                _Country = objCountry,
                _Touristplace = objTouristplace
            };

            //Main Method to save Package
            ResponseType response = objAddPackageDataLayer.SavePackage(objCountryTourist);

            if (response == ResponseType.Sucess)
            {
                ViewBag.Status = ResponseType.Sucess;
                ViewBag.Message = "Package saved successfully";
            }

            if (response == ResponseType.Error)
            {
                ViewBag.Status = ResponseType.Error;
                ViewBag.Message = "Internal error occured";

            }

            if (response == ResponseType.Exists)
            {
                ViewBag.Status = ResponseType.Exists;
                ViewBag.Message = "Package already exists";
            }


            return View();
        }

        private string SaveImageToServer(HttpPostedFileBase files)
        {
            var fileName = "NIL";
            if (files != null)
            {
                if (files.ContentLength > 0)
                {
                    fileName = Path.GetFileName(files.FileName);
                    var path = Path.Combine(Server.MapPath("~/PackageFiles"), fileName);
                    files.SaveAs(path);

                }

            }
            return fileName;
        }
    }
}