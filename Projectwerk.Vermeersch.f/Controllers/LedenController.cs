using Projectwerk.Vermeersch.f.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projectwerk.Vermeersch.f.Controllers
{
    public class LedenController : Controller
    {
        private TriatlonContext db = new TriatlonContext();

        // GET: Leden
        public ActionResult Index()
        {
            var putterslijst = db.Putters.Include("Wedstrijden").Include("Resultaten").ToList();
            return View(putterslijst);

        }
    }
}