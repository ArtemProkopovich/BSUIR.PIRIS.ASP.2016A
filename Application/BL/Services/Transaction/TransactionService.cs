using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using BL.Services.Account;
using BL.Services.Account.Models;
using BL.Services.Transaction.Models;
using Ninject;
using AppContext = ORMLibrary.AppContext;
using ORMLibrary;

namespace BL.Services.Transaction
{
    public class TransactionService : BaseService, ITransactionService
    {
        [Inject]
        IAccountService AccountService { get; set; }

        public TransactionService(AppContext context) : base(context)
        {
        }

        public void CommitCashDeskTransaction(decimal amount)
        {
            var account = AccountService.GetCashDeskAccount();
            account.DebitValue += amount;
            account.Balance = account.DebitValue - account.CreditValue;
        }

        public void WithDrawCashDeskTransaction(decimal amount)
        {
            var account = AccountService.GetCashDeskAccount();
            account.CreditValue -= amount;
            account.Balance = account.DebitValue - account.CreditValue;
        }

        public void CommitTransaction(int debitAccountId, int creditAccountId, decimal amount)
        {
            var debitAccount = Context.Accounts.FirstOrDefault(e => e.Id == debitAccountId);
            var creditAccount = Context.Accounts.FirstOrDefault(e => e.Id == creditAccountId);

            if (debitAccount == null || creditAccount == null)
                throw new AccountNotFoundException("One of transaction account was not found.");

            CommitTransaction(debitAccount, creditAccount, amount);
        }

        public void CommitTransaction(ORMLibrary.Account debitAccount, ORMLibrary.Account creditAccount, decimal amount)
        {
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
                    .Where(e => e.DebetAccountId == accountId || e.CreditAccountId == accountId).ToArray()
                    .Select(Mapper.Map<ORMLibrary.Transaction, TransactionModel>);
        }

        public IEnumerable<TransactionModel> GetAllByDay(int bankDayNumber)
        {
            return Context.Transactions.Reverse().ToArray().Select(Mapper.Map<ORMLibrary.Transaction, TransactionModel>);
        }
    }
}
