using Projectwerk.Vermeersch.f.Data;
using System.Web.Mvc;

namespace Projectwerk.Vermeersch.f.Controllers
{
    public class HomeController : Controller
    {
        private TriatlonContext db = new TriatlonContext();

        public ActionResult Index()
        {
         

            return View();
        }
    }
}