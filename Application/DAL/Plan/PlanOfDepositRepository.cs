using System;
using System.Collections.Generic;
using DAL.Interface;
using ORMLibrary;
using PlanOfDeposit = DAL.Interface.Entity.PlanOfDeposit;

namespace DAL.Plan
{
    public class PlanOfDepositRepository : IRepository<PlanOfDeposit>
    {
        private DatabaseContext Context { get; set; }
        public PlanOfDepositRepository(DatabaseContext context)
        {
            this.Context = context;
        }

        public int Add(PlanOfDeposit entity)
        {
            throw new NotImplementedException();
        }

        public PlanOfDeposit Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlanOfDeposit> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(PlanOfDeposit entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
