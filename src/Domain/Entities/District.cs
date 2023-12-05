using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointMateApi.Domain.Entities;
public class District : BaseAuditableEntity
{
    public required string Name { get; set; }

    public int CityId { get; set; }

    public required City City { get; set; }

    public ICollection<Service>? Services { get; set; }
}
