using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.Services.Common.Model;
using ORMLibrary;
using AppContext = ORMLibrary.AppContext;

namespace BL.Services.Common
{
    public class CommonService : BaseService, ICommonService
    {
        public CommonService(AppContext context) : base(context)
        {
            systemVars = GetSystemVariables();
            StartDate = systemVars.StartDate;
            StartBankDay = systemVars.StartBankDay;
            CurrentBankDay = systemVars.CurrentBankDay;
        }

        private SystemVariable systemVars;

        public void IncreaseCurrentBankDay()
        {
            systemVars.CurrentBankDay++;
            Context.SaveChanges();
        }

        public int CurrentBankDay { get; }

        public int MonthLength { get; } = 30;

        public int StartBankDay { get; private set; }

        public DateTime StartDate { get; private set; }

        public int YearLength { get; } = 365;

        private SystemVariable GetSystemVariables()
        {
            var sv = Context.SystemVariables.FirstOrDefault();
            if (sv == null)
            {
                sv =
                    Context.SystemVariables.Add(new SystemVariable()
                    {
                        StartBankDay = 0,
                        CurrentBankDay = 0,
                        StartDate = DateTime.Now.Date
                    });
                Context.SaveChangesAsync();
            }
            return sv;
        }
    }
}
