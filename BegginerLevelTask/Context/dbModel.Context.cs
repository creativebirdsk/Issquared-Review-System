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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BegginerLevelTaskEntities : DbContext
    {
        public BegginerLevelTaskEntities()
            : base("name=BegginerLevelTaskEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_Organisation> tbl_Organisation { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ReviewCreation> ReviewCreations { get; set; }
        public virtual DbSet<ReviewAssignment> ReviewAssignments { get; set; }
        public virtual DbSet<ReviewSubmission> ReviewSubmissions { get; set; }
        public virtual DbSet<SuperUser> SuperUsers { get; set; }
    }
}
