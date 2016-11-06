using DAL.Interface;
using DAL.ClientRepositories;
using DAL.Operation;
using DAL.Plan;
using ORMLibrary;
using Account = DAL.Interface.Entity.Account;
using Citizenship = DAL.Interface.Entity.Citizenship;
using Client = DAL.Interface.Entity.Client;
using Credit = DAL.Interface.Entity.Credit;
using CreditCard = DAL.Interface.Entity.CreditCard;
using Deposit = DAL.Interface.Entity.Deposit;
using Disability = DAL.Interface.Entity.Disability;
using MaritalStatus = DAL.Interface.Entity.MaritalStatus;
using PlanOfAccount = DAL.Interface.Entity.PlanOfAccount;
using PlanOfCredit = DAL.Interface.Entity.PlanOfCredit;
using PlanOfDeposit = DAL.Interface.Entity.PlanOfDeposit;
using Town = DAL.Interface.Entity.Town;
using Transaction = DAL.Interface.Entity.Transaction;


namespace DAL
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private DatabaseContext Context { get; }
        public EfUnitOfWork(DatabaseContext context)
        {
            this.Context = context;
        }

        private IRepository<Client> clientRepository;
        public IRepository<Client> Clients => clientRepository ?? (clientRepository = new ClientRepository(Context));

        private IRepository<Town> townRepository;
        public IRepository<Town> Towns => townRepository ?? (townRepository = new TownRepository(Context));

        private IRepository<Citizenship> citizenshipRepository;
        public IRepository<Citizenship> Citizenships
            => citizenshipRepository ?? (citizenshipRepository = new CitizenshipRepository(Context));

        private IRepository<MaritalStatus> maritalStatusReposiotry;
        public IRepository<MaritalStatus> MaritalStatuses
            => maritalStatusReposiotry ?? (maritalStatusReposiotry = new MaritalStatusRepository(Context));

        private IRepository<Disability> disabilityRepository;
        public IRepository<Disability> DisabilityStatuses
            => disabilityRepository ?? (disabilityRepository = new DisabilityRepository(Context));

        private IRepository<Account> accountRepository;
        public IRepository<Account> Accounts
            => accountRepository ?? (accountRepository = new AccountRepository(Context));

        private IRepository<Credit> creditRepository;
        public IRepository<Credit> Credits => creditRepository ?? (creditRepository = new CreditRepository(Context));

        private IRepository<CreditCard> creditCardRepository;
        public IRepository<CreditCard> CreditCards
            => creditCardRepository ?? (creditCardRepository = new CreditCardRepository(Context));

        private IRepository<Deposit> depositRepository;
        public IRepository<Deposit> Deposits
            => depositRepository ?? (depositRepository = new DepositRepository(Context));

        private IRepository<Transaction> transactionRepository;
        public IRepository<Transaction> Transactions
            => transactionRepository ?? (transactionRepository = new TransactionRepository(Context));

        private IRepository<PlanOfAccount> planAccountRepository;
        public IRepository<PlanOfAccount> PlanOfAccounts
            => planAccountRepository ?? (planAccountRepository = new PlanOfAccountRepository(Context));

        private IRepository<PlanOfCredit> planCreditRepository;

        public IRepository<PlanOfCredit> PlanOfCredits
            => planCreditRepository ?? (planCreditRepository = new PlanOfCreditRepository(Context));

        private IRepository<PlanOfDeposit> planDepositRepository;
        public IRepository<PlanOfDeposit> PlanOfDeposits
            => planDepositRepository ?? (planDepositRepository = new PlanOfDepositRepository(Context));

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
