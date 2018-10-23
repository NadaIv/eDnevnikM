using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDnevnikM.Models
{
	[MetadataType(typeof(ProfesoriPodaci))]
	public partial class Profesori
	{
	}
	public class ProfesoriPodaci
	{

		[Required(AllowEmptyStrings = false, ErrorMessage = "Unesite ime")]
		public string Ime { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Unesite prezime")]
		public string Prezime { get; set; }
        [DisplayName("Korisnicko ime:     ")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "Unesite korisnicko ime")]
		public string KorisnickoIme { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Unesite lozinku")]
        [DisplayName("Lozinka:")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Lozinka { get; set; }
        [DisplayName("Status:")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesi status")]
		public string Status { get; set; }
		public string LoginErrorMessage { get; set; }
	}
}