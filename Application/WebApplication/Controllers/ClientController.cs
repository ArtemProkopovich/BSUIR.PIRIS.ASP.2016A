using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Infrastructure.Repository;
using WebApplication.Models.DataModels;
using WebApplication.Models.ViewModels;

namespace WebApplication.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientData repository;

        public ClientController()
        {
            this.repository = new ClientData(Resolver.GetService<IClientService>());
        }
        // GET: Client
        public ActionResult Index()
        {
            var clients = repository.GetAll(); 
            return View(clients);
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            var client = repository.Get(id);
            return View(client);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View(repository.GetLists(new Client()));
        }

        // POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int id = repository.Create(client);
                    return RedirectToAction("Details", new {id = id});
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(repository.GetLists(client));
                }
                catch (Exception ex)
                {
                    return View("Error");
                }
            }
            return View(repository.GetLists(client));
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            var client = repository.Get(id);
            client = repository.GetLists(client);
            return View(client);
        }

        // POST: Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Update(client);
                    return RedirectToAction("Details", new {id = client.Id});
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(repository.GetLists(client));
                }
                catch(Exception ex)
                {
                    return View("Error");
                }
            }
            return View(repository.GetLists(client));
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            var client = repository.Get(id);
            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            try
            {
                // TODO: Add delete logic here
                repository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
