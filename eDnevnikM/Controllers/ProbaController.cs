using eDnevnikM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eDnevnikM.Controllers
{
    public class ProbaController : Controller
    {
        // GET: Proba
        DBModel dc = new DBModel();
        public ActionResult Index()
        {
            List<Profesori> allProfesori = dc.Profesoris.ToList();
            ViewBag.allProfesori = new SelectList(allProfesori, "ProfesorID", "Ime");
            return View();
        }

        public JsonResult GetProfs(int profesorID)
        {
            dc.Configuration.ProxyCreationEnabled = false;
            List<Predmeti> allPredmeti = dc.Predmetis.Where(a => a.ProfesorID == profesorID).ToList();
            return Json(allPredmeti, JsonRequestBehavior.AllowGet);

        }
    }
}