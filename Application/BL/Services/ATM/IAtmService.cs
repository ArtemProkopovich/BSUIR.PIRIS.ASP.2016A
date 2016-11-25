using BL.Services.Credit.Models;

namespace BL.Services.ATM
{
    public interface IAtmService
    {
        CreditModel LoginUser(string creditCardNumber, string pin);
    }
}
