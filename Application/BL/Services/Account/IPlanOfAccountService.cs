using System.Collections.Generic;
using BL.Services.Account.Models;
using ORMLibrary;

namespace BL.Services.Account
{
    public interface IPlanOfAccountService
    {
        IEnumerable<PlanOfAccountModel> GetAll();

        PlanOfAccount GetPlanOfAccountByNumber(string number);

        PlanOfAccount GetPlanOfAccountById(int id);
    }
}
