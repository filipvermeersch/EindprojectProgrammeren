using Projectwerk.Vermeersch.f.Data;
using Projectwerk.Vermeersch.f.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projectwerk.Vermeersch.f.Controllers
{
    public class HomeController : Controller
    {
        private TriatlonContext db = new TriatlonContext();

        public ActionResult Index()
        {
            List<Sport> sportlijst = db.Sporten.ToList();
            return View(sportlijst);
        }

        public ActionResult Leden()
        {
            var putterslijst = db.Putters.ToList();
            return View(putterslijst);
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}