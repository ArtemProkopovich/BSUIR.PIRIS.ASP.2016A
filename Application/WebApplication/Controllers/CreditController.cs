using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BL.Services.Credit;
using BL.Services.Credit.Models;
using Microsoft.Practices.Unity;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class CreditController : Controller
    {
        [Dependency]
        public ICreditService CreditService { get; set; }

        public ActionResult Index()
        {
            var credits = CreditService.GetAll();
            return View(credits.Select(Mapper.Map<CreditModel, Credit>));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Credit credit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CreditService.Create(Mapper.Map<Credit, CreditModel>(credit));
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(Mapper.Map<Credit, CreateCreditModel>(credit));
                }
            }
            return View(Mapper.Map<Credit, CreateCreditModel>(credit));
        }

        [HttpGet]
        public ActionResult Details(int creditId)
        {
            var credit = CreditService.Get(creditId);
            return View(Mapper.Map<CreditModel, Credit>(credit));
        }

        [HttpGet]
        public ActionResult PaymentSchedule(int creditId)
        {
            var schedule = CreditService.GetPaymentSchedule(creditId);
            return View("Schedule", Mapper.Map<PlanOfPaymentModel, PlanOfPayment>(schedule));
        }


        [HttpPost]
        public ActionResult PayPercents(int creditId)
        {
            CreditService.PayPercents(creditId);
            return RedirectToAction("Details", new { CreditId = creditId });
        }

        [HttpPost]
        public ActionResult CloseCredit(int creditId)
        {
            CreditService.CloseCredit(creditId);
            return RedirectToAction("Details", new { CreditId = creditId });
        }
    }
}