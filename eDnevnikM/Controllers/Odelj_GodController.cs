//using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eDnevnikM.Models;
using System.Data.Entity;

namespace eDnevnikM.Controllers
{
    public class Odelj_GodController : Controller
    {
        // GET: Odelj_God
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOdelj_Gods()
        {
            using (DBModel dc = new DBModel())
            {
                dc.Configuration.LazyLoadingEnabled = false;
                var Odelj_Gods = dc.Odeljenjas.OrderBy(a => a.GodinaID).ToList();
                return Json(new { data = Odelj_Gods }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult Odelj_God_Save(int id)
        {
            List<Godine> allGodine = new List<Godine>();
            //List<Odeljenja> allOdeljenja = new List<Odeljenja>();
            using (DBModel dc = new DBModel())
            {
                allGodine = dc.Godines.OrderBy(a => a.GodinaID).ToList();
            }
            ViewBag.GodinaID = new SelectList(allGodine, "GodinaID", "Opis");
            //ViewBag.OdeljenjeID = new SelectList(allOdeljenja, "OdeljenjeID", "OdeljenjeID");
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public ActionResult Odelj_God_Save1(Odeljenja od)
        //{
        //    List<Godine> allGodine = new List<Godine>();
        //    //List<Odeljenja> allOdeljenja = new List<Odeljenja>();

        //    using (DBModel dc = new DBModel())

        //    {
        //        allGodine = dc.Godines.OrderBy(a => a.Opis).ToList();
        //        //if (od != null && od.GodinaID > 0)

        //        //{
        //        //    allOdeljenja = dc.Odeljenjas.Where(a => a.GodinaID.Equals(od.GodinaID)).OrderBy(a => a.OdeljenjeID).ToList();
        //        //}

        //        ViewBag.GodinaID = new SelectList(allGodine, "GodinaID", "Opis", od.GodinaID);
        //        //ViewBag.OdeljenjeID = new SelectList(allOdeljenja, "OdeljenjeID", "OdeljenjeID", od.OdeljenjeID);

        //        if (ModelState.IsValid)
        //        {


        //            dc.Odeljenjas.Add(od);
        //            dc.SaveChanges();
        //            ModelState.Clear();
        //            od = null;
        //            ViewBag.Message = "Odlicno";



        //        }
        //        else
        //        {
        //            ViewBag.Message = "Pokusaj ponovo";
        //        }

        //    }
        //    return View(od);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public ActionResult Odelj_God_Save1(Odeljenja od)
        //{
        //    List<Godine> allGodine = new List<Godine>();
        //    //List<Odeljenja> allOdeljenja = new List<Odeljenja>();

        //    using (DBModel dc = new DBModel())

        //    {
        //        allGodine = dc.Godines.OrderBy(a => a.Opis).ToList();
        //        if (od != null && od.GodinaID > 0)

        //        {
        //            allGodine = dc.Godines.Where(a => a.GodinaID.Equals(od.GodinaID)).OrderBy(a => a.GodinaID).ToList();
        //        }

        //        ViewBag.GodinaID = new SelectList(allGodine, "GodinaID", "Opis", od.GodinaID);
        //        //ViewBag.OdeljenjeID = new SelectList(allOdeljenja, "OdeljenjeID", "OdeljenjeID", od.OdeljenjeID);

        //        if (ModelState.IsValid)
        //        {


        //            dc.Odeljenjas.Add(od);
        //            dc.SaveChanges();
        //            ModelState.Clear();
        //            od = null;
        //            ViewBag.Message = "Odlicno";



        //        }
        //        else
        //        {
        //            ViewBag.Message = "Pokusaj ponovo";
        //        }

        //    }
        //    return View(od);
        //}

        [HttpPost]
        public ActionResult Odelj_God_Save1(Odeljenja od)
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
                            v.BrojOdeljenja= od.BrojOdeljenja;
                            v.GodinaUpisa = od.GodinaUpisa;
                          

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