using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMateApi.Domain.Entities;
public class City : BaseAuditableEntity
{
    public required string Name { get; set; }

    public required string Country { get; set; }

    public ICollection<District>? Districts { get; set; }

    public ICollection<AppService>? Services { get; set; }
}
