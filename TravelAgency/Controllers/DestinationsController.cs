using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.Logic;
using DataLibrary.Models;
using TravelAgency.Models;
using static DataLibrary.Logic.DestinationProcessor;

namespace TravelAgency.Controllers
{
    public class DestinationsController : Controller
    {
        // GET: Destinations
        public ActionResult Index(string searchBy, string search, int? sortOrder)
        {
            ViewBag.Message = "Destinations List";

            var data = LoadDestinations();
            List<Models.Destination> destinations = new List<Models.Destination>();

            foreach (var row in data)
            {
                destinations.Add(new Models.Destination
                {
                    dest_id = row.Dest_id,
                    dest_name = row.Dest_name,
                    dest_phone = row.Dest_phone,
                    dest_address = row.Dest_address
                });
            }

            if (search != null && search != "")
            {
                if (searchBy == "ID")
                {
                    var dataList = destinations.FindAll(x => x.dest_id == int.Parse(search));
                    return View(dataList);
                }
                if (searchBy == "Destination")
                {
                    var dataList = destinations.FindAll(x => x.dest_name == search);
                    return View(dataList);
                }
                if (searchBy == "Phone")
                {
                    var dataList = destinations.FindAll(x => x.dest_phone == search);
                    return View(dataList);
                }
                if (searchBy == "Address")
                {
                    var dataList = destinations.FindAll(x => x.dest_address == search);
                    return View(dataList);
                }
            }

            if (sortOrder == 1)
            {
                List<Models.Destination> destById = destinations.OrderBy(Destination => Destination.dest_id).ToList();
                return View(destById);

            }
            if (sortOrder == 2)
            {
                List<Models.Destination> destByName = destinations.OrderBy(Destination => Destination.dest_name).ToList();
                return View(destByName);

            }
            if (sortOrder == 3)
            {
                List<Models.Destination> destByPhone = destinations.OrderBy(Destination => Destination.dest_phone).ToList();
                return View(destByPhone);

            }
            if (sortOrder == 4)
            {
                List<Models.Destination> destByAddress = destinations.OrderBy(Destination => Destination.dest_address).ToList();
                return View(destByAddress);

            }

            return View(destinations);
        }

        // Destinations/AddDestination
        public ActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDestination(Models.Destination model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateDestination(
                    model.dest_name,
                    model.dest_phone,
                    model.dest_address);
                return RedirectToAction("Index");
            }
            return View();
        }


        // Destinations/Edit/1
        public ActionResult Edit(int id)
        {
            var data = LoadDestinations(id);
            List<Models.Destination> destinations = new List<Models.Destination>();

            foreach (var row in data)
            {
                destinations.Add(new Models.Destination
                {
                    dest_id = row.Dest_id,
                    dest_name = row.Dest_name,
                    dest_phone = row.Dest_phone,
                    dest_address = row.Dest_address
                });
            }
            Destination destination = new Destination();
            destination = destinations.First();

            return View(destination);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Destination model)
        {
            if (model == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            if (ModelState.IsValid)
            {
                int recordsCreated = UpdateDestination(
                    model.dest_id,
                    model.dest_name,
                    model.dest_phone,
                    model.dest_address);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            DeleteDestination(id);

            return RedirectToAction("Index");
        }
    }
}