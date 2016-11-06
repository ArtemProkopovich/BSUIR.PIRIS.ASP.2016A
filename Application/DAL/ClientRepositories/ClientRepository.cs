using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Interface.Entity;
using ORMLibrary;
using Client = DAL.Interface.Entity.Client;

namespace DAL.ClientRepositories
{
    public class ClientRepository : IRepository<Client>
    {
        private DatabaseContext Context { get; set; }
        public ClientRepository(DatabaseContext context)
        {
            this.Context = context;
        }

        public int Add(Client entity)
        {
            throw new NotImplementedException();
        }

        public Client Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Client entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
