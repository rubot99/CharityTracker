﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CharityTracker
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CharityTrackerEntities : DbContext
    {
        public CharityTrackerEntities()
            : base("name=CharityTrackerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<vwActivity> vwActivities { get; set; }
        public DbSet<vwActivitiesByType> vwActivitiesByTypes { get; set; }
        public DbSet<vwActivitiesByUser> vwActivitiesByUsers { get; set; }
        public DbSet<vwGetUser> vwGetUsers { get; set; }
    }
}
