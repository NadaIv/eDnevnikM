using eDnevnikM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eDnevnikM.Controllers
{
    public class PrvaGodinaController : Controller
    {
		// GET: PrvaGodina
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult GetUcenicis()
		{
			using (DBModel dc = new DBModel())
			{
				dc.Configuration.LazyLoadingEnabled = false;
				var ucen = dc.Ucenicis.OrderBy(a => a.UcenikID).ToList();
				return Json(new { data = ucen }, JsonRequestBehavior.AllowGet);
			}
		}
		//[HttpGet]
		//public ActionResult Save(int id)
		//{
		//	List<Odeljenja> allOdeljenja = new List<Odeljenja>();


		//	using (DBModel dc = new DBModel())
		//	{
		//		allOdeljenja = dc.Odeljenjas.OrderBy(a => a.MatBrOdeljenja).ToList();

		//	}
		//	ViewBag.OdeljenjeID = new SelectList(allOdeljenja, "OdeljenjeID", "MatBrOdeljenja");

		//	return View();
		//}
		//[HttpPost]
		//public ActionResult Save(Ucenici ucen)
		//{
		//	bool status = false;
		//	if (ModelState.IsValid)
		//	{
		//		using (DBModel dc = new DBModel())
		//		{
		//			if (ucen.UcenikID > 0)
		//			{
		//				var v = dc.Ucenicis.Where(a => a.UcenikID == ucen.UcenikID).FirstOrDefault();
		//				if (v != null)
		//				{
		//					v.OdeljenjeID = ucen.OdeljenjeID;
		//					v.Ime = ucen.Ime;
		//					v.Prezime = ucen.Prezime;
		//					v.DatumRodjenja = ucen.DatumRodjenja;
		//					v.Adresa = ucen.Adresa;
		//					v.GodinaUpisa = ucen.GodinaUpisa;
		//					v.RedBrUOdeljenju = ucen.RedBrUOdeljenju;

		//					v.Lozinka = ucen.Lozinka;


		//				}
		//			}
		//			else
		//			{
		//				dc.Ucenicis.Add(ucen);
		//			}

		//			dc.SaveChanges();
		//			status = true;

		//		}
		//	}
		//	return new JsonResult { Data = new { status = status } };
		//}
	}
}