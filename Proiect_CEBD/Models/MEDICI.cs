//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proiect_CEBD.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MEDICI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MEDICI()
        {
            this.PROGRAMARIs = new HashSet<PROGRAMARI>();
        }
    
        public short ID_MEDIC { get; set; }
        public string NUME { get; set; }
        public string PRENUME { get; set; }
        public string TELEFON { get; set; }
        public string PARAFA_MEDIC { get; set; }
        public short SPECIALIZARI_ID { get; set; }
    
        public virtual SPECIALIZARI SPECIALIZARI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROGRAMARI> PROGRAMARIs { get; set; }
    }
}
