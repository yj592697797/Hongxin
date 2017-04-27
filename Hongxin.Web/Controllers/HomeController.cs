using Hongxin.Core;
using Hongxin.Model;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hongxin.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //var path = Server.MapPath("/db/hongxin.db");
            //var basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            //string connectionString = "Data Source=" + path;
            //var provider = "System.Data.SQLite";
            //var db = new Database(connectionString, provider);
            //var db = DBHelper.CreateDB();
            //var sql = "select * from [order]";
            //var orders = db.Query<OrderRecord>(sql);
            //ViewBag.Data = orders.First().ToString();
            return View();
        }

    }
}
