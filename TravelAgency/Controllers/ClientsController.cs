using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.Logic;
using DataLibrary.Models;
using TravelAgency.Models;
using static DataLibrary.Logic.ClientProcessor;

namespace TravelAgency.Controllers
{
    public class ClientsController : Controller
    {
        public ActionResult Index(Models.Client model, string searchBy, string search, int? sortOrder)
        {
            ViewBag.Message = "Clients List";

            var data = LoadClients();
            List<Models.Client> clients = new List<Models.Client>();

            foreach (var row in data)
            {
                clients.Add(new Models.Client
                {
                    client_id = row.Client_id,
                    client_fname = row.Client_fname,
                    client_lname = row.Client_lname,
                    client_phone = row.Client_phone,
                    client_address = row.Client_address
                });
            }
            if(search != null && search != "" && search != "*")
            {
                if (searchBy == "ID")
                {
                    var dataList = clients.FindAll(x => x.client_id == int.Parse(search));
                    return View(dataList);
                }
                if (searchBy == "Name")
                {
                    var dataList = clients.FindAll(x => x.client_fname == search);
                    return View(dataList);
                }
                if (searchBy == "LastName")
                {
                    var dataList = clients.FindAll(x => x.client_lname == search);
                    return View(dataList);
                }
                if (searchBy == "Phone")
                {
                    var dataList = clients.FindAll(x => x.client_phone == search);
                    return View(dataList);
                }
                if (searchBy == "Address")
                {
                    var dataList = clients.FindAll(x => x.client_address == search);
                    return View(dataList);
                }
            }

            if (sortOrder == 1)
            {
                List<Models.Client> clientsById = clients.OrderBy(Client => Client.client_id).ToList();
                return View(clientsById);

            }
            if (sortOrder == 2)
            {
                List<Models.Client> clientsByfname = clients.OrderBy(Client => Client.client_fname).ToList();
                return View(clientsByfname);

            }
            if (sortOrder == 3)
            {
                List<Models.Client> clientsBylname = clients.OrderBy(Client => Client.client_lname).ToList();
                return View(clientsBylname);

            }
            if (sortOrder == 4)
            {
                List<Models.Client> clientsByPhone = clients.OrderBy(Client => Client.client_phone).ToList();
                return View(clientsByPhone);

            }
            if (sortOrder == 5)
            {
                List<Models.Client> clientsByAddress = clients.OrderBy(Client => Client.client_address).ToList();
                return View(clientsByAddress);

            }

            return View(clients);
        }

        // Clients/AddClient
        public ActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddClient(Models.Client model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateClient(
                    model.client_fname,
                    model.client_lname,
                    model.client_phone,
                    model.client_address);
                return RedirectToAction("Index");
            }
            return View();
        }


        // Clients/Edit/1
        public ActionResult Edit(int id)
        {
            var data = LoadClients(id);
            List<Models.Client> clients = new List<Models.Client>();

            foreach (var row in data)
            {
                clients.Add(new Models.Client
                {
                    client_id = row.Client_id,
                    client_fname = row.Client_fname,
                    client_lname = row.Client_lname,
                    client_phone = row.Client_phone,
                    client_address = row.Client_address
                });
            }
            Client client = new Client();
            client = clients.First();

            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Client model)
        {
            if (model == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            if (ModelState.IsValid)
            {
                int recordsCreated = UpdateClient(
                    model.client_id,
                    model.client_fname,
                    model.client_lname,
                    model.client_phone,
                    model.client_address);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            DeleteClient(id);

            return RedirectToAction("Index");
        }

    }
}