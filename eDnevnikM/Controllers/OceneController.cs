using eDnevnikM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eDnevnikM.Controllers
{
    public class OceneController : Controller
    {
        // GET: Ocene
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult GetOcenes()
		{
			using (DBModel dc = new DBModel())
			{
				dc.Configuration.LazyLoadingEnabled = false;
				var ocenes = dc.Ocenes.OrderBy(a => a.Ocena).ToList();
				return Json(new { data = ocenes }, JsonRequestBehavior.AllowGet);
			}
		}

		[HttpGet]
		public ActionResult Save(int id)
		
		{
			using (DBModel dc = new DBModel())
			{
				var v = dc.Ocenes.Where(a => a.OcenaID == id).FirstOrDefault();
				return View(v);
			}
		}
		[HttpPost]
	
		public ActionResult Save(Ocene oce)
		{
			bool status = false;
			if (ModelState.IsValid)
			{
				using (DBModel dc = new DBModel())
				{
					if (oce.OcenaID > 0)
					{
						var v = dc.Ocenes.Where(a => a.OcenaID == oce.OcenaID).FirstOrDefault();
						if (v != null)
						{
							v.Ocena = oce.Ocena;
							v.OpisOcene = oce.OpisOcene;
							v.TipOcene = oce.TipOcene;
							

						}
					}
					else
					{
						dc.Ocenes.Add(oce);
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
				var v = dc.Ocenes.Where(a => a.OcenaID == id).FirstOrDefault();
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
		public ActionResult DeleteOcene(int id)
		{
			bool status = false;
			using (DBModel dc = new DBModel())

			{
				var v = dc.Ocenes.Where(a => a.OcenaID == id).FirstOrDefault();
				if (v != null)
				{
					dc.Ocenes.Remove(v);
					dc.SaveChanges();
					status = true;


				}


			}

			return new JsonResult { Data = new { status = status } };
		}
	}
}