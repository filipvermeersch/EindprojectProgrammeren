using Projectwerk.Vermeersch.f.Data;
using Projectwerk.Vermeersch.f.Models;
using Projectwerk.Vermeersch.f.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projectwerk.Vermeersch.f.Controllers
{
    public class WedstrijdenController : Controller
    {
        private TriatlonContext db = new TriatlonContext();

        // GET: Wedstrijden
        public ActionResult Index(int Id)
        {
            var putter = db.Putters.Include("Wedstrijden").Include("Resultaten").FirstOrDefault(p => p.Id == Id);
            var wedstrijdlijst = putter.Wedstrijden;
            var resultaten = putter.Resultaten;

            var wedstrijden = new List<WedstrijdViewModel>();
            foreach ( var wedstrijd in putter.Wedstrijden )
            {
                WedstrijdViewModel WVM = new WedstrijdViewModel();
                WVM.PutterId = Id;
                WVM.Putternaam = putter.VolledigeNaam;
                WVM.Plaats = wedstrijd.Plaats;
                WVM.Datum = wedstrijd.Datum;
                WVM.Afstand = wedstrijd.Afstand.Lengte;
                WVM.Sport = wedstrijd.Sport.soortSport;
                wedstrijden.Add(WVM);
            }

            return View(wedstrijden);
        }
        // public JsonResult test(int Id)
        //{
        //    var testje = new List<Test>() { new Test { id = 1, testnaam = "vermeersch", testvoornaam = "fluppe" },
        //        new Test { id = 2, testnaam = "hendrickx", testvoornaam = "sven" } };
        //    return Json(testje, JsonRequestBehavior.AllowGet);

        //}

        public ActionResult test(int Id)
        {
            var testje = new List<Test>() { new Test { id = 1, testnaam = "vermeersch", testvoornaam = "fluppe" },
                         new Test { id = 2, testnaam = "hendrickx", testvoornaam = "sven" } };
            //var testje = new Test { id = 1, testnaam = "vermeersch", testvoornaam = "fluppe" };
            return View(testje);

        }
    }
}