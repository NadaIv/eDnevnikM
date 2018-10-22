using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace eDnevnikM.Models
{
	[MetadataType(typeof(PredmetiPodaci))]
	public partial class Predmeti
	{
	}
	public class PredmetiPodaci
	{

		[Required(AllowEmptyStrings = false, ErrorMessage = "Unesite predmet")]
		public string NazivPredmeta { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Unesite redosled")]
		public int Redosled { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Unesite tip ocene")]
		public string TipOcene { get; set; }
        public int ProfesorID { get; set; }
		public int GodinaID { get; set; }

	}
}