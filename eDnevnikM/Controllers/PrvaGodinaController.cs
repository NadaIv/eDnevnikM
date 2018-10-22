using eDnevnikM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eDnevnikM.Controllers
{
    public class PrvaGodinaController : Controller
    {
		// GET: PrvaGodina
		public ActionResult ViewUcenici()

		{
			using (DBModel dc = new DBModel())
			{
				List<Ucenici> list = dc.Ucenicis.ToList();
				return PartialView("_UceniciList", list);
			}
			
		}
	}
}