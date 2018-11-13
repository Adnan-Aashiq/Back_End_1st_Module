using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZipShip.Models
{
    public class TripViewModel
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Date { get; set; }
        [Display(Name = "Travelers Name")]
        public string AddedBy { get; set; }
        public DateTime AddedOn { get; set; }

    }
}