using eDnevnikM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace eDnevnikM.Controllers
{
	public class StaresineController : Controller
	{
		// GET: Staresine
		//public ActionResult Index()
		//{

		//	return View();
		//}
		//private List<Profesori> GetProfesoris()
		//{
		//	using (DBModel dc = new DBModel())
		//	{
		//		return dc.Profesoris.OrderBy(a => a.Ime).ToList();
		//	}
		//}

		//private List<Odeljenja> GetOdeljenjas()
		//{
		//	using (DBModel dc = new DBModel())
		//	{
		//		return dc.Odeljenjas.OrderBy(a => a.MatBrOdeljenja).ToList();
		//	}
		//}

		//public JsonResult GetStaresines()
		//{
		//	using (DBModel dc = new DBModel())
		//	{
		//		dc.Configuration.LazyLoadingEnabled = false;

		//		return new JsonResult { Data = GetStaresines(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };

		//	}
		//}
		//public Staresine GetContact(int star)
		//{
		//	Staresine contact = null;
		//	using (DBModel dc = new DBModel())
		//	{
		//		var v = (from a in dc.Staresines
		//				 join b in dc.Profesoris on a.ProfesorID equals b.ProfesorID
		//				 join c in dc.Odeljenjas on a.OdeljenjeID equals c.OdeljenjeID
		//				 where a.StaresinaID.Equals(star)
		//				 select new
		//				 {
		//					 a,
		//					 b.Ime,
		//					 c.MatBrOdeljenja
		//				 }).FirstOrDefault();
		//		//if (v != null)
		//		//{
		//		//	contact = v.a;
		//		//	contact.CountryName = v.CountryName;
		//		//	contact.StateName = v.StateName;
		//		//}
		//		return contact;
		//	}
		//}


		public ActionResult GetStaresines()
		{
			using (DBModel dc = new DBModel())
			{
				dc.Configuration.LazyLoadingEnabled = false;
				var staresines = dc.Staresines.OrderBy(a => a.ProfesorID).ToList();
				return Json(new { data = staresines }, JsonRequestBehavior.AllowGet);
			}
		}

		//[HttpGet]
		//public ActionResult Save(int id)
		//{
		//	List<Staresine> allStaresine = new List<Staresine>();
		//	using (DBModel dc = new DBModel())
		//	{
		//		allStaresine = dc.Staresines.Where(a => a.ProfesorID.Equals(id)).OrderBy(a => a.ProfesorID).ToList();
		//		allStaresine = dc.Staresines.Where(a => a.OdeljenjeID.Equals(id)).OrderBy(a => a.OdeljenjeID).ToList();
		//	}
		//	return new JsonResult { Data = allStaresine, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		//}


		//[HttpGet]
		//public ActionResult Save(int id)
		//{
		//	List<Profesori> allProfesori = new List<Profesori>();
		//	List<Odeljenja> allOdeljenja = new List<Odeljenja>();
		//	using (DBModel dc = new DBModel())
		//	{
		//		allProfesori = dc.Profesoris.OrderBy(a => a.Ime).ToList();
		//		allOdeljenja = dc.Odeljenjas.OrderBy(a => a.MatBrOdeljenja).ToList();
		//	}
		//	ViewBag.ProfesorID = new SelectList(allProfesori, "ProfesorID", "Ime");
		//	ViewBag.OdeljenjeID = new SelectList(allOdeljenja, "OdeljenjeID", "MatBrOdeljenja");
		//	return View();
		//}

		//[HttpGet]
		public ActionResult Save()
		{
			List<Profesori> allProfesori = new List<Profesori>();
			List<Odeljenja> allOdeljenja = new List<Odeljenja>();
			using (DBModel dc = new DBModel())
			{
				allProfesori = dc.Profesoris.OrderBy(a => a.Ime).ToList();
				//allOdeljenja = dc.Odeljenjas.OrderBy(a => a.MatBrOdeljenja).ToList();
			}
			ViewBag.Prof = new SelectList(allProfesori, "ProfesorID", "Ime");
			ViewBag.Odelj = new SelectList(allOdeljenja, "OdeljenjeID", "MatBrOdeljenja");
			return View();
		}

		//[HttpPost]
		//[ValidateAntiForgeryToken]

		//public ActionResult Save(Staresine star)
		//{

		//	bool status = false;
		//	if (ModelState.IsValid)
		//	{
		//		using (DBModel dc = new DBModel())
		//		{



		//			if (star.StaresinaID > 0)
		//			{
		//				var v = dc.Staresines.Where(a => a.StaresinaID == star.StaresinaID).FirstOrDefault();
		//				if (v != null)
		//				{
		//					v.ProfesorID = star.ProfesorID;
		//					v.OdeljenjeID = star.OdeljenjeID;
		//				}
		//			}
		//			else
		//			{

		//				dc.Staresines.Add(star);
		//			}
		//			dc.SaveChanges();
		//			status = true;
		//		}



		//	}
		//	return new JsonResult
		//	{
		//		Data = new
		//		{
		//			status = status
		//		}
		//	};
		//}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public ActionResult Save(Staresine star)
		{
			List<Profesori> allProfesori = new List<Profesori>();
			List<Odeljenja> allOdeljenja = new List<Odeljenja>();

			using (DBModel dc = new DBModel())
			{
				allProfesori = dc.Profesoris.OrderBy(a => a.Ime).ToList();

				if (star != null && star.ProfesorID > 0)
				{
					allOdeljenja = dc.Odeljenjas.Where(a => a.ProfesorID.Equals(star.ProfesorID)).OrderBy(a => a.MatBrOdeljenja).ToList();
				}
			}


			ViewBag.Prof = new SelectList(allProfesori, "ProfesorID", "Ime",star.ProfesorID);
			ViewBag.Odelj = new SelectList(allOdeljenja, "OdeljenjeID", "MatBrOdeljenja", star.OdeljenjeID);


			if (ModelState.IsValid)
			{
				using (DBModel dc = new DBModel())
				{



					//if (star.StaresinaID > 0)
					//{
					//	var v = dc.Staresines.Where(a => a.StaresinaID == star.StaresinaID).FirstOrDefault();
					//	if (v != null)
					//	{
					//		v.ProfesorID = star.ProfesorID;
					//		v.OdeljenjeID = star.OdeljenjeID;
					//	}
					//}
					//else
					{

						dc.Staresines.Add(star);

						dc.SaveChanges();
						ModelState.Clear();
						star = null;
						ViewBag.Message = "no";
					}
				}
			}
			else
			{
				ViewBag.Message = "yes";
			}
				return View();


			}
			//return new JsonResult { Data = new { status = status } };
		}

	//[HttpGet]
	//public JsonResult GetStaresine(string profesorID = "" )
	//{
	//	List<Odeljenja> allOdeljenja = new List<Odeljenja>();
	//	int ID = 0;
	//	if (int.TryParse(profesorID, out ID))
	//	{
	//		using (DBModel dc = new DBModel())
	//		{
	//			allOdeljenja = dc.Odeljenjas.Where(a => a.ProfesorID.Equals(ID)).OrderBy(a => a.MatBrOdeljenja).ToList();
	//		}
	//	}
	//	//if (Request.IsAjaxRequest())
	//	//{
	//	//	return new JsonResult
	//	//	{
	//	//		Data = allOdeljenja,
	//	//		JsonRequestBehavior = JsonRequestBehavior.AllowGet
	//	//	};
	//	//}
	//	else
	//	{
	//		return new JsonResult
	//		{
	//			Data = "Not valid request",
	//			JsonRequestBehavior = JsonRequestBehavior.AllowGet
	//		};
			//[HttpGet]
			//public ActionResult Delete(int id)
			//{
			//	using (DBModel dc = new DBModel())
			//	{
			//		var v = dc.Staresines.Where(a => a.StaresinaID == id).FirstOrDefault();
			//		if (v != null)
			//		{
			//			return View(v);

			//		}
			//		else
			//		{
			//			return HttpNotFound();
			//		}
			//	}
			//}

			//[HttpPost]
			//[ActionName("Delete")]
			//public ActionResult DeleteProfesori(int id)
			//{
			//	bool status = false;
			//	using (DBModel dc = new DBModel())

			//	{
			//		var v = dc.Staresines.Where(a => a.StaresinaID == id).FirstOrDefault();
			//		if (v != null)
			//		{
			//			dc.Staresines.Remove(v);
			//			dc.SaveChanges();
			//			status = true;


			//		}


			//	}

			//	return new JsonResult { Data = new { status = status } };
			//}
		}
	
		




