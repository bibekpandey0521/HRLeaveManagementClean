using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Domain.Common;
using HR.LeaveManagement.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Persistence.DatabaseContext
{
    public class HrDatabaseContext : DbContext
    {
        public HrDatabaseContext(DbContextOptions<HrDatabaseContext> options) : base(options)
        {
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDatabaseContext).Assembly);
            modelBuilder.ApplyConfiguration(new LeaveTypeConfiguration());
            //modelBuilder.Entity<LeaveType>().HasData(
            //    new LeaveType
            //    {
            //        Id = 1,
            //        Name = "Vacation",
            //        DefaultDays = 10,
            //        DateCreated = DateTime.Now,
            //        DateModified = DateTime.Now
            //    });
            
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
