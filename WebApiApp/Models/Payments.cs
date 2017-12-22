using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiApp.Models
{
    public class Payments
    {
        public bool status { get; set; }
        public Payment payment { get; set; }
    }
    public class Payment
    {
        public int id { get; set; }
        public int date { get; set; }
        public int amount { get; set; }
        public string status { get; set; }
    }

   
}