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
    public class PuttersController : Controller
    {
        private TriatlonContext db = new TriatlonContext();

        // GET: Admin/Putters
        public ActionResult Index()
        {
            var putters = db.Putters.Include(p => p.Role).Include(p => p.Sex);
            return View(putters.ToList());
        }

        // GET: Admin/Putters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Putter putter = db.Putters.Find(id);
            if (putter == null)
            {
                return HttpNotFound();
            }
            return View(putter);
        }

        // GET: Admin/Putters/Create
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.Roles, "Id", "Rolenaam");
            ViewBag.SexID = new SelectList(db.Sexes, "Id", "Geslacht");
            return View();
        }

        // POST: Admin/Putters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naam,Voornaam,Geboortedatum,Gebruikersnaam,Woonplaats,Paswoord,Email,Licentie,RoleID,SexID")] Putter putter)
        {
            if (ModelState.IsValid)
            {
                db.Putters.Add(putter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.Roles, "Id", "Rolenaam", putter.RoleID);
            ViewBag.SexID = new SelectList(db.Sexes, "Id", "Geslacht", putter.SexID);
            return View(putter);
        }

        // GET: Admin/Putters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Putter putter = db.Putters.Find(id);
            if (putter == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.Roles, "Id", "Rolenaam", putter.RoleID);
            ViewBag.SexID = new SelectList(db.Sexes, "Id", "Geslacht", putter.SexID);
            return View(putter);
        }

        // POST: Admin/Putters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naam,Voornaam,Geboortedatum,Gebruikersnaam,Woonplaats,Paswoord,Email,Licentie,RoleID,SexID")] Putter putter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(putter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.Roles, "Id", "Rolenaam", putter.RoleID);
            ViewBag.SexID = new SelectList(db.Sexes, "Id", "Geslacht", putter.SexID);
            return View(putter);
        }

        // GET: Admin/Putters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Putter putter = db.Putters.Find(id);
            if (putter == null)
            {
                return HttpNotFound();
            }
            return View(putter);
        }

        // POST: Admin/Putters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Putter putter = db.Putters.Find(id);
            db.Putters.Remove(putter);
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
