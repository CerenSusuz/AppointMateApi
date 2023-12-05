using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMateApi.Domain.Entities;

public class Appointment : BaseAuditableEntity
{
    public required string Title { get; set; }

    public required string Description { get; set; }

    public DateTime AppointmentDate { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string? Location { get; set; }

    public string? Note { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }

    public int ServiceId { get; set; }

    public Service Service { get; set; }

    public int? AppointmentHistoryId { get; set; }

    public AppointmentHistory? AppointmentHistory { get; set; }
}
