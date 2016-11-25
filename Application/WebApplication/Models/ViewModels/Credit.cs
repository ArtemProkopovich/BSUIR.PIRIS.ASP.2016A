using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels
{
    public class Credit
    {
        public int Id { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public decimal Amount { get; set; }
        public string CreditCardPin { get; set; }
        public virtual Client Client { get; set; }
        public virtual PlanOfCredit PlanOfCredit { get; set; }
    }
}