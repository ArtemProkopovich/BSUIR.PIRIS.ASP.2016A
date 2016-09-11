using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Interface.Entity;

namespace DAL
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

        private IRepository<MartialStatus> martialStatusRepository;
        public IRepository<MartialStatus> MartialStatuses => martialStatusRepository ?? (martialStatusRepository = new MartialStatusRepository(Connection));

        private IRepository<Town> townRepository;
        public IRepository<Town> Towns => townRepository ?? (townRepository = new TownRepository(Connection));

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
    }
}
