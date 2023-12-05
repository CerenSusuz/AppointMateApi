using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointMateApi.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AppointMateApi.Infrastructure.Data.Configurations;
public class ServiceReviewConfiguration : IEntityTypeConfiguration<ServiceReview>
{
    public void Configure(EntityTypeBuilder<ServiceReview> builder)
    {
        builder.ToTable("ServiceReviews");

        builder.Property(review => review.Title).IsRequired().HasMaxLength(50);
        builder.Property(review => review.Comment).IsRequired().HasMaxLength(250);
        builder.Property(review => review.Rating).IsRequired();

        builder.HasOne(review => review.Service)
            .WithMany(service => service.Reviews)
            .HasForeignKey(review => review.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(review => review.AppUser)
            .WithMany(user => user.Reviews)
            .HasForeignKey(review => review.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
