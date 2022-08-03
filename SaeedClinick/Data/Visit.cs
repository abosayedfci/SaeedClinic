//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SaeedClinick.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Visit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Visit()
        {
            this.VisitLabs = new HashSet<VisitLab>();
            this.VisitTreatments = new HashSet<VisitTreatment>();
            this.VisitUS = new HashSet<VisitU>();
        }
        [Key]
        public int Id { get; set; }
        public int VisitNum { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<System.DateTime> NextVisitDate { get; set; }
        [DisplayName("Treatments")]
        public string BP { get; set; }
        [DisplayName("Labs")]
        public string LL { get; set; }
        public Nullable<double> Weight { get; set; }
        public string Complain { get; set; }
        [DisplayName("US")]
        public string Others { get; set; }
        [ForeignKey("PatientData")]
        public int PatientID { get; set; }
    
        public virtual PatientData PatientData { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VisitLab> VisitLabs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VisitTreatment> VisitTreatments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VisitU> VisitUS { get; set; }

    }
}
