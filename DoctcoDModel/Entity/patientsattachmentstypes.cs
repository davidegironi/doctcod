//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DG.DoctcoD.Model.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class patientsattachmentstypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public patientsattachmentstypes()
        {
            this.patientsattachments = new HashSet<patientsattachments>();
        }
    
        public int patientsattachmentstypes_id { get; set; }
        public string patientsattachmentstypes_name { get; set; }
        public string patientsattachmentstypes_valueautofunc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<patientsattachments> patientsattachments { get; set; }
    }
}
