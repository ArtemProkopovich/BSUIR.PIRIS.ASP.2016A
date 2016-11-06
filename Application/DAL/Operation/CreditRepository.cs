using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Interface.Entity;
using ORMLibrary;
using Credit = DAL.Interface.Entity.Credit;

namespace DAL.Operation
{
    public class CreditRepository : IRepository<Credit>
    {
        private DatabaseContext Context { get; set; }
        public CreditRepository(DatabaseContext context)
        {
            this.Context = context;
        }

        public int Add(Credit entity)
        {
            throw new NotImplementedException();
        }

        public Credit Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Credit> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Credit entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
