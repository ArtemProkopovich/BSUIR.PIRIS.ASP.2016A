using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BL.Services.Credit.Models;
using ORMLibrary;
using AppContext = ORMLibrary.AppContext;

namespace BL.Services.Credit
{
    public class PlanOfCreditService : BaseService, IPlanOfCreditService
    {
        public PlanOfCreditService(AppContext context) : base(context)
        {
        }

        public void Create(PlanOfCreditModel plan)
        {
            var dbPlan = Mapper.Map<PlanOfCreditModel, PlanOfCredit>(plan);
            dbPlan.MainPlanOfAccount = Context.PlanOfAccounts.FirstOrDefault(e => e.Id == plan.MainAccountPlanId);
            dbPlan.PercentPlanOfAccount = Context.PlanOfAccounts.FirstOrDefault(e => e.Id == plan.PercentAccountPlanId);
            Context.PlanOfCredits.Add(dbPlan);
            Context.SaveChanges();
        }

        public IEnumerable<PlanOfCreditModel> GetAll()
        {
            return Context.PlanOfCredits.ToArray().Select(Mapper.Map<PlanOfCredit, PlanOfCreditModel>);
        }
    }
}
