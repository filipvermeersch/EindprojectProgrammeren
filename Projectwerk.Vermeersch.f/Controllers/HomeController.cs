using Projectwerk.Vermeersch.f.Data;
using System.Web.Mvc;

namespace Projectwerk.Vermeersch.f.Controllers
{
    public class HomeController : Controller
    {
        private TriatlonContext db = new TriatlonContext();

        public ActionResult Index()
        {
            //   List<Sport> sportlijst = db.Sporten.ToList();
            //  return View(sportlijst);
            return View();
        }

        //public ActionResult Leden()
        //{
        //    var putterslijst = db.Putters.ToList();
        //    return View(putterslijst);
        //}

    }
}