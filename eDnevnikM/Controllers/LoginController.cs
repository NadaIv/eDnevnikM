using eDnevnikM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eDnevnikM.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Odobrenje(Profesori prof)
		{
			using (DBModel dc = new DBModel())
			{
				var v = dc.Profesoris.Where(a => a.KorisnickoIme == prof.KorisnickoIme && a.Lozinka == prof.Lozinka && a.Status == prof.Status).FirstOrDefault();
				if (v == null)
				{
                    if(prof.KorisnickoIme !=null || prof.Lozinka == null)

                    prof.LoginErrorMessage = "Pokusaj ponovo...";
					return View("Index", prof);
				}

				else
				{
                    if (prof.KorisnickoIme == prof.KorisnickoIme && prof.Lozinka == prof.Lozinka && prof.Status.Contains("admin"))
                    {
                        Session["ProfesorID"] = v.ProfesorID;
                        Session["KorisnickoIme"] = v.KorisnickoIme;
                        return RedirectToAction("Index", "Home");
                    }
                    Session["ProfesorID"] = v.ProfesorID;
                    Session["KorisnickoIme"] = v.KorisnickoIme;
                    return RedirectToAction("About", "Home");
                }
				
			}
		}
		public ActionResult LogOut()
		{
			//int ProfesorID = (int)Session["ProfesorID"];
			Session.Abandon();
			return RedirectToAction("Index", "Login");
		}
	}
}