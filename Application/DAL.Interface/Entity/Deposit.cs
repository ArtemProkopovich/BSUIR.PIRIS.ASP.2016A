using System;

namespace DAL.Interface.Entity
{
    public class Deposit : IEntity
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public PlanOfDeposit Plan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Amount { get; set; }
    }
}
