using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BL.Services.Deposit;
using BL.Services.Deposit.Models;
using Ninject;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class DepositController : Controller
    {
        [Inject]
        public IDepositService DepositService { get; set; }

        public ActionResult Index()
        {
            var deposits = DepositService.GetAll();
            return View(deposits.Select(Mapper.Map<DepositModel, Deposit>));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Deposit());
        }

        [HttpPost]
        public ActionResult Create(Deposit deposit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DepositService.Create(Mapper.Map<Deposit, DepositModel>(deposit));
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(deposit);
                }
            }
            return View(deposit);
        }

        [HttpGet]
        public ActionResult Details(int depositId)
        {
            var deposit = DepositService.Get(depositId);
            return View(Mapper.Map<DepositModel, Deposit>(deposit));
        }

        [HttpPost]
        public ActionResult PayPercents(int depositId)
        {
            DepositService.WithdrawPercents(depositId);
            return RedirectToAction("Details", new { depositId = depositId });
        }

        [HttpPost]
        public ActionResult WithDrawDeposit(int depositId)
        {
            DepositService.CloseDeposit(depositId);
            return RedirectToAction("Details", new {depositId = depositId});
        }
    }
}