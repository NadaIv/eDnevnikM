using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eDnevnikM.Models;

namespace eDnevnikM.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(Profesori u)
		{
			// this action is for handle post (login)
			if (ModelState.IsValid) // this is check validity
			{
				using (DBModel dc = new DBModel())
				{
					var v = dc.Profesoris.Where(a => a.KorisnickoIme.Equals(u.KorisnickoIme) && a.Lozinka.Equals(u.Lozinka)).FirstOrDefault();
					if (v != null)
					{
						Session["LogedProfesorID"] = v.ProfesorID.ToString();
						Session["LogedUserImeProfesora"] = v.Ime.ToString();
						return RedirectToAction("PosleLogin");
					}
				}
			}
			return View(u);
		}


		public ActionResult PosleLogin()
		{
			if (Session["LogedProfesorID"] != null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Index");
			}
		}
	}
}