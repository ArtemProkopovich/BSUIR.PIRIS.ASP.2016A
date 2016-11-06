using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using ORMLibrary;
using Account = DAL.Interface.Entity.Account;

namespace DAL.ClientRepositories
{
    public class AccountRepository: IRepository<Account>
    {
        private DatabaseContext Context { get; set; }
        public AccountRepository(DatabaseContext context)
        {
            this.Context = context;
        }

        public int Add(Account entity)
        {
            throw new NotImplementedException();
        }

        public Account Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Account entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
