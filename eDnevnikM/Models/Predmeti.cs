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
    
    public partial class Predmeti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Predmeti()
        {
            this.Ocenjivanjes = new HashSet<Ocenjivanje>();
            this.Prof_Predm = new HashSet<Prof_Predm>();
        }
    
        public int PredmetID { get; set; }
        public string NazivPredmeta { get; set; }
        public int Redosled { get; set; }
        public string TipOcene { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ocenjivanje> Ocenjivanjes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prof_Predm> Prof_Predm { get; set; }
    }
}