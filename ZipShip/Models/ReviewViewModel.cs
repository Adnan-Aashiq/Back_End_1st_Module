using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZipShip.Models
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public string Review { get; set; }
        public string AddedBy { get; set; }
    }
}