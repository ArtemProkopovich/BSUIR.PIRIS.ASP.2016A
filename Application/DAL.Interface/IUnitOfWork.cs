using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Entity;

namespace DAL.Interface
{
    public interface IUnitOfWork
    {
        IRepository<Client> ClientRepository { get; set; }
    }
}
