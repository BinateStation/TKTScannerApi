using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiApp.Models
{
    public class TKTInputModel
    {
        [JsonProperty("qr_code")]
        public string qrCode { get; set; }
    }
}