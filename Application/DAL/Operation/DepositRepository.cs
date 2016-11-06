using System;
using System.Collections.Generic;
using DAL.Interface;
using DAL.Interface.Entity;
using ORMLibrary;
using Deposit = DAL.Interface.Entity.Deposit;

namespace DAL.Operation
{
    public class DepositRepository : IRepository<Deposit>
    {
        private DatabaseContext Context { get; set; }
        public DepositRepository(DatabaseContext context)
        {
            this.Context = context;
        }

        public int Add(Deposit entity)
        {
            throw new NotImplementedException();
        }

        public Deposit Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Deposit> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Deposit entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
