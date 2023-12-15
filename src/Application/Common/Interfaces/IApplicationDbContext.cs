using AppointMateApi.Domain.Entities;

namespace AppointMateApi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Appointment> Appointments { get; }

    DbSet<AppointmentHistory> AppointmentHistories { get; }

    DbSet<AppService> AppServices { get; }

    DbSet<AppUser> AppUsers { get; }

    DbSet<Booking> Bookings { get; }

    DbSet<City> Cities { get; }

    DbSet<District> Districts { get; }

    DbSet<ServiceReview> ServiceReviews { get; }

    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
