using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Interface.Entity;
using ORMLibrary;

namespace DAL.ClientRepositories
{
    public class MaritalStatusRepository : IRepository<MaritalStatus>
    {
        private DatabaseContext Context { get; set; }
        public MaritalStatusRepository(DatabaseContext context)
        {
            this.Context = context;
        }

        public int Add(MaritalStatus entity)
        {
            throw new NotImplementedException();
        }

        public MaritalStatus Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MaritalStatus> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(MaritalStatus entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
