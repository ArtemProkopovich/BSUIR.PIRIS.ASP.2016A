using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Entity
{
    public class Account : IEntity
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal DebitValue { get; set; }
        public decimal CreditValue { get; set; }
        public decimal Balance { get; set; }
        public PlanOfAccount PlanOfAccount { get; set; }
    }
}
