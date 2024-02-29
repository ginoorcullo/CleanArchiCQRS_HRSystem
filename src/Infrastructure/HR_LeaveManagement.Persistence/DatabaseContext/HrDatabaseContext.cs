﻿using HR_LeaveManagement.Domain;
using HR_LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_LeaveManagement.Persistence.DatabaseContext {
    public class HrDatabaseContext: DbContext {
        public HrDatabaseContext(DbContextOptions<HrDatabaseContext> options): base(options) {
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity<int>>().Where(e => e.State == EntityState.Added || e.State ==EntityState.Modified)) {
                entry.Entity.DateModified = DateTime.Now;

                if(entry.State == EntityState.Added) {
                    entry.Entity.DateModified = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
