using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projectwerk.Vermeersch.f.Data;
using Projectwerk.Vermeersch.f.Models;

namespace Projectwerk.Vermeersch.f.Areas.Admin.Controllers
{
    [Authorize]
    public class ResultaatsController : Controller
    {
        private TriatlonContext db = new TriatlonContext();

        // GET: Admin/Resultaats
        public ActionResult Index()
        {
            var resultaten = db.Resultaten.Include(r => r.Putter).Include(r => r.Wedstrijd);
            return View(resultaten.ToList());
        }

        // GET: Admin/Resultaats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultaat resultaat = db.Resultaten.Find(id);
            if (resultaat == null)
            {
                return HttpNotFound();
            }
            return View(resultaat);
        }

        // GET: Admin/Resultaats/Create
        public ActionResult Create()
        {
            ViewBag.PutterID = new SelectList(db.Putters, "Id", "Naam");
            ViewBag.WedstrijdId = new SelectList(db.Wedstrijden, "Id", "Plaats");
            return View();
        }

        // POST: Admin/Resultaats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UitslagCategorie,UitslagAlgemeen,PutterID,WedstrijdId")] Resultaat resultaat)
        {
            if (ModelState.IsValid)
            {
                db.Resultaten.Add(resultaat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PutterID = new SelectList(db.Putters, "Id", "Naam", resultaat.PutterID);
            ViewBag.WedstrijdId = new SelectList(db.Wedstrijden, "Id", "Plaats", resultaat.WedstrijdId);
            return View(resultaat);
        }

        // GET: Admin/Resultaats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultaat resultaat = db.Resultaten.Find(id);
            if (resultaat == null)
            {
                return HttpNotFound();
            }
            ViewBag.PutterID = new SelectList(db.Putters, "Id", "Naam", resultaat.PutterID);
            ViewBag.WedstrijdId = new SelectList(db.Wedstrijden, "Id", "Plaats", resultaat.WedstrijdId);
            return View(resultaat);
        }

        // POST: Admin/Resultaats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UitslagCategorie,UitslagAlgemeen,PutterID,WedstrijdId")] Resultaat resultaat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resultaat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PutterID = new SelectList(db.Putters, "Id", "Naam", resultaat.PutterID);
            ViewBag.WedstrijdId = new SelectList(db.Wedstrijden, "Id", "Plaats", resultaat.WedstrijdId);
            return View(resultaat);
        }

        // GET: Admin/Resultaats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultaat resultaat = db.Resultaten.Find(id);
            if (resultaat == null)
            {
                return HttpNotFound();
            }
            return View(resultaat);
        }

        // POST: Admin/Resultaats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resultaat resultaat = db.Resultaten.Find(id);
            db.Resultaten.Remove(resultaat);
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
