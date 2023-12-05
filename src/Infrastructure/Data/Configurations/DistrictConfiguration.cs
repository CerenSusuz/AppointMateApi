using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointMateApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AppointMateApi.Infrastructure.Data.Configurations;
public class DistrictConfiguration : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        builder.ToTable("Districts");

        builder.HasKey(district => district.Id);
        builder.Property(district => district.Id).ValueGeneratedOnAdd();

        builder.Property(district => district.Name).IsRequired().HasMaxLength(100);

        builder.HasOne(district => district.City)
            .WithMany(city => city.Districts)
            .HasForeignKey(district => district.CityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
