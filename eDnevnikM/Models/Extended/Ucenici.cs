using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDnevnikM.Models
{
    [MetadataType(typeof(UceniciPodaci))]
    public partial class Ucenici
    {
    }
    public class UceniciPodaci
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite odeljenje")]
        public int OdeljenjeID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite ime")]
        public string Ime { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite prezime")]
        public string Prezime { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite datum rodjenja")]
		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
		public DateTime DatumRodjenja { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite adresu")]
        public string Adresa { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite godinu upisa")]
		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
		public DateTime GodinaUpisa { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite redni broj u odeljenju")]
        public int RedBrUOdeljenju { get; set; }
       
       
        public string Lozinka { get; set; }



    }
}