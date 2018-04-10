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
    public class ResultatenController : Controller
    {
        private TriatlonContext db = new TriatlonContext();

        [HttpGet]
        public ActionResult AddResult(string PutterId , string  Id)

        {
            int nummer = Convert.ToInt32(PutterId);
            int wedstrijdNummer = Convert.ToInt32(Id);
            var wedstrijd = db.Wedstrijden.Include("Sport").FirstOrDefault(w => w.Id == wedstrijdNummer);
            var putter = db.Putters.FirstOrDefault(p => p.Id == nummer);
            ResultaatViewModel RVM = new ResultaatViewModel();
            RVM.PutterId = nummer;
            RVM.WedstrijdId = wedstrijdNummer;
            RVM.Plaats = wedstrijd.Plaats;
            RVM.soortSport = wedstrijd.Sport.soortSport;
            return PartialView("_AddResult", RVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddResult(ResultaatViewModel RVM)
        {
            if (ModelState.IsValid)
            {
                var resultaat = new Resultaat();
                resultaat.UitslagAlgemeen = RVM.UitslagAlgemeen;
                resultaat.UitslagCategorie = RVM.UitslagCategorie;
                resultaat.WedstrijdId = RVM.WedstrijdId;
                resultaat.PutterID = RVM.PutterId;

                var putter = db.Putters.FirstOrDefault(p => p.Id == RVM.PutterId);
                var wedstrijd = db.Wedstrijden.FirstOrDefault(w => w.Id == RVM.WedstrijdId);
                db.Resultaten.Add(resultaat);
                //wedstrijd.Resultaten.Add(resultaat);
                //putter.Resultaten.Add(resultaat);
                db.SaveChanges();

                return RedirectToAction("Index", "Wedstrijden", new { Id = RVM.PutterId });

            }
            return View(RVM);
        }
        public ActionResult Result(string id, string wedstrijdId)
        {
            int nummer = Convert.ToInt32(id);
            int wedstrijdNummer = Convert.ToInt32(wedstrijdId);

            var result = db.Resultaten.Include("Wedstrijd").FirstOrDefault(r => r.PutterID == nummer && r.WedstrijdId == wedstrijdNummer);

            return PartialView("_Result", result);

        }

    }
}