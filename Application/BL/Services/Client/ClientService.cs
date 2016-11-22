using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.Services.Client.Models;
using BL.Services.Common.Model;
using AppContext = ORMLibrary.AppContext;

namespace BL.Services.Client
{
    public class ClientService : BaseService, IClientService
    {
        public ClientService(AppContext context) : base(context)
        {
        }

        public ClientModel Add(ClientModel client)
        {
            try
            {
                var dbClient = Mapper.Map<ClientModel, ORMLibrary.Client>(client);
                dbClient.Disability = Context.Disabilities.First(e => e.Id == client.Disability.Id);
                dbClient.Town = Context.Towns.First(e => e.Id == client.Town.Id);
                dbClient.MartialStatus = Context.MartialStatus.First(e => e.Id == client.MartialStatus.Id);
                dbClient.Citizenship = Context.Citizenships.First(e => e.Id == client.Citizenship.Id);
                dbClient = Context.Clients.Add(dbClient);
                Context.SaveChanges();
                return Mapper.Map<ORMLibrary.Client, ClientModel>(dbClient);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Exception during client adding", ex);
            }
        }

        public IEnumerable<ClientModel> GetAll()
        {
            return Context.Clients.ToArray().Select(Mapper.Map<ORMLibrary.Client, ClientModel>);
        }

        public ClientModel Get(int id)
        {
            var client = Context.Clients.FirstOrDefault(e => e.Id == id);
            return Mapper.Map<ORMLibrary.Client, ClientModel>(client);
        }

        public void Delete(int id)
        {
            try
            {
                var client = Context.Clients.FirstOrDefault(e => e.Id == id);
                if (client != null)
                {
                    Context.Clients.Remove(client);
                    Context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new ServiceException("Exception during client deleting", ex);
            }
        }

        public void Update(ClientModel client)
        {
            try
            {
                var dbClient = Context.Clients.FirstOrDefault(e => e.Id == client.Id);
                if (dbClient == null)
                    throw new ServiceException("User not found");                
                dbClient = Mapper.Map<ClientModel, ORMLibrary.Client>(client);
                dbClient.Disability = Context.Disabilities.First(e => e.Id == client.Disability.Id);
                dbClient.Town = Context.Towns.First(e => e.Id == client.Town.Id);
                dbClient.MartialStatus = Context.MartialStatus.First(e => e.Id == client.MartialStatus.Id);
                dbClient.Citizenship = Context.Citizenships.First(e => e.Id == client.Citizenship.Id);
                Context.Entry(dbClient).State = EntityState.Modified;
            }
            catch (ServiceException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ServiceException("Exception during client updating", ex);
            }
        }
    }
}
