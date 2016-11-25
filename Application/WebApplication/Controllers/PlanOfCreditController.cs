using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BL.Services.Credit;
using BL.Services.Credit.Models;
using Ninject;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class PlanOfCreditController : Controller
    {
        [Inject]
        public IPlanOfCreditService PlanService { get; set; }

        public ActionResult Index()
        {
            var plans = PlanService.GetAll();
            return View(plans.Select(Mapper.Map<PlanOfCreditModel, PlanOfCredit>));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new PlanOfCredit());
        }

        [HttpPost]
        public ActionResult Create(PlanOfCredit plan)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    PlanService.Create(Mapper.Map<PlanOfCredit, PlanOfCreditModel>(plan));
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(plan);
                }
            }
            return View(plan);
        }
    }
}