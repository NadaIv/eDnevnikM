using eDnevnikM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                var odeljenjas = dc.Odeljenjas.OrderBy(a => a.OdeljenjeID).ToList();
                return Json(new { data = odeljenjas }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            using (DBModel dc = new DBModel())
            {
                var v = dc.Odeljenjas.Where(a => a.OdeljenjeID == id).FirstOrDefault();
                return View(v);
            }
        }
        [HttpPost]
        public ActionResult Save(Odeljenja ode)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (DBModel dc = new DBModel())
                {
                    if (ode.OdeljenjeID > 0)
                    {
                        var v = dc.Odeljenjas.Where(a => a.OdeljenjeID == ode.OdeljenjeID).FirstOrDefault();
                        if (v != null)
                        {
                            v.GodinaID = ode.GodinaID;
                            v.BrojOdeljenja = ode.BrojOdeljenja;
                            v.GodinaUpisa = ode.GodinaUpisa;
                            v.MatBrOdeljenja = ode.MatBrOdeljenja;
                           

                        }
                    }
                    else
                    {
                        dc.Odeljenjas.Add(ode);
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
                var v = dc.Odeljenjas.Where(a => a.OdeljenjeID == id).FirstOrDefault();
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
        public ActionResult DeleteOdeljenja(int id)
        {
            bool status = false;
            using (DBModel dc = new DBModel())

            {
                var v = dc.Odeljenjas.Where(a => a.OdeljenjeID == id).FirstOrDefault();
                if (v != null)
                {
                    dc.Odeljenjas.Remove(v);
                    dc.SaveChanges();
                    status = true;


                }


            }

            return new JsonResult { Data = new { status = status } };
        }
    }
}