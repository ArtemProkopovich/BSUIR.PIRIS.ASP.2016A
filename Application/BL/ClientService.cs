using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.Interface;
using DAL.Interface;
using DAL.Interface.Entity;
using Client = BL.Interface.Entity.Client;
using DalClient = DAL.Interface.Entity.Client;

namespace BL
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork uof;

        public ClientService(IUnitOfWork uof)
        {
            this.uof = uof;
        }

        public int Add(Client entity)
        {
            ValidateClient(entity);
            return uof.Clients.Add(MapClientToDalClient(entity));
        }

        public bool Delete(int id)
        {
            return uof.Clients.Delete(id);
        }

        public Client Get(int id)
        {
            return MapDalClientToClient(uof.Clients.Get(id));
        }

        public IEnumerable<Client> GetAll()
        {
            return uof.Clients.GetAll().Select(MapDalClientToClient);
        }

        public void Update(Client entity)
        {
            uof.Clients.Update(MapClientToDalClient(entity));
        }

        protected virtual bool ValidateClient(Client entity)
        {
            var clients = uof.Clients.GetAll().ToList();
            clients.RemoveAll(e => e.Id == entity.Id);
            if (clients.Any(
                e => e.Surname == entity.Surname && e.Name == entity.Name && e.FatherName == entity.FatherName))
                throw new ValidationException("Cannot be two clients with same names.");
            if (clients.Any(e => e.PassportNumber == entity.PassportNumber && e.PassportSeries == entity.PassportSeries))
                throw new ValidationException("Cannot be two clients with same passport data");
            if (clients.Any(e => e.IdentificationNumber == entity.IdentificationNumber))
                throw new ValidationException("Cannot be two clients with same identification numbers");
            return true;
        }

        protected DalClient MapClientToDalClient(Client client)
        {
            int rapId = uof.Towns.GetAll().FirstOrDefault(e => e.Name == client.ResidenceActualPlace)?.Id ??
                        uof.Towns.Add(new Town() {Name = client.ResidenceActualPlace});
            int cityId = uof.Citizenships.GetAll().FirstOrDefault(e => e.Country == client.Citizenship)?.Id ??
                        uof.Citizenships.Add(new Citizenship() { Country = client.Citizenship });
            int disId = uof.DisabilityStatuses.GetAll().FirstOrDefault(e => e.Status == client.Disability)?.Id ??
                        uof.DisabilityStatuses.Add(new Disability() { Status = client.Disability });
            int msId = uof.MartialStatuses.GetAll().FirstOrDefault(e => e.Status == client.MaritalStatus)?.Id ??
                       uof.MartialStatuses.Add(new MartialStatus() {Status = client.MaritalStatus});
            var config =
                new MapperConfiguration(cfg =>
                    cfg.CreateMap<Client, DalClient>()
                        .ForMember<int>(e => e.ResidenceActualPlaceId,
                            e => e.MapFrom(x => rapId))
                        .ForMember<int>(e => e.CitizenshipId,
                            e => e.MapFrom(x => cityId))
                        .ForMember<int>(e => e.DisabilityId,
                            e => e.MapFrom(x => disId))
                        .ForMember<int>(e => e.MaritalStatusId,
                            e => e.MapFrom(x => msId)));
            return config.CreateMapper().Map<Client, DalClient>(client);
        }

        protected Client MapDalClientToClient(DalClient dalClient)
        {
            var config =
                new MapperConfiguration(cfg =>
                    cfg.CreateMap<DalClient, Client>()
                        .ForMember<string>(e => e.ResidenceActualPlace,
                            e => e.MapFrom(r => uof.Towns.Get(r.ResidenceActualPlaceId).Name))
                        .ForMember<string>(e => e.Citizenship,
                            e => e.MapFrom(r => uof.Citizenships.Get(r.CitizenshipId).Country))
                        .ForMember<string>(e => e.Disability,
                            e => e.MapFrom(r => uof.DisabilityStatuses.Get(r.DisabilityId).Status))
                        .ForMember<string>(e => e.MaritalStatus,
                            e => e.MapFrom(r => uof.MartialStatuses.Get(r.MaritalStatusId).Status)));
            return config.CreateMapper().Map<DalClient, Client>(dalClient);
        }

        public IEnumerable<string> GetTowns()
        {
            return uof.Towns.GetAll().Select(e => e.Name);
        }

        public IEnumerable<string> GetCitizenships()
        {
            return uof.Citizenships.GetAll().Select(e => e.Country);
        }

        public IEnumerable<string> GetMartialStatuses()
        {
            return uof.MartialStatuses.GetAll().Select(e => e.Status);
        }

        public IEnumerable<string> GetDisabilityStatuses()
        {
            return uof.DisabilityStatuses.GetAll().Select(e => e.Status);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    uof.Dispose();
                }
                disposedValue = true;
            }
        }

        ~ClientService()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
