using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Interface.Entity;

namespace BL.Interface
{
    public interface IClientService : IService<Client>
    {
        IEnumerable<string> GetTowns();
        IEnumerable<string> GetCitizenships();
        IEnumerable<string> GetMartialStatuses();
        IEnumerable<string> GetDisabilityStatuses();
    }
}
