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
    
    public partial class patientsattachments
    {
        public int patientsattachments_id { get; set; }
        public int patients_id { get; set; }
        public int patientsattachmentstypes_id { get; set; }
        public string patientsattachments_value { get; set; }
        public System.DateTime patientsattachments_date { get; set; }
        public string patientsattachments_filename { get; set; }
        public string patientsattachments_note { get; set; }
    
        public virtual patients patients { get; set; }
        public virtual patientsattachmentstypes patientsattachmentstypes { get; set; }
    }
}
