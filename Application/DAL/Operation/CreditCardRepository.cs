using System;
using System.Collections.Generic;
using DAL.Interface;
using DAL.Interface.Entity;
using ORMLibrary;
using CreditCard = DAL.Interface.Entity.CreditCard;

namespace DAL.Operation
{
    public class CreditCardRepository: IRepository<CreditCard>
    {
        private DatabaseContext Context { get; set; }
        public CreditCardRepository(DatabaseContext context)
        {
            this.Context = context;
        }

        public int Add(CreditCard entity)
        {
            throw new NotImplementedException();
        }

        public CreditCard Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CreditCard> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(CreditCard entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
