using System;
using System.Collections.Generic;
using DAL.Interface;
using DAL.Interface.Entity;
using ORMLibrary;
using PlanOfAccount = DAL.Interface.Entity.PlanOfAccount;

namespace DAL.Plan
{
    public class PlanOfAccountRepository : IRepository<PlanOfAccount>
    {
        private DatabaseContext Context { get; set; }
        public PlanOfAccountRepository(DatabaseContext context)
        {
            this.Context = context;
        }

        public int Add(PlanOfAccount entity)
        {
            throw new NotImplementedException();
        }

        public PlanOfAccount Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlanOfAccount> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(PlanOfAccount entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
