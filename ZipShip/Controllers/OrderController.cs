using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZipShip.Models;

namespace ZipShip.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            
            
            return View();
        }

        public ActionResult SelectedOrder()
        {

            DBZipShipEntities db = new DBZipShipEntities();
            string personID = User.Identity.GetUserId();
            Deal deal = db.Deals.Where(x => x.SelectedBy == personID).First();
            int order_id =Convert.ToInt16(deal.OrderId);

            Order order = db.Orders.Where(x=>x.Id == order_id).First();
            OrderViewModel o = new OrderViewModel();
             
            o.Name = order.Name;
            o.Quantity = order.Quantity;
            o.Price = Convert.ToDouble(order.Price);
            o.DealPrice = Convert.ToDouble(order.DealPrice);
            o.AddedBy = order.AddedBy;
                
            

            return View(o);
        }
        // GET: Order/MyList
        public ActionResult MyList()
        {
            
            return View();
        }

        // GET: Order/Details/5
        public ActionResult Details(string id)
        {
            DBZipShipEntities db = new DBZipShipEntities();
            UserViewModel u = new UserViewModel();
            var user = db.AspNetUsers.Where(x => x.Id == id).First();
            u.Name = user.Name;
            u.Email = user.Email;
            u.Address = user.Address;
            u.CNIC = user.CNIC;
            u.PhoneNumber = user.PhoneNumber;

            return View(u);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(OrderViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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


        
        // POST: Order/Select/5
        
        public ActionResult Select(int id,OrderViewModel collection)
        {
            
            DBZipShipEntities db = new DBZipShipEntities();
            Deal d = new Deal();
            d.OrderId = id;
            d.SelectedBy = User.Identity.GetUserId();
            db.Deals.Add(d);
            db.SaveChanges();
            return RedirectToAction("SelectedOrder");
            
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
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
