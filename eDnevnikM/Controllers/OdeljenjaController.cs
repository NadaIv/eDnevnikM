using eDnevnikM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace eDnevnikM.Controllers
{
    public class OdeljenjaController : Controller
    {
        // GET: Odeljenja
        public ActionResult Index()
        {
            return View();
        }
    


        public ActionResult GetOdeljenjas()
        {
            using (DBModel dc = new DBModel())
            {
                dc.Configuration.LazyLoadingEnabled = false;
                var odelj = dc.Odeljenjas.OrderBy(a => a.OdeljenjeID).ToList();
                return Json(new { data = odelj }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult Save(int id)
        {
            List<Godine> allGodine = new List<Godine>();
            List<Profesori> allProfesori = new List<Profesori>();
            using (DBModel dc = new DBModel())
            {
                allGodine = dc.Godines.OrderBy(a => a.Opis).ToList();
                allProfesori = dc.Profesoris.OrderBy(a => a.Ime).ToList();
            }
            ViewBag.GodinaID = new SelectList(allGodine, "GodinaID", "Opis");
            ViewBag.ProfesorID = new SelectList(allProfesori, "ProfesorID", "Ime");
            return View();
        }
        [HttpPost]
        public ActionResult Save(Odeljenja od)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (DBModel dc = new DBModel())
                {
                    if (od.OdeljenjeID > 0)
                    {
                        var v = dc.Odeljenjas.Where(a => a.OdeljenjeID == od.OdeljenjeID).FirstOrDefault();
                        if (v != null)
                        {
                            v.GodinaID = od.GodinaID;
                            v.BrojOdeljenja = od.BrojOdeljenja;
                            v.GodinaUpisa = od.GodinaUpisa;
                            v.ProfesorID = od.ProfesorID;


                        }
                    }
                    else
                    {
                        dc.Odeljenjas.Add(od);
                    }

                    dc.SaveChanges();
                    status = true;

                }
            }
            return new JsonResult { Data = new { status = status } };

			
        }
		
    }
}
