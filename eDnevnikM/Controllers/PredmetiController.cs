﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eDnevnikM.Models;


namespace eDnevnikM.Controllers
{
    public class PredmetiController : Controller
    {
        // GET: Predmeti
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult GetPredmetis()
		{
			using (DBModel dc = new DBModel())
			{
				dc.Configuration.LazyLoadingEnabled = false;
				var predmetis = dc.Predmetis.OrderBy(a => a.NazivPredmeta).ToList();
				return Json(new { data = predmetis }, JsonRequestBehavior.AllowGet);
			}
		}

		[HttpGet]
		public ActionResult Save(int id)
		{
           
            List<Profesori> allProfesori = new List<Profesori>();
			List<Godine> allGodine = new List<Godine>();
            using (DBModel dc = new DBModel())
            {
               
                allProfesori = dc.Profesoris.OrderBy(a => a.Ime).ToList();
				allGodine = dc.Godines.OrderBy(a => a.Opis).ToList();
            }
            
            ViewBag.ProfesorID = new SelectList(allProfesori, "ProfesorID", "Ime");
			ViewBag.GodinaID = new SelectList(allGodine, "GodinaID", "Opis");
            return View();
            //using (DBModel dc = new DBModel())
            //{
            //	var v = dc.Predmetis.Where(a => a.PredmetID == id).FirstOrDefault();
            //	return View(v);
            //}
        }
		[HttpPost]
		[ActionName("Save")]
		public ActionResult SavePredmeti(Predmeti pred)
		{
			bool status = false;
			if (ModelState.IsValid)
			{
				using (DBModel dc = new DBModel())
				{
					if (pred.PredmetID > 0)
					{
						var v = dc.Predmetis.Where(a => a.PredmetID == pred.PredmetID).FirstOrDefault();
						if (v != null)
						{
							v.NazivPredmeta = pred.NazivPredmeta;
							v.Redosled = pred.Redosled;
							v.TipOcene = pred.TipOcene;
                            v.ProfesorID = pred.ProfesorID;
							v.GodinaID = pred.GodinaID;


						}
					}
					else
					{
						dc.Predmetis.Add(pred);
					}

					dc.SaveChanges();
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
				var v = dc.Predmetis.Where(a => a.PredmetID == id).FirstOrDefault();
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
		public ActionResult DeletePredmeti(int id)
		{
			bool status = false;
			using (DBModel dc = new DBModel())

			{
				var v = dc.Predmetis.Where(a => a.PredmetID == id).FirstOrDefault();
				if (v != null)
				{
					dc.Predmetis.Remove(v);
					dc.SaveChanges();
					status = true;


				}


			}

			return new JsonResult { Data = new { status = status } };
		}
        public ActionResult IndexPr()
        {
            return View();
        }
    }
}