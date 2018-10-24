using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDnevnikM.Models.Extended
{
    public partial class Ocenjivanje
    {
        public string NazivPredmeta { get; set; }
        public string OpisOcene { get; set; }
    }
    public class PodaciOcenjivanje
    {
        [Required(ErrorMessage = "Contact Name required", AllowEmptyStrings = false)]
        [Display(Name = "Ucenik")]
        public string UcenikID { get; set; }

        [Required(ErrorMessage = "Contact No required", AllowEmptyStrings = false)]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Country required")]
        [Display(Name = "Country")]
        public int CountryID { get; set; }

        [Required(ErrorMessage = "State required")]
        [Display(Name = "State")]
        public int StateID { get; set; }
    }
}