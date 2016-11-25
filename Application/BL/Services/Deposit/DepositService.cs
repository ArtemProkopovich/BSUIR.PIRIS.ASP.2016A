using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.Services.Deposit.Models;
using ORMLibrary;
using AppContext = ORMLibrary.AppContext;

namespace BL.Services.Deposit
{
    public class DepositService : BaseService, IDepositService
    {
        public DepositService(AppContext context) : base(context)
        {
        }

        public void Create(DepositModel deposit)
        {
            var dbDeposit = Mapper.Map<DepositModel, ORMLibrary.Deposit>(deposit);
            var dbPlan = Context.PlanOfDeposits.FirstOrDefault(e => e.Id == deposit.PlanOfDeposit.Id);
            dbDeposit.PlanOfDeposit = dbPlan;
            dbDeposit.MainAccount = new ORMLibrary.Account() {PlanOfAccount = dbPlan.MainPlanOfAccount};
            dbDeposit.PercentAccount = new ORMLibrary.Account() {PlanOfAccount = dbPlan.PercentPlanOfAccount};
            dbDeposit.Client = Context.Clients.FirstOrDefault(e => e.Id == deposit.Client.Id);
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
            throw new NotImplementedException();
        }

        public void CloseDeposit(int id)
        {
            throw new NotImplementedException();
        }
    }
}
