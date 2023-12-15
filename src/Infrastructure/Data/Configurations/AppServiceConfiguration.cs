using AppointMateApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointMateApi.Infrastructure.Data.Configurations
{
    public class AppServiceConfiguration : IEntityTypeConfiguration<AppService>
    {
        public void Configure(EntityTypeBuilder<AppService> builder)
        {
            builder.ToTable("AppServices");

            builder.Property(service => service.Name).IsRequired().HasMaxLength(50);
            builder.Property(service => service.Description).IsRequired().HasMaxLength(200);
            builder.Property(service => service.Address).IsRequired().HasMaxLength(100);

            builder.HasOne(service => service.City)
                   .WithMany(city => city.Services)
                   .HasForeignKey(service => service.CityId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(service => service.District)
                   .WithMany(district => district.Services)
                   .HasForeignKey(service => service.DistrictId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(service => service.AppUser)
                   .WithMany(user => user.Services)
                   .HasForeignKey(service => service.AppUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(service => service.Appointments)
                   .WithOne(appointment => appointment.AppService)
                   .HasForeignKey(appointment => appointment.AppServiceId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(service => service.Bookings)
                   .WithOne(booking => booking.AppService)
                   .HasForeignKey(booking => booking.AppServiceId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(service => service.Reviews)
                   .WithOne(review => review.AppService)
                   .HasForeignKey(review => review.AppServiceId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
