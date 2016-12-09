using System;
using System.Linq;

namespace BL.Services.Common
{
    public class CommonService : BaseService, ICommonService
    {

        static CommonService() { }

        public static int currentBankDay = Context.Transactions?.Max(e => e.TransactionDay) ?? 0;
        public static DateTime startDate = DateTime.Now;

        public int MonthLength { get; } = 30;

        public int YearLength { get; } = 365;

        public int StartBankDay { get; } = 0;

        public int CurrentBankDay => currentBankDay;

        public DateTime StartDate => startDate;

        public void IncreaseCurrentBankDay()
        {
            currentBankDay++;
        }
    }
}
