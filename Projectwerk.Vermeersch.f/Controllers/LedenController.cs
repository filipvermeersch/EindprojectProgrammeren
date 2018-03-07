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
            var putterslijst = db.Putters.ToList();
            return View(putterslijst);

        }
    }
}