﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Credit.Models
{
    public class PlanOfPaymentModel
    {
        private IDictionary<DateTime, decimal> PaymentSchedule { get; set; }
    }
}
