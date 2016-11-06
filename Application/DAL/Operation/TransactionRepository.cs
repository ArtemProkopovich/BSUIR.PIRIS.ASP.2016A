using System;
using System.Collections.Generic;
using DAL.Interface;
using ORMLibrary;
using Transaction = DAL.Interface.Entity.Transaction;

namespace DAL.Operation
{
    public class TransactionRepository : IRepository<Transaction>
    {
        private DatabaseContext Context { get; set; }
        public TransactionRepository(DatabaseContext context)
        {
            this.Context = context;
        }

        public int Add(Transaction entity)
        {
            throw new NotImplementedException();
        }

        public Transaction Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Transaction entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
