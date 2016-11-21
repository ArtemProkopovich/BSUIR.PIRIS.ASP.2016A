using System;
using System.Collections.Generic;
using BL.Services.Account.Models;
using BL.Services.Transaction.Models;
using AppContext = ORMLibrary.AppContext;

namespace BL.Services.Transaction
{
    public class TransactionService : BaseService, ITransactionService
    {
        public TransactionService(AppContext context) : base(context)
        {
        }

        public void CommitTransaction(AccountModel debitAccount, AccountModel creditAccount, decimal amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransactionModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransactionModel> GetAll(int accountId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransactionModel> GetAllByDay(int bankDayNumber)
        {
            throw new NotImplementedException();
        }
    }
}
