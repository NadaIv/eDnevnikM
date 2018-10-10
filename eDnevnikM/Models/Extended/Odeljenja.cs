using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Web;

namespace eDnevnikM.Models
{
    [MetadataType(typeof(OdeljenjaPodaci))]
    public partial class Odeljenja
    {
    }
    public class OdeljenjaPodaci
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite godinu")]
        public List<Godine> GodinaID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite broj odeljenja")]
        public string BrojOdeljenja { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite godinu upisa")]
        public string GodinaUpisa { get; set; }
        
    }
}