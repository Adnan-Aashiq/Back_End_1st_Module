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
            
            DBZipShipEntities db = new DBZipShipEntities();
            var orders = db.Orders.ToList();
            List<OrderViewModel> list = new List<OrderViewModel>();
            foreach(var i in orders)
            {
                OrderViewModel o = new OrderViewModel();
                o.Id = i.Id;
                o.Name = i.Name;
                o.Quantity = i.Quantity;
                o.Price =Convert.ToDouble(i.Price);
                o.DealPrice = Convert.ToDouble(i.DealPrice);
                o.AddedBy = i.AddedBy;
                if(o.AddedBy != User.Identity.GetUserId())
                {
                    list.Add(o);
                }
                
            }
            
            return View(list);
        }

        public ActionResult SelectedOrder()
        {

            DBZipShipEntities db = new DBZipShipEntities();
            string personID = User.Identity.GetUserId();
            var deals = db.Deals.ToList();
            List<int> list = new List<int>();
            foreach (Deal d in deals)
            {
                if(d.SelectedBy == personID)
                {
                    int i = Convert.ToInt16(d.OrderId);
                    list.Add(i);
                }
            }
            List<OrderViewModel> listOfOrders = new List<OrderViewModel>();
            var AllOrders = db.Orders.ToList();
            foreach(var v in AllOrders)
            {
                foreach(int a in list)
                {
                    if(v.Id == a)
                    {
                        OrderViewModel o = new OrderViewModel();
                        o.Name = v.Name;
                        o.Quantity = v.Quantity;
                        o.Price = Convert.ToDouble(v.Price);
                        o.DealPrice = Convert.ToDouble(v.DealPrice);
                        o.AddedBy = v.AddedBy;
                        listOfOrders.Add(o);
                    }
                }
            }
            
        
            return View(listOfOrders);
        }
        // GET: Order/MyList
        public ActionResult MyList()
        {
            DBZipShipEntities db = new DBZipShipEntities();
            string personID = User.Identity.GetUserId();
            var orders = db.Orders.Where(x => x.AddedBy == personID);
            List<OrderViewModel> list = new List<OrderViewModel>();
            foreach (var i in orders)
            {
                OrderViewModel o = new OrderViewModel();
                o.Id = i.Id;
                o.Name = i.Name;
                o.Quantity = i.Quantity;
                o.Price = Convert.ToDouble(i.Price);
                o.DealPrice = Convert.ToDouble(i.DealPrice);
                list.Add(o);
            }
            return View(list);
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
                DBZipShipEntities db = new DBZipShipEntities();
                Order o = new Order();
                o.Name = collection.Name;
                o.Quantity = collection.Quantity;
                o.Price =Convert.ToInt64(collection.Price);
                o.DealPrice =Convert.ToInt64(collection.DealPrice);
                o.AddedBy = User.Identity.GetUserId();
                o.AddedOn = DateTime.Now;
                db.Orders.Add(o);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            DBZipShipEntities db = new DBZipShipEntities();
            OrderViewModel user = new OrderViewModel();
            foreach (Order p in db.Orders)
            {
                if (id == p.Id)
                {
                    user.Name = p.Name;
                    user.Quantity = p.Quantity;
                    user.Price =Convert.ToInt16(p.Price);
                    user.DealPrice = Convert.ToInt16(p.DealPrice);
                    
                    break;
                }
            }
            return View(user);
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OrderViewModel collection)
        {
            // TODO: Add update logic here
            DBZipShipEntities db = new DBZipShipEntities();
            OrderViewModel user = new OrderViewModel();
            foreach (Order p in db.Orders)
            {
                if (p.Id == id)
                {

                    p.Name = collection.Name;
                    p.Quantity = collection.Quantity;
                    p.Price = Convert.ToInt16(collection.Price);
                    p.DealPrice = Convert.ToInt16(collection.DealPrice);
                    
                    break;
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
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
            return View();
            
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
                DBZipShipEntities db = new DBZipShipEntities();
                var order = db.Deals.Where(x => x.OrderId == id);
                db.Entry(order).State = System.Data.Entity.EntityState.Deleted;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/DeleteOrder/5
        public ActionResult DeleteOrder(int id)
        {
            return View();
        }

        // POST: Order/DeleteOrder/5
        [HttpPost]
        public ActionResult DeleteOrder(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                DBZipShipEntities db = new DBZipShipEntities();
                var order = db.Orders.Where(x => x.Id == id);
                db.Entry(order).State = System.Data.Entity.EntityState.Deleted;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
