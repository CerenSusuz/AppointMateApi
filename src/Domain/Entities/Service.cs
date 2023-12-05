using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMateApi.Domain.Entities;
public class Service
{
    public required string Name { get; set; }

    public required string Description { get; set; }

    public required string Address { get; set; }

    public int CityId { get; set; }

    public required City City { get; set; }

    public int DistrictId { get; set; }

    public District? District { get; set; }

    public int OwnerId { get; set; }

    public User Owner { get; set; }

    public ICollection<Appointment>? Appointments { get; set; }

    public ICollection<Booking>? Bookings { get; set; }

    public ICollection<ServiceReview>? Reviews { get; set; }
}
