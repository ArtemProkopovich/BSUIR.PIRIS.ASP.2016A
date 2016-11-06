using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Entity
{
    public class Credit : IEntity
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public PlanOfCredit Plan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Amount { get; set; }
    }
}
