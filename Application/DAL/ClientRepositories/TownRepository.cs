using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Interface.Entity;
using ORMLibrary;
using Town = DAL.Interface.Entity.Town;

namespace DAL.ClientRepositories
{
    public class TownRepository : IRepository<Town>
    {
        private DatabaseContext Context { get; set; }
        public TownRepository(DatabaseContext context)
        {
            this.Context = context;
        }

        public int Add(Town entity)
        {
            throw new NotImplementedException();
        }

        public Town Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Town> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Town entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
