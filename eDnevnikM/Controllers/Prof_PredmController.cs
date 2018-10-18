using eDnevnikM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eDnevnikM.Controllers
{
    public class Prof_PredmController : Controller
    {
        // GET: Prof_Predm
        public ActionResult Submit()
        {
            List<Profesori> allProfesori = new List<Profesori>();
            List<Predmeti> allPredmeti = new List<Predmeti>();
            using (DBModel dc = new DBModel())
            {
                allProfesori = dc.Profesoris.OrderBy(a => a.Ime).ToList();
            }
            ViewBag.ProfesorID = new SelectList(allProfesori, "ProfesorID", "Ime");
            ViewBag.PredmetID = new SelectList(allPredmeti, "PredmetID", "NazivPredmeta");
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Submit(Prof_Predm pp)
        {
            List<Profesori> allProfesori = new List<Profesori>();
            List<Predmeti> allPredmeti = new List<Predmeti>();

            using (DBModel dc = new DBModel())

            {
                allProfesori = dc.Profesoris.OrderBy(a => a.Ime).ToList();
                if (pp != null && pp.ProfesorID > 0)

                {
                    allPredmeti = dc.Predmetis.Where(a => a.ProfesorID.Equals(pp.ProfesorID)).OrderBy(a => a.NazivPredmeta).ToList();
                }

            }
            ViewBag.ProfesorID = new SelectList(allProfesori, "ProfesorID", "Ime", pp.ProfesorID);
            ViewBag.PredmetID = new SelectList(allPredmeti, "PredmetID", "NazivPredmeta", pp.PredmetID);

            if (ModelState.IsValid)
            {

                using (DBModel dc = new DBModel())
                {

                    dc.Prof_Predm.Add(pp);
                    dc.SaveChanges();
                    ModelState.Clear();
                    pp = null;

                    ViewBag.Message = "Odlicno";

                }

            }
            else
            {
                ViewBag.Message = "Successfully submitted";
            }
            return View(pp);
        }
        [HttpGet]
        public JsonResult GetProf_Predms(string profesorID = "")
        {
            List<Predmeti> allPredmeti = new List<Predmeti>();
            int ID = 0;
            if (int.TryParse(profesorID, out ID))
            {
                using (DBModel dc = new DBModel())
                {
                    allPredmeti = dc.Predmetis.Where(a => a.ProfesorID.Equals(ID)).OrderBy(a => a.NazivPredmeta).ToList();
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = allPredmeti,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                return new JsonResult
                {
                    Data = "Failed! Please try again",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };

            }
        }
    }
}


