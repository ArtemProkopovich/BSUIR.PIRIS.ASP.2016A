using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using WebApplication.Infrastructure;

namespace WebApplication.Controllers
{
    public class AtmController : Controller
    {
        public IMapper Mapper { get; set; } = MappingRegistrar.CreareMapper();
        // GET: Atm
        public ActionResult Index()
        {
            return View();
        }
    }
}