using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
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

        public void CommitCashDeskTransaction(decimal amount)
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction(int debitAccountId, int creditAccountId, decimal amount)
        {
            var debitAccount = Context.Accounts.FirstOrDefault(e => e.Id == debitAccountId);
            var creditAccount = Context.Accounts.FirstOrDefault(e => e.Id == creditAccountId);

            if (debitAccount == null || creditAccount == null)
                throw new AccountNotFoundException("One of transaction account was not found.");
                
            if (debitAccount.PlanOfAccount.AccountType == "P")
            {
                if (amount > debitAccount.DebitValue)
                    throw new InsufficientFundsException("Insufficient Funds");
                debitAccount.DebitValue -= amount;
                debitAccount.Balance = debitAccount.CreditValue - debitAccount.DebitValue;
            }
            else
            {
                if (amount > debitAccount.CreditValue)
                    throw new InsufficientFundsException("Insufficient Funds");
                debitAccount.CreditValue -= amount;
                debitAccount.Balance = debitAccount.DebitValue - debitAccount.CreditValue;
            }

            if (creditAccount.PlanOfAccount.AccountType == "P")
            {
                debitAccount.CreditValue += amount;
                debitAccount.Balance = debitAccount.CreditValue - debitAccount.DebitValue;
            }
            else
            {
                debitAccount.DebitValue += amount;
                debitAccount.Balance = debitAccount.DebitValue - debitAccount.CreditValue;
            }

            ORMLibrary.Transaction trs = new ORMLibrary.Transaction()
            {
                DebetAccountId = debitAccount.Id,
                CreditAccountId = creditAccount.Id,
                Amount = amount
            };

            Context.Transactions.Add(trs);

            Context.SaveChanges();
        }

        public IEnumerable<TransactionModel> GetAll()
        {
            return
                Context.Transactions.ToArray()
                    .Select(Mapper.Map<ORMLibrary.Transaction, TransactionModel>);
        }

        public IEnumerable<TransactionModel> GetAll(int accountId)
        {
            return
                Context.Transactions.ToArray()
                    .Where(e => e.DebetAccountId == accountId || e.CreditAccountId == accountId)
                    .Select(Mapper.Map<ORMLibrary.Transaction, TransactionModel>);
        }

        public IEnumerable<TransactionModel> GetAllByDay(int bankDayNumber)
        {
            throw new NotImplementedException();
        }
    }
}
