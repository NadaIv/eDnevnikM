using eDnevnikM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eDnevnikM.Controllers
{
    public class ProfesoriController : Controller
    {
        // GET: Profesori
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult GetProfesoris()
		{
			using (DBModel dc = new DBModel())
			{
				dc.Configuration.LazyLoadingEnabled = false;
				var profesoris = dc.Profesoris.OrderBy(a => a.Ime).ToList();
				return Json(new { data = profesoris }, JsonRequestBehavior.AllowGet);
			}
		}

		[HttpGet]
		public ActionResult Save(int id)
		{
			using (DBModel dc = new DBModel())
			{
				var v = dc.Profesoris.Where(a => a.ProfesorID == id).FirstOrDefault();
				return View(v);
			}
		}
		[HttpPost]
		public ActionResult Save(Profesori prof)
		{
			bool status = false;
			if (ModelState.IsValid)
			{
				using (DBModel dc = new DBModel())
				{
					if (prof.ProfesorID > 0)
					{
						var v = dc.Profesoris.Where(a => a.ProfesorID == prof.ProfesorID).FirstOrDefault();
						if (v != null)
						{
							v.Ime = prof.Ime;
							v.Prezime = prof.Prezime;
							v.KorisnickoIme = prof.KorisnickoIme;
							v.Lozinka = prof.Lozinka;
							v.Status = prof.Status;

						}
					}
					else
					{
						dc.SaveChanges();
					}
					status = true;
				}
			}
			return new JsonResult { Data = new { status = status } };
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			using (DBModel dc = new DBModel())
			{
				var v = dc.Profesoris.Where(a => a.ProfesorID == id).FirstOrDefault();
				if (v != null)
				{
					return View(v);

				}
				else
				{
					return HttpNotFound();
				}
			}
		}

		[HttpPost]
		[ActionName("Delete")]
		public ActionResult DeleteProfesori(int id)
		{
			bool status = false;
			using (DBModel dc = new DBModel())

			{
				var v = dc.Profesoris.Where(a => a.ProfesorID == id).FirstOrDefault();
				if (v != null)
				{
					dc.Profesoris.Remove(v);
					dc.SaveChanges();
					status = true;


				}


			}

			return new JsonResult { Data = new { status = status } };
		}
	}
}