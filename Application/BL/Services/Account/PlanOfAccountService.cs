using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BL.Services.Account.Models;
using ORMLibrary;

namespace BL.Services.Account
{
    public class PlanOfAccountService : BaseService, IPlanOfAccountService
    {
        public PlanOfAccountService(ORMLibrary.AppContext context) : base(context)
        {
            if (!Context.PlanOfAccounts.Any())
            {
                InitPlanOfAccounts();
            }
        }

        public PlanOfAccount GetPlanOfAccountByNumber(string number)
        {
            return Context.PlanOfAccounts.FirstOrDefault(e => e.AccountNumber == number);
        }

        public PlanOfAccount GetPlanOfAccountById(int id)
        {
            return Context.PlanOfAccounts.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<PlanOfAccountModel> GetAll()
        {
            return Context.PlanOfAccounts.ToArray().Select(Mapper.Map<PlanOfAccount, PlanOfAccountModel>);
        }

        private void InitPlanOfAccounts()
        {
            Context.PlanOfAccounts.AddRange(new List<PlanOfAccount>
            {
                new PlanOfAccount()
                {
                    AccountName = "Passive account for Individuals",
                    AccountNumber = "3014",
                    AccountType = "P",
                },
                new PlanOfAccount()
                {
                    AccountName = "Active account for Entities",
                    AccountNumber = "2400",
                    AccountType = "A",
                },
                new PlanOfAccount()
                {
                    AccountName = "Bank Insurance Fund account",
                    AccountNumber = "1010",
                    AccountType = "A",
                },
                new PlanOfAccount()
                {
                    AccountName = "Bank Development Fund account",
                    AccountNumber = "7327",
                    AccountType = "P",
                }
            });
            Context.SaveChanges();
        }
    }
}
