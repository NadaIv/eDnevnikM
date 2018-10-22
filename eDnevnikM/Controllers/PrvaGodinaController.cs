using eDnevnikM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//namespace eDnevnikM.Controllers
//{
//    public class PrvaGodinaController : Controller
//    {
//		// GET: PrvaGodina
//		public ActionResult Index()
//		{
//			return View();
//		}
//		public ActionResult GetUcenicis()
//		{
//			using (DBModel dc = new DBModel())
//			{
//				dc.Configuration.LazyLoadingEnabled = false;
//				var ucen = dc.Ucenicis.OrderBy(a => a.UcenikID).ToList();
//				return Json(new { data = ucen }, JsonRequestBehavior.AllowGet);
//			}
//		}
//		public ActionResult ListaOd()
//		{
//			DBModel dc = new DBModel();
//			List<Odeljenja> odeljenjas = dc.Odeljenjas.ToList();
//			return View(odeljenjas);
//		}
//		public ActionResult ListaUc(int odeljenjeId)
//		{
//			DBModel dc = new DBModel();
//			List<Ucenici> ucenicis = dc.Ucenicis.Where(a => a.OdeljenjeID == odeljenjeId).ToList();
//			return View(ucenicis);
//		}
//		public ActionResult Details(int id)
//		{
//			DBModel dc = new DBModel();
//			Ucenici ucenici = dc.Ucenicis.Single(a => a.UcenikID == id);
//			return View(ucenici);
//		}
//	}
//}