using System;
using System.Data.SqlClient;
using DAL.Interface;
using DAL.Interface.Entity;

namespace DAL.Obsolete
{
    public class UnitOfWork : IUnitOfWork
    {
        private SqlConnection connection;
        private readonly string connectionString;

        private SqlConnection Connection
        {
            get
            {
                if (connection != null) return connection;
                connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
        }

        private IRepository<Client> clientRepository;
        public IRepository<Client> Clients => clientRepository ?? (clientRepository = new ClientRepository(Connection));

        private IRepository<Citizenship> citizenshipRepository;
        public IRepository<Citizenship> Citizenships => citizenshipRepository ?? (citizenshipRepository = new CitizenshipRepository(Connection));

        private IRepository<Disability> disabilityRepository;
        public IRepository<Disability> DisabilityStatuses => disabilityRepository ?? (disabilityRepository = new DisabilityRepository(Connection));

        private IRepository<MaritalStatus> martialStatusRepository;
        public IRepository<MaritalStatus> MartialStatuses => martialStatusRepository ?? (martialStatusRepository = new MartialStatusRepository(Connection));

        private IRepository<Town> townRepository;
        public IRepository<Town> Towns => townRepository ?? (townRepository = new TownRepository(Connection));

        public IRepository<Account> Accounts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IRepository<Credit> Credits
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IRepository<CreditCard> CreditCards
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IRepository<Deposit> Deposits
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IRepository<Transaction> Transactions
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IRepository<PlanOfAccount> PlanOfAccounts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IRepository<PlanOfCredit> PlanOfCredits
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IRepository<PlanOfDeposit> PlanOfDeposits
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public UnitOfWork(IConfigurationManager manager)
        {
            connectionString = manager.GetConnectionString();
        }

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                connection?.Close();
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
