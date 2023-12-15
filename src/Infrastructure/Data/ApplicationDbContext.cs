using System.Reflection;
using System.Reflection.Emit;
using AppointMateApi.Application.Common.Interfaces;
using AppointMateApi.Domain.Entities;
using AppointMateApi.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppointMateApi.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Appointment> Appointments => Set<Appointment>();

    public DbSet<AppointmentHistory> AppointmentHistories => Set<AppointmentHistory>();

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    public DbSet<TodoList> TodoLists => Set<TodoList>();

    public DbSet<AppService> AppServices => Set<AppService>();

    public DbSet<AppUser> AppUsers => Set <AppUser>();

    public DbSet<Booking> Bookings => Set<Booking>();

    public DbSet<City> Cities => Set<City>();

    public DbSet<District> Districts => Set<District>();

    public DbSet<ServiceReview> ServiceReviews => Set<ServiceReview>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
