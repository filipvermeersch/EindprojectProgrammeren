using Projectwerk.Vermeersch.f.Data;
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
        public ActionResult AddResult(int id)
        {
            var wedstrijdId = 1;
            var wedstrijd = db.Wedstrijden.Include("Sport").FirstOrDefault(w => w.Id == wedstrijdId);
            ResultaatViewModel RVM = new ResultaatViewModel();
            RVM.PutterId = id;
            RVM.WedstrijdId = wedstrijdId;
            

            RVM.Plaats = wedstrijd.Plaats;
            RVM.soortSport = wedstrijd.Sport.soortSport;
            return PartialView("_AddResult", RVM);

        }

    }
}