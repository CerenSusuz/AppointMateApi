﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMateApi.Domain.Entities;

public class AppointmentHistory : BaseAuditableEntity
{
    public AppointmentStatus Status { get; set; }

    public string? Note { get; set; }

    public DateTime ModifiedDate { get; set; }

    public int ModifiedByAppUserId { get; set; }

    public required AppUser ModifiedByAppUser { get; set; }

    public int AppointmentId { get; set; }

    public required Appointment Appointment { get; set; }
}
