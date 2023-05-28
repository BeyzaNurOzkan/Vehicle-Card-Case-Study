using BusinessLayer.Concrete;
using DataAccessLayer.Context;
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

            List<SelectListItem> list = (from i in vehicleTypeRepository.GetAll().ToList()
                                         select new SelectListItem
                                         {
                                              Text=i.Model,
                                              Value=i.TypeId.ToString()
                                         }
                                         ).ToList();
            ViewBag.VehicleType = list;
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
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult VehicleTypeAdd(VehiclesType vehiclesType)
        {
            if (ModelState.IsValid)
            {
                vehicleTypeRepository.Add(vehiclesType);
                return RedirectToAction("VehicleType");
            }
            ModelState.AddModelError("", "Bir hata oluştu!");
            return View();
        }
        public ActionResult VehicleTypeUpdate(int id)
        {
            var update = vehicleTypeRepository.GetById(id);
            return View(update);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult VehicleTypeUpdate(VehiclesType vehiclesType)
        {
            if (ModelState.IsValid)
            {
                var update = vehicleTypeRepository.GetById(vehiclesType.TypeId);
                update.Brand = vehiclesType.Brand;
                update.Model = vehiclesType.Model;
                update.CapacityM3 = vehiclesType.CapacityM3;
                update.CapacityKg = vehiclesType.CapacityKg;
                vehicleTypeRepository.Update(update);
                return RedirectToAction("VehicleType");
            }
            ModelState.AddModelError("", "Bir hata oluştu!");
            return View();
        }
        public ActionResult TypeDelete(int TypeId)
        {
            var delete = vehicleTypeRepository.GetById(TypeId);
            vehicleTypeRepository.Delete(delete);
            return RedirectToAction("VehicleType");
        }
    }
}