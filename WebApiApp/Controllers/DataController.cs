using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using WebApiApp.Layour;
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    public class DataController : ApiController
    {
        //
        // GET: /Data/
        DbConnect db = new DbConnect();


        [System.Web.Http.HttpPost]
        public JsonResult getTicketDetails([FromBody]  TKTInputModel inputModel)
        {
            try
            {
                if (inputModel != null)
                {
                    TicketDetails ticketDetails = new TicketDetails();
                    ticketDetails = db.getTicketDetail(inputModel.qrCode);
                    object response = new object();
                    if (ticketDetails == null)
                    {
                        response = new { Status = "false", Message = "Authentication failed" };
                    }
                    else
                    {
                        response = new { Status = "true", Payment = ticketDetails };
                    }
                    var json = new JavaScriptSerializer().Serialize(response);
                    var result = new JsonResult
                    {
                        Data = JsonConvert.DeserializeObject(json)
                    };
                    return result;
                }
                return new JsonResult();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public object updatePayment(int ticket_id, int amount, int collecterId)
        {
            try
            {
                Payments payments = new Payments();
                payments = db.updatePayment(ticket_id, amount, collecterId);
                object response = new object();
                if (payments.payment.id > 0)
                {
                    response = new { Status = "true", Payment = payments };

                }
                else
                {
                    response = new { Status = "false", Message = "Authentication failed" };

                }
                return JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public object addEditPax(int ticket_id, int pax_id, string name, string mobile, DateTime dob, string anniversary, string email)
        {
            try
            {
                PaxDetails paxDetails = new PaxDetails();
                paxDetails = db.addEditPax(ticket_id, pax_id, name, mobile, dob, anniversary, email);
                object response = new object();
                if (paxDetails == null)
                {
                    response = new { Status = "false", Message = "Authentication failed" };
                }
                else
                {
                    response = new { Status = "true", Payment = paxDetails };
                }
                return JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public object removePax(int ticket_id, int pax_id)
        {
            try
            {
                RemovePax removePax = new RemovePax();
                removePax = db.removePax(ticket_id, pax_id);
                object response = new object();
                if (removePax == null)
                {
                    response = new { Status = "false", Message = "Authentication failed" };
                }
                else
                {
                    response = new { Status = "true", Payment = removePax };
                }
                return JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public string checkIn(int ticket_id)
        {
            try
            {
                ChechInDetails chechInDetails = new ChechInDetails();
                chechInDetails = db.checkIn(ticket_id);
                object response = new object();
                if (chechInDetails == null)
                {
                    response = new { Status = "false", Message = "This ticket is already checked in at 5:55 PM" };
                }
                else
                {
                    response = new { Status = "true", Payment = chechInDetails };
                    
                }
             
                return JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

    }

}
