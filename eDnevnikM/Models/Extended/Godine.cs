using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDnevnikM.Models

    {
	[MetadataType(typeof(GodinePodaci))]
    public partial class Godine
    {
    }
    public class GodinePodaci
    {
       

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite opis")]
        public string Opis { get; set; }
        
    }
}
