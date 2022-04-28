using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.Logic;
using DataLibrary.Models;
using TravelAgency.Models;
using static DataLibrary.Logic.OrderProcessor;
using static DataLibrary.Logic.ClientProcessor;
using static DataLibrary.Logic.DestinationProcessor;
using System.Dynamic;
using System.Data;
using System.Data.SqlClient;
using static DataLibrary.DataAccess.SqlDataAccess;
using System.Configuration;

namespace TravelAgency.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index(string searchBy, string search, int? sortOrder)
        {
            ViewBag.Message = "Orders List";

            var data = LoadFullOrders();
            List<Models.FullOrder> fullorders = new List<Models.FullOrder>();

            foreach (var row in data)
            {
                fullorders.Add(new Models.FullOrder
                {
                    order_id = row.Order_id,
                    client_fname = row.Client_fname,
                    client_lname = row.Client_lname,
                    dest_name = row.Dest_name,
                    dest_address = row.Dest_address,
                    order_from = row.Order_from,
                    order_to = row.Order_to,
                    price = row.Price,
                    order_date = row.Order_date
                });
            }

            if (search != null && search != "")
            {
                if (searchBy == "ID")
                {
                    var dataList = fullorders.FindAll(x => x.order_id == int.Parse(search));
                    return View(dataList);
                }
                if (searchBy == "FirstName")
                {
                    var dataList = fullorders.FindAll(x => x.client_fname == search);
                    return View(dataList);
                }
                if (searchBy == "LastName")
                {
                    var dataList = fullorders.FindAll(x => x.client_lname == search);
                    return View(dataList);
                }
                if (searchBy == "Destination")
                {
                    var dataList = fullorders.FindAll(x => x.dest_name == search);
                    return View(dataList);
                }
                if (searchBy == "DestinationAddress")
                {
                    var dataList = fullorders.FindAll(x => x.dest_address == search);
                    return View(dataList);
                }
                if (searchBy == "Price")
                {
                    var dataList = fullorders.FindAll(x => x.price == int.Parse(search));
                    return View(dataList);
                }
            }

            if (sortOrder == 1)
            {
                List<Models.FullOrder> ordersById = fullorders.OrderBy(FullOrder => FullOrder.order_id).ToList();
                return View(ordersById);
            }
            if (sortOrder == 2)
            {
                List<Models.FullOrder> ordersByfname = fullorders.OrderBy(FullOrder => FullOrder.client_fname).ToList();
                return View(ordersByfname);
            }
            if (sortOrder == 3)
            {
                List<Models.FullOrder> ordersBylname = fullorders.OrderBy(FullOrder => FullOrder.client_lname).ToList();
                return View(ordersBylname);
            }
            if (sortOrder == 4)
            {
                List<Models.FullOrder> ordersByDest = fullorders.OrderBy(FullOrder => FullOrder.dest_name).ToList();
                return View(ordersByDest);
            }
            if (sortOrder == 5)
            {
                List<Models.FullOrder> ordersByDestAddress = fullorders.OrderBy(FullOrder => FullOrder.dest_address).ToList();
                return View(ordersByDestAddress);
            }
            if (sortOrder == 6)
            {
                List<Models.FullOrder> ordersByOrderFrom = fullorders.OrderBy(FullOrder => FullOrder.order_from).ToList();
                return View(ordersByOrderFrom);
            }
            if (sortOrder == 7)
            {
                List<Models.FullOrder> ordersByOrderTo = fullorders.OrderBy(FullOrder => FullOrder.order_to).ToList();
                return View(ordersByOrderTo);
            }
            if (sortOrder == 8)
            {
                List<Models.FullOrder> ordersByPrice = fullorders.OrderBy(FullOrder => FullOrder.price).ToList();
                return View(ordersByPrice);
            }
            if (sortOrder == 9)
            {
                List<Models.FullOrder> ordersByOrderDate = fullorders.OrderBy(FullOrder => FullOrder.order_date).ToList();
                return View(ordersByOrderDate);
            }

            return View(fullorders);
        }

        public ActionResult AddOrder()
        {
            Order order = new Order();
            order.Clients = LoadClients();
            order.Destinations = LoadDestinations();
            List<SelectListItem> idList = new List<SelectListItem>();

            foreach (ClientModel row in order.Clients )
            {
                idList.Add(new SelectListItem()
                {
                    Value = row.Client_id.ToString(),
                    Text = row.Client_fname.ToString() +" "+ row.Client_lname.ToString()
                });
            }

            List<SelectListItem> destList = new List<SelectListItem>();

            foreach (DestinationModel row in order.Destinations)
            {
                destList.Add(new SelectListItem()
                {
                    Value = row.Dest_id.ToString(),
                    Text = row.Dest_name.ToString() +" "+ row.Dest_address.ToString()
                });
            }
            ViewBag.client_id = idList;
            ViewBag.dest_id = destList;
        
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrder(Models.Order model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateOrder(
                    model.client_id,
                    model.dest_id,
                    model.order_from,
                    model.order_to,
                    model.price);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            DeleteOrder(id);

            return RedirectToAction("Index");
        }
    }
}