﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AG04.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Ag04Entities : DbContext
    {
        public Ag04Entities()
            : base("name=Ag04Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblHeist> tblHeist { get; set; }
        public virtual DbSet<tblHeistSkills> tblHeistSkills { get; set; }
        public virtual DbSet<tblMember> tblMember { get; set; }
        public virtual DbSet<tblMemberSkills> tblMemberSkills { get; set; }
    }
}
