using System;

namespace BL.Services.Common
{
    public class CommonService : ICommonService
    {

        static CommonService() { }

        public static int currentBankDay;
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
