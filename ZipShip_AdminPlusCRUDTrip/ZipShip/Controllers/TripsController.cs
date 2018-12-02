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
            DBZipShipEntities db = new DBZipShipEntities();
            var list = db.Trips.ToList();
            List<TripViewModel> trips = new List<TripViewModel>();
            foreach(var i in list)
            {
                if(i.AddedBy != User.Identity.GetUserId())
                {
                    TripViewModel t = new TripViewModel();
                    t.Country = i.Country;
                    t.City = i.City;
                    t.Date = Convert.ToDateTime(i.Date);
                    var forname = db.AspNetUsers.Where(x => x.Id == i.AddedBy).First();
                    t.AddedBy = forname.Name;
                    t.AddedOn = Convert.ToDateTime(i.AddedOn);
                    trips.Add(t);
                }
                
            }
            
            return View(trips);
        }

        // GET: Trips/Filtered
        public ActionResult Filtered()
        {
            
            DBZipShipEntities db = new DBZipShipEntities();
            List<string> list = new List<string>();
            var trips = db.Trips.ToList();
            foreach(var v in trips)
            {
                int flag = 0;
                foreach(string s in list)
                {
                    if(v.Country == s)
                    {
                        flag = 1;
                    }
                }
                if(flag ==0)
                {
                    list.Add(v.Country);
                }
            }
            
            ViewBag.list = new SelectList(list);
            List<TripViewModel> list2 = new List<TripViewModel>();
            return View(list2);
        }

        // GET: Trips/Filtered
        [HttpPost]
        public ActionResult Filtered(TripViewModel collection)
        {
            string selvalue = collection.filtertrip;
            
            //string s = selvalue.Split();
            List<TripViewModel> list2 = new List<TripViewModel>();
            DBZipShipEntities db = new DBZipShipEntities();
            var trips = db.Trips.Where(x => x.Country == selvalue);
            
            foreach(var i in trips)
            {
                TripViewModel t = new TripViewModel();
                t.Country = i.Country;
                t.City = i.City;
                t.Date = Convert.ToDateTime(i.Date);
                var forname = db.AspNetUsers.Where(x => x.Id == i.AddedBy).First();
                t.AddedBy = forname.Name;
                list2.Add(t);
            }
            List<string> list = new List<string>();
            var alltrips = db.Trips.ToList();
            foreach (var v in alltrips)
            {
                int flag = 0;
                foreach (string s in list)
                {
                    if (v.Country == s)
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    list.Add(v.Country);
                }
            }

            ViewBag.list = new SelectList(list);
            
            return View(list2);
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
        public ActionResult Delete()
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
