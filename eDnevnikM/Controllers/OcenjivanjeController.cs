using eDnevnikM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eDnevnikM.Controllers
{
    public class OcenjivanjeController : Controller
    {
        // GET: Ocenjivanje
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetOcenjivanjes()
        {
            using (DBModel dc = new DBModel())
            {
                dc.Configuration.LazyLoadingEnabled = false;
                var ocenj = dc.Ocenjivanjes.OrderBy(a => a.OcenjivanjeID).ToList();
                return Json(new { data = ocenj }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult Save(int id)
        {
            List<Predmeti> allPredmeti = new List<Predmeti>();
            List<Ucenici> allUcenici = new List<Ucenici>();
            List<Ocene> allOcene = new List<Ocene>();

            using (DBModel dc = new DBModel())
            {
                allPredmeti = dc.Predmetis.OrderBy(a => a.NazivPredmeta).ToList();
                allUcenici = dc.Ucenicis.OrderBy(a => a.Ime).ToList();
                allOcene = dc.Ocenes.OrderBy(a => a.Ocena).ToList();

            }
            ViewBag.PredmetID = new SelectList(allPredmeti, "PredmetID", "NazivPredmeta");
            ViewBag.UcenikID = new SelectList(allUcenici, "UcenikID", "Ime");
            ViewBag.OcenaID = new SelectList(allOcene, "OcenaID", "Ocena");

            return View();
        }
        [HttpPost]
        public ActionResult Save(Ocenjivanje ocenj)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (DBModel dc = new DBModel())
                {
                    if (ocenj.OcenjivanjeID > 0)
                    {
                        var v = dc.Ocenjivanjes.Where(a => a.OcenjivanjeID == ocenj.OcenjivanjeID).FirstOrDefault();
                        if (v != null)
                        {
                            v.PredmetID = ocenj.PredmetID;
                            v.UcenikID = ocenj.UcenikID;
                            v.OcenaID = ocenj.OcenaID;
                            v.DatumOcenj = ocenj.DatumOcenj;
                            v.Komentar = ocenj.Komentar;
                            


                        }
                    }
                    else
                    {
                        dc.Ocenjivanjes.Add(ocenj);
                    }

                    dc.SaveChanges();
                    status = true;

                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}