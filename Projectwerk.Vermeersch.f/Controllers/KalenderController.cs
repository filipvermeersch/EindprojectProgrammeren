using Projectwerk.Vermeersch.f.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projectwerk.Vermeersch.f.Controllers
{
    public class KalenderController : Controller
    {
        private TriatlonContext db = new TriatlonContext();

        // GET: Kalender
        public ActionResult Index()
        {
            var wedstrijdlijst = db.Wedstrijden.Include("Deelnemers").Include("Resultaten").OrderBy(w => w.Datum).ToList();
            var todowedstrijden = from wedstrijd in wedstrijdlijst
                                      // where wedstrijd.Datum > DateTime.Now
                                  where wedstrijd.Datum > DateTime.Now.AddMonths(-3)

                                  select wedstrijd;
            return View(wedstrijdlijst);

        }
    }
}