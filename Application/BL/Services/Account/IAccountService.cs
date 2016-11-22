using System.Collections.Generic;
using BL.Services.Account.Models;
using BL.Services.Client.Models;

namespace BL.Services.Account
{
    public interface IAccountService
    {
        AccountModel Create(AccountModel account, ClientModel client);
        IEnumerable<AccountModel> GetAll();
    }
}
