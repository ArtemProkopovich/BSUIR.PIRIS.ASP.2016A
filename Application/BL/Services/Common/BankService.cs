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
    public class BankService : BaseService, IBankService
    {
        public BankService(AppContext context) : base(context)
        {
        }

        public SystemVariableModel GetSystemVariables()
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
            return Mapper.Map<SystemVariable, SystemVariableModel>(sv);
        }
    }
}
