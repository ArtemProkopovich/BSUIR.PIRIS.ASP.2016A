using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels
{
    public class CreateCreditModel : Credit
    {
        public IEnumerable<PlanOfCredit> CreditPlans { get; set; }
    }
}