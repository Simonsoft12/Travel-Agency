using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.Logic;
using DataLibrary.Models;
using static DataLibrary.Logic.ClientProcessor;

namespace TravelAgency.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Destinations()
        {
            ViewBag.Message = "Your destinations page.";

            return View();
        }

        public ActionResult Orders()
        {
            ViewBag.Message = "Your orders page.";

            return View();
        }
    }
}