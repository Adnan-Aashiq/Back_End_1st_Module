using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZipShip.Models;

namespace ZipShip.Controllers
{
    public class AdminController : Controller
    {
         
        // GET: Admin
        public ActionResult Dashboard()
        {
            List<AdminDashboardViewModel> list = new List<AdminDashboardViewModel>();
            AdminDashboardViewModel a = new AdminDashboardViewModel();
            a.Traveller = "Saqib";
            a.Shopper = "Hamza";
            a.ZipShipEarning = "2000";
            a.Order = "Iphone xs";
            a.Status = "Delievered";
            list.Add(a);
            return View(list);
        }

        public ActionResult RegisteredUsers()
        {
            List<UserViewModel> list = new List<UserViewModel>();
            UserViewModel u = new UserViewModel();
            u.Name = "Rana Kashif";
            u.Email = "kashif@gmail.com";
            u.Address = "Iqbal Town";
            u.CNIC = "3520261257293";
            u.PhoneNumber = "03216964902";
            u.Password = "asad123";
            return View(list);
        }

        public ActionResult Login()
        {

            return View();
        }
        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        // GET: Admin/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(AdminViewModel collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Dashboard");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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
