using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services.Deposit.Models;
using AppContext = ORMLibrary.AppContext;

namespace BL.Services.Deposit
{
    public class DepositService : BaseService, IDepositService
    {
        public DepositService(AppContext context) : base(context)
        {
        }

        public void Create(DepositModel deposit)
        {
            throw new NotImplementedException();
        }

        public DepositModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DepositModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void CloseBankDay()
        {
            throw new NotImplementedException();
        }

        public void CloseDeposit(int id)
        {
            throw new NotImplementedException();
        }
    }
}
