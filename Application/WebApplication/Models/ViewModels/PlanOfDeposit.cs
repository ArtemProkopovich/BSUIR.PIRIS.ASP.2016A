using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels
{
    public class PlanOfDeposit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BankDayPeriod { get; set; }
        public double Percent { get; set; }
        public bool Revocable { get; set; }
        public decimal? MinAmount { get; set; }
    }
}