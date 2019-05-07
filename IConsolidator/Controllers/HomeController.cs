using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.OleDb;
using IConsolidator.Models;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Diagnostics;
using Newtonsoft.Json;

namespace IConsolidator.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            StreamReader r = new StreamReader(Server.MapPath("~/Views/config.json"));
            string json = r.ReadToEnd();
            List<DBConfig> items = JsonConvert.DeserializeObject<List<DBConfig>>(json);

            ViewBag.Title = "Home Page";
            return View(items);
        }
    }
}
