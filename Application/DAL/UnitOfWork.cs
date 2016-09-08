using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Interface.Entity;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Client> ClientRepository { get; set; }
    }
}
