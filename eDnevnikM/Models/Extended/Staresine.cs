using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDnevnikM.Models
{
	[MetadataType(typeof(StaresinePodaci))]
	public partial class Staresine
	{
	}
	public class StaresinePodaci
	{

		[Required(AllowEmptyStrings = false, ErrorMessage = "Unesite profesora")]
		public int ProfesorID { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Unesite odeljenje")]
		public string OdeljenjeID { get; set; }



	}
}