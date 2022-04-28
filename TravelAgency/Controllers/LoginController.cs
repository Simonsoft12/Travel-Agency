using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary.Models;
using static DataLibrary.DataAccess.SqlDataAccess;
using System.Configuration;
using System.Web.Routing;

namespace TravelAgency.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
            IDbConnection cnn = new SqlConnection(GetConnectionString());
            SqlCommand com = new SqlCommand();
            SqlDataReader dr;

            cnn.Open();
            com.Connection = (SqlConnection)cnn;
            com.CommandText = @"Select * from dbo.Login Where username ='" + login.Username +
                "'AND password='" + login.Password + "';";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                cnn.Close();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                cnn.Close();
                ViewBag.Message = "Bad login or password.";
                return View();
            }
        }
    }
}
