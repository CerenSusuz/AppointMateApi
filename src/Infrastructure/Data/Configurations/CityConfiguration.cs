using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointMateApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AppointMateApi.Infrastructure.Data.Configurations;
public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(city => city.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(city => city.Country)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasMany(city => city.Districts)
               .WithOne(district => district.City)
               .HasForeignKey(district => district.CityId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
