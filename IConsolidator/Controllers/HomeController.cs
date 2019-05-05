using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.OleDb;
using IConsolidator.Models;

namespace IConsolidator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
        
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}
