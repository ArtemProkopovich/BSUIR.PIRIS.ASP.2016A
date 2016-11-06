using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Entity
{
    public class PlanOfAccount : IEntity
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
