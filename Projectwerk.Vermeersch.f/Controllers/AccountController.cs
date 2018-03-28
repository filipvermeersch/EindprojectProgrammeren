using Projectwerk.Vermeersch.f.Data;
using Projectwerk.Vermeersch.f.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Projectwerk.Vermeersch.f.Controllers
{
    public class AccountController : Controller
    {
        private TriatlonContext db = new TriatlonContext();

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

                //else
                //{
                //    ModelState.AddModelError("CredentialError", "De ingevoerde gebruikersnaam en/of het wachtwoord is ongeldig");
                //}
                else
                {
                    FormsAuthentication.SetAuthCookie(putter.Gebruikersnaam, IVM.Onthouden);

                    TempData["succesboodschap"] = "Welkom, <b>" + putter.Gebruikersnaam + "</b><br />Je bent succesvol ingelogd";
                    return RedirectToAction("Index", "Home");

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

    }
}