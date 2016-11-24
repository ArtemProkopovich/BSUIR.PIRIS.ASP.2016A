using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BL.Services.Deposit.Models;
using ORMLibrary;

namespace BL.Services.Deposit
{
    public class PlanOfDepositService : BaseService, IPlanOfDepositService
    {
        public PlanOfDepositService(ORMLibrary.AppContext context) : base(context)
        {
        }

        public void Create(PlanOfDepositModel plan)
        {
            var dbPlan = Mapper.Map<PlanOfDepositModel, PlanOfDeposit>(plan);
            dbPlan.MainPlanOfAccount = Context.PlanOfAccounts.FirstOrDefault(e => e.Id == plan.MainAccountPlanId);
            dbPlan.PercentPlanOfAccount = Context.PlanOfAccounts.FirstOrDefault(e => e.Id == plan.PercentAccountPlanId);
            Context.PlanOfDeposits.Add(dbPlan);
            Context.SaveChanges();
        }

        public IEnumerable<PlanOfDepositModel> GetAll()
        {
            return Context.PlanOfDeposits.ToArray().Select(Mapper.Map<PlanOfDeposit, PlanOfDepositModel>);
        }
    }
}
