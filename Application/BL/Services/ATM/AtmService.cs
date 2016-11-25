using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.Services.Credit.Models;
using AppContext = ORMLibrary.AppContext;

namespace BL.Services.ATM
{
    public class AtmService : BaseService, IAtmService
    {
        public AtmService(AppContext context) : base(context)
        {
        }

        public CreditModel LoginUser(string creditCardNumber, string pin)
        {
            var credit =
                Context.Credits.FirstOrDefault(
                    e => e.CreditCardNumber == creditCardNumber && e.CreditCardPin == pin);
            return Mapper.Map<ORMLibrary.Credit, CreditModel>(credit);
        }
    }
}
