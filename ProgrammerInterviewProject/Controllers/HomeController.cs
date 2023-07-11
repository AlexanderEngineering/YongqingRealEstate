using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgrammerInterviewProject.Models;

namespace ProgrammerInterviewProject.Controllers
{
    public class HomeController : Controller
    {
        Entity entity = new Entity();
        public ActionResult Index()
        {
            entity.GetData();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}