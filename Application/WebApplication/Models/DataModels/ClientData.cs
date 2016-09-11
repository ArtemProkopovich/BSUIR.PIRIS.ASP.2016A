using System;
using System.Collections.Generic;
using System.Linq;
using BL.Interface;
using WebApplication.Infrastructure.Repository;
using AutoMapper;
using Client = WebApplication.Models.ViewModels.Client;
using BlClient = BL.Interface.Entity.Client;
namespace WebApplication.Models.DataModels
{
    public class ClientData : IMvcRepository<Client>
    {
        private readonly IClientService service;

        public ClientData(IClientService service)
        {
            this.service = service;
        }

        public int Create(Client entity)
        {
            return service.Add(ClientToBlClient(entity));
        }

        public bool Delete(int id)
        {
            return service.Delete(id);
        }

        public Client GetLists(Client client)
        {
            client.Towns = service.GetTowns();
            client.Citizenships = service.GetCitizenships();
            client.DisabilityStatuses = service.GetDisabilityStatuses();
            client.MartialStatuses = service.GetMartialStatuses();
            return client;
        }

        public Client Get(int id)
        {
            return BlClientToClient(service.Get(id));
        }

        public void Update(Client entity)
        {
            service.Update(ClientToBlClient(entity));
        }
        public IEnumerable<Client> GetAll()
        {
            return service.GetAll().Select(BlClientToClient);
        }

        public static BlClient ClientToBlClient(Client client)
        {
            Mapper.Initialize(config => config.CreateMap<Client, BlClient>());
            return Mapper.Map<BlClient>(client);
        }

        public static Client BlClientToClient(BlClient blClient)
        {
            Mapper.Initialize(config => config.CreateMap<BlClient, Client>());
            return Mapper.Map<Client>(blClient);
        }

        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    service.Dispose();
                }
                disposedValue = true;
            }
        }

         ~ClientData()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}