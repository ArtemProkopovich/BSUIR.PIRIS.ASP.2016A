using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models.ViewModels
{
    public class PlanOfDeposit
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Name { get; set; }
        public int BankDayPeriod { get; set; }
        public double Percent { get; set; }
        public bool Revocable { get; set; }
        public decimal? MinAmount { get; set; }
    }
}