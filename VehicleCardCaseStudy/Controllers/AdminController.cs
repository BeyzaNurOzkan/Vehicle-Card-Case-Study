using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VehicleCardCaseStudy.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Vehicle()
        {
            return View();
        }
        public ActionResult VehicleAdd()
        {
            return View();
        }

        public ActionResult VehicleUpdate()
        {
            return View();
        }
        public ActionResult VehicleType()
        {
            return View();
        }
        public ActionResult VehicleTypeAdd()
        {
            return View();
        }
        public ActionResult VehicleTypeUpdate()
        {
            return View();
        }
    }
}