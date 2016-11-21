using System.Collections.Generic;

namespace BL.Services.Client
{
    public interface IClientService
    {
        Models.ClientModel Add(Models.ClientModel client);
        IEnumerable<Models.ClientModel> Get(int id);
        Models.ClientModel GetAll();
        void Delete(int id);
        void Update(Models.ClientModel client);
    }
}
