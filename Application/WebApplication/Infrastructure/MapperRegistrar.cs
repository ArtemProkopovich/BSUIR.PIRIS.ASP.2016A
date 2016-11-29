using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BL.Services.Client;
using BL.Services.Client.Models;
using BL.Services.Credit;
using BL.Services.Credit.Models;
using BL.Services.Deposit;
using BL.Services.Deposit.Models;
using BL.Services.Transaction.Models;
using Microsoft.Practices.Unity;
using WebApplication.Models.ViewModels;

namespace WebApplication.Infrastructure
{
    public class MapperRegistrar
    {
        [Dependency]
        IClientService ClientService { get; set; }

        [Dependency]
        IDepositService DepositService { get; set; }

        [Dependency]
        ICreditService CreditService { get; set; }

        [Dependency]
        IPlanOfCreditService PlanOfCreditService { get; set; }

        [Dependency]
        IPlanOfDepositService PlanOfDepositService { get; set; }

        public void Register()
        {
            #region ClientMapper

            Mapper.Initialize(
                e => e.CreateMap<ClientModel, Client>()
                    .ForMember(r => r.Disability, r => r.MapFrom(t => t.Disability.Status))
                    .ForMember(r => r.Citizenship, r => r.MapFrom(t => t.Citizenship.Country))
                    .ForMember(r => r.MaritalStatus, r => r.MapFrom(t => t.MartialStatus.Status))
                    .ForMember(r => r.ResidenceActualPlace, r => r.MapFrom(t => t.Town.Name))
                    .ForMember(r => r.DisabilityStatuses,
                        r => r.MapFrom(t => ClientService.GetDisabilities().Select(y => y.Status)))
                    .ForMember(r => r.Citizenships,
                        r => r.MapFrom(t => ClientService.GetCitizenships().Select(y => y.Country)))
                    .ForMember(r => r.Towns,
                        r => r.MapFrom(t => ClientService.GetTowns().Select(y => y.Name)))
                    .ForMember(r => r.MartialStatuses,
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
                e => e.CreateMap<Client, Client>().ForMember(r => r.DisabilityStatuses,
                        r => r.MapFrom(t => ClientService.GetDisabilities().Select(y => y.Status)))
                    .ForMember(r => r.Citizenships,
                        r => r.MapFrom(t => ClientService.GetCitizenships().Select(y => y.Country)))
                    .ForMember(r => r.Towns,
                        r => r.MapFrom(t => ClientService.GetTowns().Select(y => y.Name)))
                    .ForMember(r => r.MartialStatuses,
                        r => r.MapFrom(t => ClientService.GetMaritalStatuses().Select(y => y.Status))));

            #endregion

            #region PlanOfDepositMapper
            Mapper.Initialize(e => e.CreateMap<PlanOfDepositModel, DepositModel>());
            Mapper.Initialize(e => e.CreateMap<DepositModel, PlanOfDepositModel>());
            
            #endregion

            #region DepositMapper

            Mapper.Initialize(e => e.CreateMap<DepositModel, Deposit>());
            Mapper.Initialize(e => e.CreateMap<Deposit, DepositModel>());
            Mapper.Initialize(
                e => e.CreateMap<DepositModel, CreateDepositModel>()
                        .ForMember(t => t.DepositPlans, t => t.MapFrom(
                            r => PlanOfDepositService.GetAll().Select(Mapper.Map<PlanOfDepositModel, PlanOfDeposit>))));

            #endregion

            #region PlanOfCreditMapper

            Mapper.Initialize(e => e.CreateMap<PlanOfCreditModel, CreditModel>());
            Mapper.Initialize(e => e.CreateMap<CreditModel, PlanOfCreditModel>());

            #endregion

            #region CreditMapper

            Mapper.Initialize(e => e.CreateMap<CreditModel, Credit>());
            Mapper.Initialize(e => e.CreateMap<Credit, CreditModel>());
            Mapper.Initialize(
                e => e.CreateMap<CreditModel, CreateCreditModel>()
                        .ForMember(t => t.CreditPlans, t => t.MapFrom(
                            r => PlanOfCreditService.GetAll().Select(Mapper.Map<PlanOfCreditModel, PlanOfCredit>))));
            #endregion

            #region TransactionMapper

            #endregion
        }
    }
}