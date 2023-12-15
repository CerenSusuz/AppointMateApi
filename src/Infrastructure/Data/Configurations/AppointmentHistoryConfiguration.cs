using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointMateApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AppointMateApi.Infrastructure.Data.Configurations;
public class AppointmentHistoryConfiguration : IEntityTypeConfiguration<AppointmentHistory>
{
    public void Configure(EntityTypeBuilder<AppointmentHistory> builder)
    {
        builder.ToTable("AppointmentHistories");

        builder.Property(history => history.Status).IsRequired();
        builder.Property(history => history.Note).HasMaxLength(500);
        builder.Property(history => history.ModifiedDate).IsRequired();

        builder.HasOne(history => history.ModifiedByAppUser)
               .WithMany()
               .HasForeignKey(history => history.ModifiedByAppUserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(history => history.Appointment)
               .WithOne(appointment => appointment.AppointmentHistory)
               .HasForeignKey<AppointmentHistory>(history => history.AppointmentId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
