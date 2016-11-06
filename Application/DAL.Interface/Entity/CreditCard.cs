using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Entity
{
    public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public Credit Credit { get; set; }
        public string PinCode { get; set; }
    }
}
