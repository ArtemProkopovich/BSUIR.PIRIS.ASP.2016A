using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services.Account;
using BL.Services.Common;
using BL.Services.Credit.Models;
using BL.Services.Transaction;
using AppContext = ORMLibrary.AppContext;
using AutoMapper;
using BL.Services.Common.Model;
using Microsoft.Practices.Unity;

namespace BL.Services.Credit
{
    public class CreditService : BaseService, ICreditService
    {
        [Dependency]
        IAccountService AccountService { get; set; }

        [Dependency]
        ICommonService CommonService { get; set; }

        [Dependency]
        ITransactionService TransactionService { get; set; }

        public CreditService(AppContext context) : base(context)
        {
        }

        public void Create(CreditModel credit)
        {
            if (credit.Amount == 0)
                throw new ServiceException("Amount cannot be zero.");

            var dbCredit = Mapper.Map<CreditModel, ORMLibrary.Credit>(credit);
            dbCredit.PlanOfCredit = Context.PlanOfCredits.FirstOrDefault(e => e.Id == credit.PlanId);
            dbCredit.Client = Context.Clients.FirstOrDefault(e => e.Id == credit.ClientId);
            AccountService.CreateAccountsForCredit(dbCredit);
            InitializeCredidCardCredentials(dbCredit);
            dbCredit.StartDate = CommonService.CurrentBankDay;
            dbCredit.EndDate = dbCredit.StartDate + dbCredit.PlanOfCredit.BankDayPeriod;
            dbCredit.Amount = credit.Amount;
            

            TransactionService.CommitTransaction(AccountService.GetDevelopmentFundAccount(), dbCredit.MainAccount,
                dbCredit.Amount);
            TransactionService.CommitTransaction(dbCredit.MainAccount, AccountService.GetCashDeskAccount(),
                dbCredit.Amount);
            TransactionService.WithDrawCashDeskTransaction(dbCredit.Amount);

            Context.SaveChanges();
        }

        private void InitializeCredidCardCredentials(ORMLibrary.Credit credit)
        {
            Random random = new Random();
            credit.CreditCardNumber = credit.MainAccount.AccountNumber + random.Next(0, 1000);
            credit.CreditCardPin = random.Next(0, 10000).ToString();
        }

        public CreditModel Get(int id)
        {
            var credit = Context.Credits.FirstOrDefault(e => e.Id == id);
            return Mapper.Map<ORMLibrary.Credit, CreditModel>(credit);
        }

        public IEnumerable<CreditModel> GetAll()
        {
            return Context.Credits.ToArray().Select(Mapper.Map<ORMLibrary.Credit, CreditModel>);
        }

        public PlanOfPaymentModel GetPaymentSchedule(int creditId)
        {
            var credit = Context.Credits.FirstOrDefault(e => e.Id == creditId);
            PlanOfPaymentModel result = new PlanOfPaymentModel();
            result.CurrentDay = CommonService.StartDate +
                                new TimeSpan(CommonService.CurrentBankDay, 0, 0, 0);

            decimal allAmount = credit.Amount +
                                    credit.Amount * (credit.EndDate - credit.StartDate) *
                                    (decimal)credit.PlanOfCredit.Percent / CommonService.YearLength;
            decimal montlyAmount = credit.PlanOfCredit.Anuity
                ? allAmount/(credit.EndDate - credit.StartDate)*CommonService.MonthLength
                : credit.Amount*CommonService.MonthLength*
                  (decimal) credit.PlanOfCredit.Percent/CommonService.YearLength;
            result.PaymentSchedule = new Dictionary<DateTime, decimal>();
            decimal tempAmount = 0;
            for (int i = credit.StartDate+CommonService.MonthLength; i <= credit.EndDate; i+=CommonService.MonthLength)
            {
                tempAmount += montlyAmount;
                result.PaymentSchedule.Add(CommonService.StartDate + new TimeSpan(i, 0, 0, 0), montlyAmount);
            }
            result.PaymentSchedule.Add(CommonService.StartDate + new TimeSpan(credit.EndDate, 0, 0, 0),
                allAmount - tempAmount);
            return result;
        }

        public void CloseBankDay()
        {
            var credits =
                Context.Credits.Where(
                    e =>
                        e.StartDate > CommonService.CurrentBankDay && e.EndDate < CommonService.CurrentBankDay &&
                        e.Amount >= 0);
            foreach (var credit in credits)
            {
                CommitPercents(credit);
            }
        }

        private void CommitPercents(ORMLibrary.Credit credit)
        {
            decimal percentAmount;
            if (credit.PlanOfCredit.Anuity)
            {
                percentAmount = credit.Amount/(credit.EndDate - credit.StartDate) +
                                credit.Amount*(decimal) credit.PlanOfCredit.Percent/
                                CommonService.YearLength;
            }
            else
            {
                percentAmount = credit.Amount*(decimal) credit.PlanOfCredit.Percent/
                                CommonService.YearLength;
            }
            TransactionService.CommitTransaction(credit.PercentAccount, AccountService.GetDevelopmentFundAccount(),
                percentAmount);
        }

        public void CloseCredit(int id)
        {
            var credit = Context.Credits.FirstOrDefault(e => e.Id == id);
            if (credit.EndDate > CommonService.CurrentBankDay)
                throw new SystemException("Cannot close credit before credit term ended.");

            if (credit.Amount == 0)
                throw new SystemException("Credit already have been closed.");

            if (!credit.PlanOfCredit.Anuity)
            {
                TransactionService.CommitCashDeskDebitTransaction(credit.Amount);
                TransactionService.CommitTransaction(AccountService.GetCashDeskAccount(), credit.MainAccount,
                    credit.Amount);
                TransactionService.CommitTransaction(credit.MainAccount, AccountService.GetDevelopmentFundAccount(),
                    credit.Amount);
            }

            TransactionService.CommitCashDeskDebitTransaction(credit.PercentAccount.Balance);
            TransactionService.CommitTransaction(AccountService.GetCashDeskAccount(), credit.PercentAccount,
                credit.PercentAccount.Balance);

            credit.Amount = 0;

            Context.SaveChanges();
        }

        public void PayPercents(int id)
        {
            var credit = Context.Credits.FirstOrDefault(e => e.Id == id);
            if (credit.Amount == 0)
            {
                throw new ServiceException("Cannot pay percents for closed credit.");
            }

            var amount = credit.PercentAccount.Balance;
            TransactionService.WithDrawCashDeskTransaction(amount);
            TransactionService.CommitTransaction(AccountService.GetCashDeskAccount(), credit.PercentAccount, amount);
        }
    }
}
