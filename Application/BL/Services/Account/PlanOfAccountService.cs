using BL.Services.Account.Models;
using ORMLibrary;

namespace BL.Services.Account
{
    public class PlanOfAccountService:BaseService, IPlanOfAccountService
    {
        public PlanOfAccountService(AppContext context) : base(context)
        {
        }

        public PlanOfAccountModel GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
