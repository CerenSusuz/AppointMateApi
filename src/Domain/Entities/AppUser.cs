using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMateApi.Domain.Entities;
public class AppUser: BaseAuditableEntity
{
    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public string? PhoneNumber { get; set; }

    public UserRole Role { get; set; }

    public ICollection<Appointment>? Appointments { get; set; }

    public ICollection<AppService>? Services { get; set; }

    public ICollection<Booking>? Bookings { get; set; }

    public ICollection<ServiceReview>? Reviews { get; set; }
}
