using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Entity;

namespace DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        void Close();
        IRepository<Client> Clients { get; }
        IRepository<Town> Towns { get; }
        IRepository<Citizenship> Citizenships { get; }
        IRepository<MartialStatus> MartialStatuses { get; }
        IRepository<Disability> DisabilityStatuses { get; }
    }
}
