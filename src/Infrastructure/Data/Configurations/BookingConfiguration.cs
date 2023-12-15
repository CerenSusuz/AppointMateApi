using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointMateApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AppointMateApi.Infrastructure.Data.Configurations;
public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Bookings");

        builder.Property(booking => booking.StartDateTime)
            .IsRequired();

        builder.Property(booking => booking.EndDateTime)
            .IsRequired();

        builder.Property(booking => booking.IsConfirmed)
            .HasDefaultValue(false);

        builder.Property(booking => booking.IsCancelled)
            .HasDefaultValue(false);

        builder.Property(booking => booking.Note)
            .HasMaxLength(500);

        builder.HasOne(booking => booking.AppUser)
            .WithMany(user => user.Bookings)
            .HasForeignKey(booking => booking.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(booking => booking.AppService)
            .WithMany(service => service.Bookings)
            .HasForeignKey(booking => booking.AppServiceId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
