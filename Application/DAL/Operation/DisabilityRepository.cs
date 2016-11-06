using System;
using System.Collections.Generic;
using DAL.Interface;
using DAL.Interface.Entity;
using ORMLibrary;
using Disability = DAL.Interface.Entity.Disability;

namespace DAL.Operation
{
    public class DisabilityRepository : IRepository<Disability>
    {
        private DatabaseContext Context { get; set; }
        public DisabilityRepository(DatabaseContext context)
        {
            this.Context = context;
        }

        public int Add(Disability entity)
        {
            throw new NotImplementedException();
        }

        public Disability Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Disability> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Disability entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
