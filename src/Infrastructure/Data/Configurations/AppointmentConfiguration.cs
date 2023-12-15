using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointMateApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AppointMateApi.Infrastructure.Data.Configurations;
public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointments");

        builder.Property(appointment => appointment.Title).HasMaxLength(50).IsRequired();
        builder.Property(appointment => appointment.Description).HasMaxLength(200);
        builder.Property(appointment => appointment.AppointmentDate).IsRequired();
        builder.Property(appointment => appointment.StartTime).IsRequired();
        builder.Property(appointment => appointment.EndTime).IsRequired();
        builder.Property(appointment => appointment.Location).HasMaxLength(100);

        builder.HasOne(appointment => appointment.AppUser)
               .WithMany(user => user.Appointments)
               .HasForeignKey(appointment => appointment.AppUserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(appointment => appointment.AppService)
               .WithMany(service => service.Appointments)
               .HasForeignKey(appointment => appointment.AppServiceId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(appointment => appointment.AppointmentHistory)
               .WithOne(history => history.Appointment)
               .HasForeignKey<Appointment>(appointment => appointment.AppointmentHistoryId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
