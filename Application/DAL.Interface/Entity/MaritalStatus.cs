using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Entity
{
    public class MaritalStatus : IEntity
    {
        public int Id { get; set; }
        public string Status { get; set; }
    }
}
