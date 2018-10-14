using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDnevnikM.Models
{
	[MetadataType(typeof(OcenePodaci))]
	public partial class Ocene
	{
	}
	public class OcenePodaci
	{

		[Required(AllowEmptyStrings = false, ErrorMessage = "Unesite ocenu")]
		public int Ocena { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Unesite opis ocene")]
		public string OpisOcene { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Unesite tip ocene")]
		public string TipOcene { get; set; }
		
	}
}