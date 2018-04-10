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
            foreach (var wedstrijd in putter.Wedstrijden)
            {
                WedstrijdViewModel WVM = new WedstrijdViewModel();
                WVM.PutterId = Id;
                WVM.Id = wedstrijd.Id;
                WVM.Putternaam = putter.VolledigeNaam;
                WVM.Plaats = wedstrijd.Plaats;
                WVM.Datum = wedstrijd.Datum ?? DateTime.Now;
                WVM.Afstand = wedstrijd.Afstand.Lengte;
                WVM.Sport = wedstrijd.Sport.soortSport;
                WVM.Stayer = wedstrijd.Stayer;
                if (wedstrijd.Resultaten.Any( r => r.PutterID == Id))
                {
                    WVM.Result = true;
                }
                wedstrijden.Add(WVM);
            }

            return View(wedstrijden);
        }

        [HttpGet]
        public ActionResult AddWedstrijd(int id)
        {
            WedstrijdViewModel WVM = new WedstrijdViewModel();
            WVM.PutterId = id;
        //    WVM.Datum = DateTime.Now;

            ViewBag.Afstand = new SelectList(db.Afstanden, "Id", "Lengte");
            ViewBag.Sport = new SelectList(db.Sporten, "Id", "soortSport");

            var plaatsen = from wedstrijd in db.Wedstrijden
                           orderby wedstrijd.Plaats
                           select wedstrijd.Plaats;
            var locaties = plaatsen.Distinct();

            var selectlistLocaties = locaties.Select
                (x => new SelectListItem() { Value = x, Text = x }).ToList();
            //ViewBag.Plaats = new SelectList(selectlistLocaties ,"Value","Text");
            ViewBag.Plaats = selectlistLocaties;

            return PartialView("_AddWedstrijd", WVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddWedstrijd(WedstrijdViewModel WVM)
        {
            if (ModelState.IsValid)
            {
                var wedstrijd = new Wedstrijd();
                wedstrijd.Datum = WVM.Datum;
                wedstrijd.Plaats = WVM.Plaats;
                wedstrijd.Stayer = WVM.Stayer;
                wedstrijd.AfstandId = int.Parse(WVM.Afstand);
                wedstrijd.SportId = int.Parse(WVM.Sport);

                var putter = db.Putters.FirstOrDefault(p => p.Id == WVM.PutterId);

                var wed = db.Wedstrijden.Include("Deelnemers").FirstOrDefault(w => w.Datum == wedstrijd.Datum && w.Plaats == wedstrijd.Plaats
                    && w.SportId == wedstrijd.SportId && w.AfstandId == wedstrijd.AfstandId && w.Stayer == wedstrijd.Stayer);

                if (wed == null)
                {
                    db.Wedstrijden.Add(wedstrijd);
                    putter.Wedstrijden.Add(wedstrijd);
                }
                else
                {
                    putter.Wedstrijden.Add(wed);

                }

                db.SaveChanges();

                return RedirectToAction("Index", "Wedstrijden", new { Id = WVM.PutterId });

            }
            else
            {
                ViewBag.Afstand = new SelectList(db.Afstanden, "Id", "Lengte");
                ViewBag.Sport = new SelectList(db.Sporten, "Id", "soortSport");

                var plaatsen = from wedstrijd in db.Wedstrijden
                               orderby wedstrijd.Plaats
                               select wedstrijd.Plaats;
                var locaties = plaatsen.Distinct();

                var selectlistLocaties = locaties.Select
                    (x => new SelectListItem() { Value = x, Text = x }).ToList();
                //ViewBag.Plaats = new SelectList(selectlistLocaties ,"Value","Text");
                ViewBag.Plaats = selectlistLocaties;


                return PartialView("_AddWedstrijd", WVM);

            }
        }
        // public JsonResult test(int Id)
        //{
        //    var testje = new List<Test>() { new Test { id = 1, testnaam = "vermeersch", testvoornaam = "fluppe" },
        //        new Test { id = 2, testnaam = "hendrickx", testvoornaam = "sven" } };
        //    return Json(testje, JsonRequestBehavior.AllowGet);

        //}

        public string Verwijder(string PutterId, string Id)
        {
            int nummer = Convert.ToInt32(PutterId);
            int wedstrijdNummer = Convert.ToInt32(Id);
            var wedstrijd = db.Wedstrijden.FirstOrDefault(w => w.Id == wedstrijdNummer);
            var putter = db.Putters.FirstOrDefault(p => p.Id == nummer);
            if (wedstrijd.Deelnemers.Count>1)
            {
                putter.Wedstrijden.Remove(wedstrijd);

            }
            else
            {
                db.Wedstrijden.Remove(wedstrijd);
            }
            db.SaveChanges();
            return "Wedstrijd verwijderd !";
        }





        public ActionResult test(int Id)
        {
            var testje = new List<Test>() { new Test { id = 1, testnaam = "vermeersch", testvoornaam = "fluppe" },
                         new Test { id = 2, testnaam = "hendrickx", testvoornaam = "sven" } };
            //var testje = new Test { id = 1, testnaam = "vermeersch", testvoornaam = "fluppe" };
            return View(testje);

        }
    }
}