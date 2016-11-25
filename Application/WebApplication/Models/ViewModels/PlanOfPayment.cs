using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels
{
    public class PlanOfPayment
    {
        public DateTime CurrentDay { get; set; }
        public IDictionary<DateTime, decimal> PaymentSchedule { get; set; }
    }
}