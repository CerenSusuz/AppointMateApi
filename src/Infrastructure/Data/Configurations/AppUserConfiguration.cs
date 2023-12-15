using AppointMateApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointMateApi.Infrastructure.Data.Configurations
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");

            builder.Property(user => user.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(user => user.LastName).IsRequired().HasMaxLength(50);
            builder.Property(user => user.Email).IsRequired().HasMaxLength(100);
            builder.Property(user => user.Password).IsRequired();
            builder.Property(user => user.PhoneNumber).HasMaxLength(20);

            builder.HasMany(user => user.Appointments)
                   .WithOne(appointment => appointment.AppUser)
                   .HasForeignKey(appointment => appointment.AppUserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(user => user.Services)
                   .WithOne(service => service.AppUser)
                   .HasForeignKey(service => service.AppUserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(user => user.Bookings)
                   .WithOne(booking => booking.AppUser)
                   .HasForeignKey(booking => booking.AppUserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(user => user.Reviews)
                   .WithOne(review => review.AppUser)
                   .HasForeignKey(review => review.AppUserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
