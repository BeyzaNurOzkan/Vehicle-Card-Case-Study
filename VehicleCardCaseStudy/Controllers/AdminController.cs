using BusinessLayer.Concrete;
using EntityLayer.Entities;
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
        VehicleRepository vehicleRepository=new VehicleRepository();
        VehicleTypeRepository vehicleTypeRepository=new VehicleTypeRepository();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Vehicle()
        {
            return View(vehicleRepository.GetAll());
        }
        public ActionResult VehicleAdd()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult VehicleAdd(Vehicle vehicle)
        {
            if(ModelState.IsValid)
            {
                vehicleRepository.Add(vehicle);
                return RedirectToAction("Vehicle");
            }
            ModelState.AddModelError("", "Bir hata oluştu!");
            return View();  
        }
        public ActionResult Delete(int id)
        {
            var delete = vehicleRepository.GetById(id); 
            vehicleRepository.Delete(delete);
            return RedirectToAction("Vehicle");
        }
        public ActionResult VehicleUpdate(int id)
        {
            var update = vehicleRepository.GetById(id);
            return View(update);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult VehicleUpdate(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                var update = vehicleRepository.GetById(vehicle.Id);
                update.Plate = vehicle.Plate;
                update.Color = vehicle.Color;
                update.ModelYear = vehicle.ModelYear;
                update.TypeId = vehicle.TypeId;
                vehicleRepository.Update(update);
                return RedirectToAction("Vehicle");
            }
            ModelState.AddModelError("", "Bir hata oluştu!");
            return View();
        }
        public ActionResult VehicleType()
        {
            return View(vehicleTypeRepository.GetAll());
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