using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eDnevnikM.Models;

namespace eDnevnikM.Controllers
{
	public class OdeljGodController : Controller
	{
		// GET: OdeljGod
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult OdeljGod(int id)
		{
			List<Godine> allGodine = new List<Godine>();
			List<Odeljenja> allOdeljenja = new List<Odeljenja>();
			using (DBModel dc = new DBModel())
			{
				allGodine = dc.Godines.OrderBy(a => a.Opis).ToList();
			}
			ViewBag.GodinaID = new SelectList(allGodine, "GodinaID", "Opis");
			ViewBag.OdeljenjeID = new SelectList(allOdeljenja, "OdeljenjeID", "OdeljenjeID");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public ActionResult OdeljGod(Odeljenja od)
		{
			List<Godine> allGodine = new List<Godine>();
			List<Odeljenja> allOdeljenja = new List<Odeljenja>();

			using (DBModel dc = new DBModel())

			{
				allGodine = dc.Godines.OrderBy(a => a.Opis).ToList();
				if (od != null && od.GodinaID > 0)

				{
					allOdeljenja = dc.Odeljenjas.Where(a => a.GodinaID.Equals(od.GodinaID)).OrderBy(a => a.OdeljenjeID).ToList();
				}
			}
			ViewBag.GodinaID = new SelectList(allGodine, "GodinaID", "Opis", od.GodinaID);
			ViewBag.OdeljenjeID = new SelectList(allOdeljenja, "OdeljenjeID", "OdeljenjeID", od.OdeljenjeID);

			if (ModelState.IsValid)
			{

				using (DBModel dc = new DBModel())
				{
					dc.Odeljenjas.Add(od);
					dc.SaveChanges();
					ModelState.Clear();
					od = null;
					ViewBag.Message = "Odlicno";
				}


			}
			else
			{
				ViewBag.Message = "Pokusaj ponovo";
			}
			return View(od);
		}

		[HttpGet]
		public JsonResult GetOdeljenjas(string GodinaID = "")
		{
			List<Odeljenja> allOdeljenja = new List<Odeljenja>();
			int ID = 0;
			if (int.TryParse(GodinaID, out ID))
			{
				using (DBModel dc = new DBModel())
				{
					allOdeljenja = dc.Odeljenjas.Where(a => a.GodinaID.Equals(ID)).OrderBy(a => a.OdeljenjeID).ToList();
				}
			}
			if (Request.IsAjaxRequest())
			{
				return new JsonResult
				{
					Data = allOdeljenja,
					JsonRequestBehavior = JsonRequestBehavior.AllowGet
				};
			}
			else
			{
				return new JsonResult
				{
					Data = "Nije dobro",
					JsonRequestBehavior = JsonRequestBehavior.AllowGet
				};
			}
		}
	}
}