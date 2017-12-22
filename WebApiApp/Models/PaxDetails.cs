using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiApp.Models
{
    public class PaxDetails
    {
        public bool status { get; set; }
        public Pax pax { get; set; }
    }
    public class Pax
    {
        public int id { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        public int dob { get; set; }
        public int anniversary { get; set; }
        public string email { get; set; }
    }

    
}