using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.Configuration;
using BL.Services.Client;
using BL.Services.Client.Models;
using Ninject;
using WebApplication.Models.ViewModels;

namespace WebApplication.Infrastructure
{
    public class MapperRegistrar
    {
        [Inject]
        IClientService ClientService { get; set; }

        public void Register()
        {
            Mapper.Initialize(
                e => e.CreateMap<ClientModel, Client>()
                    .ForMember<string>(r => r.Disability, r => r.MapFrom(t => t.Disability.Status))
                    .ForMember<string>(r => r.Citizenship, r => r.MapFrom(t => t.Citizenship.Country))
                    .ForMember<string>(r => r.MaritalStatus, r => r.MapFrom(t => t.MartialStatus.Status))
                    .ForMember<string>(r => r.ResidenceActualPlace, r => r.MapFrom(t => t.Town.Name))
                    .ForMember<IEnumerable<string>>(r => r.DisabilityStatuses,
                        r => r.MapFrom(t => ClientService.GetDisabilities().Select(y => y.Status)))
                    .ForMember<IEnumerable<string>>(r => r.Citizenships,
                        r => r.MapFrom(t => ClientService.GetCitizenships().Select(y => y.Country)))
                    .ForMember<IEnumerable<string>>(r => r.Towns,
                        r => r.MapFrom(t => ClientService.GetTowns().Select(y => y.Name)))
                    .ForMember<IEnumerable<string>>(r => r.MartialStatuses,
                        r => r.MapFrom(t => ClientService.GetMaritalStatuses().Select(y => y.Status))));

            Mapper.Initialize(
                e => e.CreateMap<Client, ClientModel>()
                    .ForMember(r => r.Disability,
                        r =>
                            r.MapFrom(
                                t => ClientService.GetDisabilities().FirstOrDefault(y => y.Status == t.Disability)))
                    .ForMember(r => r.Town,
                        r =>
                            r.MapFrom(
                                t => ClientService.GetTowns().FirstOrDefault(y => y.Name == t.ResidenceActualPlace)))
                    .ForMember(r => r.Citizenship,
                        r =>
                            r.MapFrom(
                                t => ClientService.GetCitizenships().FirstOrDefault(y => y.Country == t.Citizenship)))
                    .ForMember(r => r.Disability,
                        r =>
                            r.MapFrom(
                                t => ClientService.GetMaritalStatuses().FirstOrDefault(y => y.Status == t.MaritalStatus))));

            Mapper.Initialize(
                e => e.CreateMap<Client, Client>().ForMember<IEnumerable<string>>(r => r.DisabilityStatuses,
                        r => r.MapFrom(t => ClientService.GetDisabilities().Select(y => y.Status)))
                    .ForMember<IEnumerable<string>>(r => r.Citizenships,
                        r => r.MapFrom(t => ClientService.GetCitizenships().Select(y => y.Country)))
                    .ForMember<IEnumerable<string>>(r => r.Towns,
                        r => r.MapFrom(t => ClientService.GetTowns().Select(y => y.Name)))
                    .ForMember<IEnumerable<string>>(r => r.MartialStatuses,
                        r => r.MapFrom(t => ClientService.GetMaritalStatuses().Select(y => y.Status))));
        }
    }
}