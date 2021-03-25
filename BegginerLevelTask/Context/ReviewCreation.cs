//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BegginerLevelTask.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ReviewCreation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReviewCreation()
        {
            this.ReviewAssignments = new HashSet<ReviewAssignment>();
            this.ReviewSubmissions = new HashSet<ReviewSubmission>();
        }
    
        public long ReviewID { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string ReviewAgenda { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public Nullable<System.DateTime> ReviewCycleStartDate { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public Nullable<System.DateTime> ReviewCycleEndDate { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public Nullable<int> MinRate { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public Nullable<int> MaxRate { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string ReviewDescription { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<bool> ReviewStatus { get; set; }
    
        public virtual tbl_Organisation tbl_Organisation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReviewAssignment> ReviewAssignments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReviewSubmission> ReviewSubmissions { get; set; }
    }
}