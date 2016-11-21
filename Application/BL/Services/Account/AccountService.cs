using BL.Services.Account.Models;
using ORMLibrary;

namespace BL.Services.Account
{
    public class AccountService :BaseService, IAccountService
    {
        public AccountService(AppContext context) : base(context)
        {
        }

        public AccountModel GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
