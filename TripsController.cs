using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZipShip.Models;

namespace ZipShip.Controllers
{
    public class TripsController : Controller
    {
        // GET: Trips
        public ActionResult Index()
        {
            
            
            return View();
        }

        // GET: Trips/Filtered
        public ActionResult Filtered()
        {
            
            
            return View();
        }

        // GET: Trips/Filtered
        [HttpPost]
        public ActionResult Filtered(TripViewModel collection)
        {
            
            
            return View();
        }

        // GET: Trips/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Trips/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trips/Create
        [HttpPost]
        public ActionResult Create(TripViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                DBZipShipEntities db = new DBZipShipEntities();
                Trip trip = new Trip();
                trip.Country = collection.Country;
                trip.City = collection.City;
                trip.Date = collection.Date;
                trip.AddedBy = User.Identity.GetUserId();
                trip.AddedOn = DateTime.Now.Date;
                db.Trips.Add(trip);
                db.SaveChanges();
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Trips/Edit/5
        public ActionResult Edit()
        {
            DBZipShipEntities db = new DBZipShipEntities();
            string id = User.Identity.GetUserId();
            var det = db.Trips.Where(x => x.AddedBy == id).First();
            TripViewModel t = new TripViewModel();
            t.Country = det.Country;
            t.City = det.City;
            t.Date =Convert.ToDateTime(det.Date);

            return View(t);
        }

        // POST: Trips/Edit/5
        [HttpPost]
        public ActionResult Edit(TripViewModel collection)
        {
            try
            {
                // TODO: Add update logic here
                DBZipShipEntities db = new DBZipShipEntities();
                string id = User.Identity.GetUserId();
                var det = db.Trips.Where(x => x.AddedBy == id).First();
                det.Country = collection.Country;
                det.City = collection.City;
                det.Date = Convert.ToDateTime(collection.Date);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Trips/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Trips/Delete/5
        [HttpPost]
        public ActionResult Delete(TripViewModel collection)
        {
            try
            {
                // TODO: Add delete logic here
                DBZipShipEntities db = new DBZipShipEntities();
                string id = User.Identity.GetUserId();
                var det = db.Trips.Where(x => x.AddedBy == id).First();
                db.Entry(det).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
