using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services.Credit.Models;
using AppContext = ORMLibrary.AppContext;

namespace BL.Services.ATM
{
    public class AtmService : BaseService, IAtmService
    {
        public AtmService(AppContext context) : base(context)
        {
        }

        public CreditModel LoginUser(string creditNumber, string pin)
        {
            throw new NotImplementedException();
        }
    }
}
