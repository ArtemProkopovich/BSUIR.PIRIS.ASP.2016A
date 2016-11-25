using System.Collections.Generic;
using BL.Services.Transaction.Models;

namespace BL.Services.Transaction
{
    public interface ITransactionService
    {
        void CommitTransaction(int debitAccountId, int creditAccountId, decimal amount);
        void CommitCashDeskTransaction(decimal amount);
        IEnumerable<TransactionModel> GetAll();
        IEnumerable<TransactionModel> GetAll(int accountId);
        IEnumerable<TransactionModel> GetAllByDay(int bankDayNumber);
    }
}
