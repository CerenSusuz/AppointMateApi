using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointMateApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointMateApi.Infrastructure.Data.Configurations;
public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable("Services");

        builder.HasOne(service => service.City)
            .WithMany(city => city.Services)
            .HasForeignKey(service => service.CityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(service => service.District)
            .WithMany(district => district.Services)
            .HasForeignKey(service => service.DistrictId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(service => service.Owner)
            .WithMany(user => user.Services)
            .HasForeignKey(service => service.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
