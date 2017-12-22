using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiApp.Models
{
    public class TicketDetails
    {
        public FinancialInfo financial_info { get; set; }
        public List<PaxDetail> pax_details { get; set; }
        public List<CheckInLog> check_in_log { get; set; }

    }
        public class PaymentHistory
        {
            public int id { get; set; }
            public int date { get; set; }
            public int amount { get; set; }
            public string status { get; set; }
        }

        public class FinancialInfo
        {
            public int id { get; set; }
            public int ticket_rate { get; set; }
            public int discount { get; set; }
            public int due_amount { get; set; }
            public int amount_paid { get; set; }
            public int balance_amount { get; set; }
            public string ticket_sold_by { get; set; }
            public string remark { get; set; }
            public int no_of_pax { get; set; }
            public List<PaymentHistory> payment_history { get; set; }
        }

        public class PaxDetail
        {
            public int id { get; set; }
            public string name { get; set; }
            public string mobile { get; set; }
            public int dob { get; set; }
            public int anniversary { get; set; }
            public string email { get; set; }
        }

        public class CheckInLog
        {
            public int id { get; set; }
            public int date { get; set; }
            public string type { get; set; }
        }
    

  
}