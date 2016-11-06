using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.Entity;

namespace DAL.Interface
{
    public interface IUnitOfWork
    {
        IRepository<Client> Clients { get; }
        IRepository<Town> Towns { get; }
        IRepository<Citizenship> Citizenships { get; }
        IRepository<MaritalStatus> MaritalStatuses { get; }
        IRepository<Disability> DisabilityStatuses { get; }

        IRepository<Account> Accounts { get; }
        IRepository<Credit> Credits { get; }
        IRepository<CreditCard> CreditCards { get; }
        IRepository<Deposit> Deposits { get; }
        IRepository<Transaction> Transactions { get; }

        IRepository<PlanOfAccount> PlanOfAccounts { get; }
        IRepository<PlanOfCredit> PlanOfCredits { get; }
        IRepository<PlanOfDeposit> PlanOfDeposits { get; }
        void Save();
    }
}
