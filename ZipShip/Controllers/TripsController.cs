﻿using System;
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
            List<TripViewModel> list = new List<TripViewModel>();
            TripViewModel a = new TripViewModel();
            a.Country = "UAE";
            a.City = "Dubai";
            a.Date = "1st Jan,2019";
            a.AddedBy = "Atif";
            list.Add(a);
            return View(list);
        }

        // GET: Trips/Filtered
        public ActionResult Filtered()
        {
            List<TripViewModel> list = new List<TripViewModel>();
            return View(list);
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
            return View();
        }

        // POST: Trips/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}