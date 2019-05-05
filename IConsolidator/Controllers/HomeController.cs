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
    [DataContract]
    class DBConfig
    {
        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Path { get; set; }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            StreamReader r = new StreamReader(Server.MapPath("~/Views/config.json"));
            string json = r.ReadToEnd();
            List<DBConfig> items = JsonConvert.DeserializeObject<List<DBConfig>>(json);

            List<string> sources = new List<string>();
            foreach (var item in items)
            {
                sources.Add(item.Title);
            }

            ViewBag.Sources = sources;
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
