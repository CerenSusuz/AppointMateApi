using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMateApi.Domain.Entities;
public class Booking : BaseAuditableEntity
{
    public Booking()
    {
        IsConfirmed = false;
        IsCancelled = false;
    }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public bool? IsConfirmed { get; set; }

    public bool? IsCancelled { get; set; }

    public string? Note { get; set; }

    public int AppServiceId { get; set; }

    public required AppService AppService { get; set; }

    public int AppUserId { get; set; }

    public required AppUser AppUser { get; set; }
}
