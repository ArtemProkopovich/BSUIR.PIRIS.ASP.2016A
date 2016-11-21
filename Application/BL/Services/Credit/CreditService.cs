using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services.Credit.Models;
using AppContext = ORMLibrary.AppContext;

namespace BL.Services.Credit
{
    public class CreditService : BaseService, ICreditService
    {
        public CreditService(AppContext context) : base(context)
        {
        }

        public void Create(CreditModel credit)
        {
            throw new NotImplementedException();
        }

        public CreditModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CreditModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void CloseBankDay()
        {
            throw new NotImplementedException();
        }

        public void CloseCredit(int id)
        {
            throw new NotImplementedException();
        }
    }
}
