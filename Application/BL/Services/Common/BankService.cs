using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services.Credit;
using BL.Services.Deposit;
using Microsoft.Practices.Unity;
using AppContext = ORMLibrary.AppContext;

namespace BL.Services.Common
{
    public class BankService : BaseService, IBankService
    {
        [Dependency]
        ICreditService CreditService { get; set; }

        [Dependency]
        IDepositService DepositService { get; set; } 

        ICommonService CommonService { get; set; }

        public BankService(AppContext context) : base(context)
        {
        }

        private void CloseBankDayWork()
        {
            DepositService.CloseBankDay();
            CreditService.CloseBankDay();
            CommonService.IncreaseCurrentBankDay();
        }

        public void CloseBankDay()
        {
            CloseBankDayWork();
            Context.SaveChanges();
        }

        public void CloseBankMonth()
        {
            for (int i = 0; i < CommonService.MonthLength; i++)
            {
                CloseBankDayWork();
            }
            Context.SaveChanges();
        }

        public void CloseBankYear()
        {
            for (int i = 0; i < CommonService.YearLength; i++)
            {
                CloseBankDayWork();
            }
            Context.SaveChanges();
        }     
    }
}
