using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.Services.Account;
using BL.Services.Common;
using BL.Services.Common.Model;
using BL.Services.Deposit.Models;
using BL.Services.Transaction;
using Ninject;
using ORMLibrary;
using AppContext = ORMLibrary.AppContext;

namespace BL.Services.Deposit
{
    public class DepositService : BaseService, IDepositService
    {
        [Inject]
        IAccountService AccountService { get; set; }

        [Inject]
        IBankService BankService { get; set; }

        [Inject] 
        ITransactionService TransactionService { get; set; }

        private const int MonthLength = 30;
        private const int YearLength = 365;

        public DepositService(AppContext context) : base(context)
        {
        }

        public void Create(DepositModel deposit)
        {
            var dbDeposit = Mapper.Map<DepositModel, ORMLibrary.Deposit>(deposit);
            dbDeposit.PlanOfDeposit = Context.PlanOfDeposits.FirstOrDefault(e => e.Id == deposit.PlanId);
            dbDeposit.Client = Context.Clients.FirstOrDefault(e => e.Id == deposit.ClientId);
            AccountService.CreateAccountsForDeposit(dbDeposit);
            dbDeposit.StartDate = BankService.GetSystemVariables().CurrentBankDay;
            dbDeposit.Amount = deposit.Amount;

            HoldMoneyOnDeposit(dbDeposit);  
                    
            Context.SaveChanges();
        }

        public DepositModel Get(int id)
        {
            var client = Context.Deposits.FirstOrDefault(e => e.Id == id);
            return Mapper.Map<ORMLibrary.Deposit, DepositModel>(client);
        }

        public IEnumerable<DepositModel> GetAll()
        {
            return Context.Deposits.ToArray().Select(Mapper.Map<ORMLibrary.Deposit, DepositModel>);
        }

        public void CloseBankDay()
        {
            throw new NotImplementedException();
        }

        public void WithdrawPercents(int id)
        {
            var deposit = Context.Deposits.FirstOrDefault(e => e.Id == id);
            if (!deposit.PlanOfDeposit.Revocable ||
                (BankService.GetSystemVariables().CurrentBankDay - deposit.StartDate)%MonthLength != 0)
            {
                throw new ServiceException("Cannot withdraw percents before month ended.");
            }

            TransactionService.CommitTransaction(AccountService.GetDevelopmentFundAccount(), deposit.PercentAccount,
                deposit.PercentAccount.DebitValue);
            TransactionService.CommitTransaction(deposit.PercentAccount, AccountService.GetCashDeskAccount(),
                deposit.PercentAccount.CreditValue);

            Context.SaveChanges();
        }

        public void CloseDeposit(int id)
        {
            var deposit = Context.Deposits.FirstOrDefault(e => e.Id == id);
            if (!deposit.PlanOfDeposit.Revocable && deposit.EndDate > BankService.GetSystemVariables().CurrentBankDay)
            {
                throw new SystemException("Cannot close deposit before deposit term ended.");
            }

            TransactionService.CommitTransaction(AccountService.GetDevelopmentFundAccount(), deposit.MainAccount,
                    deposit.MainAccount.CreditValue);
            TransactionService.CommitTransaction(deposit.MainAccount, AccountService.GetCashDeskAccount(),
                deposit.MainAccount.CreditValue);

            TransactionService.CommitTransaction(AccountService.GetDevelopmentFundAccount(), deposit.PercentAccount,
                -deposit.PercentAccount.DebitValue);
            TransactionService.CommitTransaction(deposit.PercentAccount, AccountService.GetCashDeskAccount(),
                -deposit.PercentAccount.DebitValue);
            deposit.Amount = 0;

            Context.SaveChanges();
        }

        private void HoldMoneyOnDeposit(ORMLibrary.Deposit deposit)
        {
            TransactionService.CommitCashDeskTransaction(deposit.Amount);
            TransactionService.CommitTransaction(AccountService.GetCashDeskAccount(), deposit.MainAccount,
                deposit.Amount);
            TransactionService.CommitTransaction(deposit.MainAccount, AccountService.GetDevelopmentFundAccount(),
                deposit.Amount);
        }
    }
}
