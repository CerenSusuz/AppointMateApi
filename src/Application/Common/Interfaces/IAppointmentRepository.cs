using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointMateApi.Domain.Entities;

namespace AppointMateApi.Application.Common.Interfaces;
public interface IAppointmentRepository : IBaseRepository<Appointment>
{
}
