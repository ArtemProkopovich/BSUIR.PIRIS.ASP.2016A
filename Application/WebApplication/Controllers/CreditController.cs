using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BL.Services.Credit;
using BL.Services.Credit.Models;
using Ninject;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class CreditController : Controller
    {
        [Inject]
        public ICreditService CreditService { get; set; }

        public ActionResult Index()
        {
            var Credits = CreditService.GetAll();
            return View(Credits.Select(Mapper.Map<CreditModel, Credit>));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Credit());
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
                    return View(credit);
                }
            }
            return View(credit);
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
            
        }


        [HttpPost]
        public ActionResult PayPercents(int creditId)
        {
            CreditService.PayPercents(creditId);
            return RedirectToAction("Details", new { CreditId = creditId });
        }

        [HttpPost]
        public ActionResult WithDrawCredit(int creditId)
        {
            CreditService.CloseCredit(creditId);
            return RedirectToAction("Details", new { CreditId = creditId });
        }
    }
}