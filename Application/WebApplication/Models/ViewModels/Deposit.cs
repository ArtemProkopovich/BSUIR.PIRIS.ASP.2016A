
namespace WebApplication.Models.ViewModels
{
    public class Deposit
    {
        public int Id { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public decimal Amount { get; set; }
        public decimal CurrentPercentAmount { get; set; }
        public decimal PercentAmountForDay { get; set; }
        public Client Client { get; set; }
        public PlanOfDeposit PlanOfDeposit { get; set; }
    }
}