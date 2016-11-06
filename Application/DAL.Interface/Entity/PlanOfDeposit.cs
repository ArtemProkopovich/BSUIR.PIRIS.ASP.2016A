using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Entity
{
    public class PlanOfDeposit : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Period { get; set; }
        public double Percent { get; set; }
        public bool Revocable { get; set; }
        public ICollection<PlanOfAccount> PlanOfAccounts { get; set; }
    }
}
