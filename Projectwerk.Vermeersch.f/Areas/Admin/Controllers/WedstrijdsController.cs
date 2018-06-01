using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Projectwerk.Vermeersch.f.Data;
using Projectwerk.Vermeersch.f.Models;

namespace Projectwerk.Vermeersch.f.Areas.Admin.Controllers
{
    [Authorize(Users ="Fluppe")]
    public class WedstrijdsController : Controller
    {
        private TriatlonContext db = new TriatlonContext();

        // GET: Admin/Wedstrijds
        public ActionResult Index()
        {
            var wedstrijden = db.Wedstrijden.Include(w => w.Afstand).Include(w => w.Sport);
            return View(wedstrijden.ToList());
        }

        // GET: Admin/Wedstrijds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wedstrijd wedstrijd = db.Wedstrijden.Find(id);
            if (wedstrijd == null)
            {
                return HttpNotFound();
            }
            return View(wedstrijd);
        }

        // GET: Admin/Wedstrijds/Create
        public ActionResult Create()
        {
            ViewBag.AfstandId = new SelectList(db.Afstanden, "Id", "Lengte");
            ViewBag.SportId = new SelectList(db.Sporten, "Id", "soortSport");
            return View();
        }

        // POST: Admin/Wedstrijds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Plaats,Datum,Stayer,AfstandId,SportId")] Wedstrijd wedstrijd)
        {
            if (ModelState.IsValid)
            {
                db.Wedstrijden.Add(wedstrijd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AfstandId = new SelectList(db.Afstanden, "Id", "Lengte", wedstrijd.AfstandId);
            ViewBag.SportId = new SelectList(db.Sporten, "Id", "soortSport", wedstrijd.SportId);
            return View(wedstrijd);
        }

        // GET: Admin/Wedstrijds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wedstrijd wedstrijd = db.Wedstrijden.Find(id);
            if (wedstrijd == null)
            {
                return HttpNotFound();
            }
            ViewBag.AfstandId = new SelectList(db.Afstanden, "Id", "Lengte", wedstrijd.AfstandId);
            ViewBag.SportId = new SelectList(db.Sporten, "Id", "soortSport", wedstrijd.SportId);
            return View(wedstrijd);
        }

        // POST: Admin/Wedstrijds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Plaats,Datum,Stayer,AfstandId,SportId")] Wedstrijd wedstrijd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wedstrijd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AfstandId = new SelectList(db.Afstanden, "Id", "Lengte", wedstrijd.AfstandId);
            ViewBag.SportId = new SelectList(db.Sporten, "Id", "soortSport", wedstrijd.SportId);
            return View(wedstrijd);
        }

        // GET: Admin/Wedstrijds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wedstrijd wedstrijd = db.Wedstrijden.Find(id);
            if (wedstrijd == null)
            {
                return HttpNotFound();
            }
            return View(wedstrijd);
        }

        // POST: Admin/Wedstrijds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wedstrijd wedstrijd = db.Wedstrijden.Find(id);
            db.Wedstrijden.Remove(wedstrijd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
