using Projectwerk.Vermeersch.f.Data;
using Projectwerk.Vermeersch.f.Viewmodels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Projectwerk.Vermeersch.f.Controllers
{
    public class AccountController : Controller
    {
        private TriatlonContext db = new TriatlonContext();
        private object adm;



        // GET: Account/Login
        public ActionResult Login()
        {
            InlogViewModel IVM = new InlogViewModel();
            return View(IVM);

        }
        // POST: Account/Login

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(InlogViewModel IVM)
        {
            if (ModelState.IsValid)
            {
                var putter = db.Putters.FirstOrDefault(p => p.Paswoord == IVM.Paswoord &&
                             p.Gebruikersnaam == IVM.Gebruikersnaam);

                if (putter == null)
                {
                    ModelState.AddModelError("", "De ingevoerde gebruikersnaam en/of het wachtwoord is ongeldig");

                    return View(IVM);

                }

                else
                {
                    
                    FormsAuthentication.SetAuthCookie(putter.Gebruikersnaam, IVM.Onthouden);

                    TempData["succesboodschap"] = "Welkom, <b>" + putter.Gebruikersnaam + "</b><br />Je bent succesvol ingelogd";

                    if (putter.Role.Rolenaam=="Admin")
                    {
                      
                    }

                    //return RedirectToAction("Index", "Home");
                    return View(IVM);

                }
            }
            else
            {
                return View(IVM);
            }
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult ChangePassword()
        {
            ChangePasswordViewModel CPVM = new ChangePasswordViewModel();
            return View(CPVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel CPVM)

        {
            if (ModelState.IsValid)
            {
                var putter = db.Putters.FirstOrDefault(p => p.Paswoord == CPVM.Paswoord &&
                p.Gebruikersnaam == CPVM.Gebruikersnaam);
                putter.Paswoord = CPVM.NieuwPaswoord;
                db.Entry(putter).State = EntityState.Modified;
                db.SaveChanges();
                FormsAuthentication.SetAuthCookie(putter.Gebruikersnaam, true);

                TempData["succesboodschap"] = "Welkom, <b>" + putter.Gebruikersnaam + "</b><br />Je paswoord werd gewijzigd";
                //return RedirectToAction("Index", "Home");
                return View(CPVM);


            }
            else
            {
                return View(CPVM);
            }

        }

        public ActionResult ChangeUsername()
        {
            ChangeUsernameViewModel CUVM = new ChangeUsernameViewModel();
            return View(CUVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeUsername(ChangeUsernameViewModel CUVM)
        {
            if (ModelState.IsValid)
            {
                var putter = db.Putters.FirstOrDefault(p => p.Paswoord == CUVM.Paswoord &&
                p.Gebruikersnaam == CUVM.Gebruikersnaam);
                putter.Gebruikersnaam = CUVM.NewUsername;
                db.Entry(putter).State = EntityState.Modified;
                db.SaveChanges();
                FormsAuthentication.SetAuthCookie(putter.Gebruikersnaam, true);
                TempData["succesboodschap"] = "Welkom, <b>" + putter.Gebruikersnaam + "</b><br />Je gebruikersnaam werd gewijzigd";

                //return RedirectToAction("Index", "Home");
                return View(CUVM);

            }
            else
            {
                return View(CUVM);
            }

        }


    }
}