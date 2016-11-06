using System;
using System.Collections.Generic;
using DAL.Interface;
using DAL.Interface.Entity;
using ORMLibrary;
using PlanOfCredit = DAL.Interface.Entity.PlanOfCredit;

namespace DAL.Plan
{
    public class PlanOfCreditRepository : IRepository<PlanOfCredit>
    {
        private DatabaseContext Context { get; set; }
        public PlanOfCreditRepository(DatabaseContext context)
        {
            this.Context = context;
        }

        public int Add(PlanOfCredit entity)
        {
            throw new NotImplementedException();
        }

        public PlanOfCredit Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlanOfCredit> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(PlanOfCredit entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
