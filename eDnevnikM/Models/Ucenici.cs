//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eDnevnikM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ucenici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ucenici()
        {
            this.Ocenjivanjes = new HashSet<Ocenjivanje>();
        }
    
        public int UcenikID { get; set; }
        public int OdeljenjeID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public System.DateTime DatumRodjenja { get; set; }

        public string Adresa { get; set; }
        public System.DateTime GodinaUpisa { get; set; }
        public int RedBrUOdeljenju { get; set; }
      
        public string Lozinka { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ocenjivanje> Ocenjivanjes { get; set; }
        public virtual Odeljenja Odeljenja { get; set; }
    }
}
