using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Services.Client.Models;
using AppContext = ORMLibrary.AppContext;

namespace BL.Services.Client
{
    public class ClientService : BaseService, IClientService
    {
        public ClientService(AppContext context) : base(context)
        {
        }

        public Models.ClientModel Add(Models.ClientModel client)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.ClientModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Models.ClientModel GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Models.ClientModel client)
        {
            throw new NotImplementedException();
        }
    }
}
