using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMateApi.Domain.Entities;
public class ServiceReview : BaseAuditableEntity
{
    public required string Title { get; set; }

    public string? Comment { get; set; }

    public int Rating { get; set; }

    public int AppServiceId { get; set; }

    public required AppService AppService { get; set; }

    public int AppUserId { get; set; }

    public required AppUser AppUser { get; set; }
}
