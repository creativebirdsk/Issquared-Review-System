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
    
    public partial class ReviewAssignment
    {
        public Nullable<long> ReviewID { get; set; }
        public Nullable<long> EmployeeID { get; set; }
        public Nullable<long> Reviewer { get; set; }
        public Nullable<int> UserID { get; set; }
        public long ReviewAssignmentID { get; set; }
        public Nullable<bool> AssignmentStatus { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Employee Employee1 { get; set; }
        public virtual ReviewCreation ReviewCreation { get; set; }
        public virtual tbl_Organisation tbl_Organisation { get; set; }
    }
}