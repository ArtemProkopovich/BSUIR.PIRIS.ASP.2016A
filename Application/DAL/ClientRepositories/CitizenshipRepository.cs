using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Interface.Entity;
using ORMLibrary;
using Citizenship = DAL.Interface.Entity.Citizenship;

namespace DAL.ClientRepositories
{
    public class CitizenshipRepository : IRepository<Citizenship>
    {
        private DatabaseContext Context { get; set; }

        public CitizenshipRepository(DatabaseContext context)
        {
            this.Context = context;
        }

        public int Add(Citizenship entity)
        {
            throw new NotImplementedException();
        }

        public Citizenship Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Citizenship> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Citizenship entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
