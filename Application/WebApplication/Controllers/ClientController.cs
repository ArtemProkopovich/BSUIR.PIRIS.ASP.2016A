using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using WebApplication.Models.ViewModels;
using BL.Services.Client;
using BL.Services.Client.Models;
using Microsoft.Practices.Unity;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace WebApplication.Controllers
{
    public class ClientController : Controller
    {
        [Dependency]
        public IClientService ClientService { get; set; }
        

        // GET: Client
        public ActionResult Index()
        {
            var clients = ClientService.GetAll();
            return View(clients.Select(Mapper.Map<ClientModel, Client>));
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            var client = ClientService.Get(id);
            return View(Mapper.Map<ClientModel, Client>(client));
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View(Mapper.Map<Client, Client>(new Client()));
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
                    var model = ClientService.Add(Mapper.Map<Client, ClientModel>(client));
                    return RedirectToAction("Details", new {id = model.Id});
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(Mapper.Map<Client, Client>(client));
                }
                catch (Exception ex)
                {
                    return View("Error");
                }
            }
            return View(Mapper.Map<Client, Client>(client));
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            var client = ClientService.Get(id);
            return View(Mapper.Map<ClientModel, Client>(client));
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
                    ClientService.Update(Mapper.Map<Client, ClientModel>(client));
                    return RedirectToAction("Details", new {id = client.Id});
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(Mapper.Map<Client, Client>(client));
                }
                catch(Exception ex)
                {
                    return View("Error");
                }
            }
            return View(Mapper.Map<Client, Client>(client));
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            var client = ClientService.Get(id);
            return View(Mapper.Map<ClientModel, Client>(client));
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
                ClientService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
