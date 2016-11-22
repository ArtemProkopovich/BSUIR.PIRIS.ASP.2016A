using System.Collections.Generic;
using BL.Services.Account.Models;
using System.Linq;
using AutoMapper;
using Ninject;
using ORMLibrary;
using BL.Services.Client.Models;
using System;

namespace BL.Services.Account
{
    public class AccountService : BaseService, IAccountService
    {
        [Inject]
        public IPlanOfAccountService PlanService { get; set; }

        public AccountService(ORMLibrary.AppContext context) : base(context)
        {
            if (!Context.Accounts.Any())
            {
                InitAccounts();
            }
        }

        public AccountModel Create(AccountModel account, ClientModel client)
        {
            var plan = PlanService.GetPlanOfAccountById(account.PlanId);
            ORMLibrary.Account dbAccount = new ORMLibrary.Account()
            {
                AccountNumber = GenerateAccountNumber(plan.AccountNumber, client),
                DebitValue = account.DebitValue,
                CreditValue = account.CreditValue,
                Balance = account.DebitValue - account.CreditValue,
                PlanOfAccount = plan,
            };
            dbAccount = Context.Accounts.Add(dbAccount);
            Context.SaveChanges();
            return Mapper.Map<ORMLibrary.Account, AccountModel>(dbAccount);
        }

        public IEnumerable<AccountModel> GetAll()
        {
            return Context.Accounts.ToArray().Select(Mapper.Map<ORMLibrary.Account, AccountModel>);
        }

        private void InitAccounts()
        {
            Context.Accounts.AddRange(new List<ORMLibrary.Account>()
            {
                CreateAccount("1010", 0, 0),
                CreateAccount("7327", 0, 10000000)
            });
            Context.SaveChanges();
        }

        private ORMLibrary.Account CreateAccount(string accountPlanNumber, decimal debit, decimal credit)
        {
            ORMLibrary.Account account = new ORMLibrary.Account()
            {
                Balance = credit - debit,
                CreditValue = credit,
                DebitValue = debit,
                PlanOfAccount = PlanService.GetPlanOfAccountByNumber(accountPlanNumber),
                AccountNumber = GenerateAccountNumber(accountPlanNumber, null)
            };
            return account;
        }

        private string GenerateAccountNumber(string accountPlanNumber, ClientModel client)
        {
            if (client == null)
                return accountPlanNumber + "123456789";
            return accountPlanNumber + "987654321";
        }
    }
}
