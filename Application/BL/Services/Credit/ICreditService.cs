using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services.Credit.Models;

namespace BL.Services.Credit
{
    public interface ICreditService
    {
        void Create(CreditModel credit);
        CreditModel Get(int id);
        IEnumerable<CreditModel> GetAll();
        PlanOfPaymentModel GetPaymentSchedule();
        void CloseBankDay();
        void PayPercents(int id);
        void CloseCredit(int id);
    }
}
