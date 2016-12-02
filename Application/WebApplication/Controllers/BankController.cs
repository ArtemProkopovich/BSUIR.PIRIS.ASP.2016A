using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BL.Services.Common;
using BL.Services.Transaction;
using Microsoft.Practices.Unity;
using WebApplication.Infrastructure;

namespace WebApplication.Controllers
{
    public class BankController : Controller
    {
        [Dependency]
        public IBankService BankService { get; set; }

        [Dependency]
        public ITransactionService TransactionService { get; set; }

        [Dependency]
        public ICommonService CommonService { get; set; }

        public IMapper Mapper { get; set; } = MappingRegistrar.CreareMapper();

        public ActionResult CloseBankDay(string returnUrl)
        {
            BankService.CloseBankDay();
            return new RedirectResult(returnUrl);
        }

        public ActionResult CloseBankMonth(string returnUrl)
        {
            BankService.CloseBankMonth();
            return new RedirectResult(returnUrl);
        }

        public ActionResult CloseBankYear(string returnUrl)
        {
            BankService.CloseBankYear();
            return new RedirectResult(returnUrl);
        }

        public ActionResult DayTransactionsReport()
        {
            var transactions = TransactionService.GetAllByDay(CommonService.CurrentBankDay);
            return View("Report", transactions);
        }

        public ActionResult AllTransactionsReport()
        {
            var transactions = TransactionService.GetAll();
            return View("Report", transactions);
        }
    }
}