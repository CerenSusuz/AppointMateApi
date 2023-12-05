using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMateApi.Domain.Entities;
public class ServiceReview
{
    public required string Title { get; set; }

    public string? Comment { get; set; }

    public int Rating { get; set; }

    public int ServiceId { get; set; }

    public required Service Service { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }
}
