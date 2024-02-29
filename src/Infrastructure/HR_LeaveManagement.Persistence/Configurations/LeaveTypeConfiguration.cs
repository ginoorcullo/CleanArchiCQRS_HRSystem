﻿using HR_LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_LeaveManagement.Persistence.Configurations {
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType> {
        public void Configure(EntityTypeBuilder<LeaveType> builder) {

            builder.HasData(
                    new LeaveType {
                        Id = 1,
                        Name = "Vacation",
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        DefaultDays = 10
                    }
                );

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
