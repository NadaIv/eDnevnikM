using eDnevnikM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eDnevnikM.Controllers
{
    public class GodineController : Controller
    {
        // GET: Godine
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetGodines()
        {
            using (DBModel dc = new DBModel())
            {
                dc.Configuration.LazyLoadingEnabled = false;
                var godines = dc.Godines.OrderBy(a => a.Opis).ToList();
                return Json(new { data = godines }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            using (DBModel dc = new DBModel())
            {
                var v = dc.Godines.Where(a => a.GodinaID == id).FirstOrDefault();
                return View(v);
            }
        }
        [HttpPost]
        public ActionResult Save(Godine god)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (DBModel dc = new DBModel())
                {
                    if (god.GodinaID > 0)
                    {
                        var v = dc.Godines.Where(a => a.GodinaID == god.GodinaID).FirstOrDefault();
                        if (v != null)
                        {
                            v.Opis = god.Opis;
                           

                        }
                    }
                    else
                    {
                        dc.Godines.Add(god);
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
                var v = dc.Godines.Where(a => a.GodinaID == id).FirstOrDefault();
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
        public ActionResult DeleteGodina(int id)
        {
            bool status = false;
            using (DBModel dc = new DBModel())

            {
                var v = dc.Godines.Where(a => a.GodinaID == id).FirstOrDefault();
                if (v != null)
                {
                    dc.Godines.Remove(v);
                    dc.SaveChanges();
                    status = true;


                }


            }

            return new JsonResult { Data = new { status = status } };
        }
    }
}