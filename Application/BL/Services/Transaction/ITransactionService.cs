using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services.Account.Models;
using BL.Services.Transaction.Models;

namespace BL.Services.Transaction
{
    public interface ITransactionService
    {
        void CommitTransaction(AccountModel debitAccount, AccountModel creditAccount, decimal amount);
        IEnumerable<TransactionModel> GetAll();
        IEnumerable<TransactionModel> GetAll(int accountId);
        IEnumerable<TransactionModel> GetAllByDay(int bankDayNumber);
    }
}
