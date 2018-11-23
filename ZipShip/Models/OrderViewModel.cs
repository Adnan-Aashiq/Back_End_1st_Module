using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZipShip.Models
{
    public class OrderViewModel
    {
        
        [Display(Name = "Order Id")]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Quantity { get; set; }
        public double Price { get; set; }
        public double DealPrice { get; set; }
        [Display(Name = "Order By")]
        public string AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        
    }
}