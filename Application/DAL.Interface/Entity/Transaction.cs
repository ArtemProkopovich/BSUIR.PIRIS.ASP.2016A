using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Entity
{
    public class Transaction : IEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Time { get; set; }
        public Account DebitAccount { get; set; }
        public Account CreditAccount { get; set; }
    }
}
