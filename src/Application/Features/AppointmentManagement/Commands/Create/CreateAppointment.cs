using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointMateApi.Application.Common.Interfaces;
using AppointMateApi.Domain.Entities;
using Mapster;

namespace AppointMateApi.Application.Features.AppointmentManagement.Commands.Create;
public record CreateAppointment : IRequest<int>
{
    public required string Title { get; set; }

    public required string Description { get; set; }

    public DateTime AppointmentDate { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string? Location { get; set; }

    public string? Note { get; set; }

    public int AppUserId { get; set; }

    public int AppServiceId { get; set; }

    public int? AppointmentHistoryId { get; set; }
}

public class CreateAppointmentCommandHandler(IAppointmentRepository repository) : IRequestHandler<CreateAppointment, int>
{
    public async Task<int> Handle(CreateAppointment request, CancellationToken cancellationToken)
    {
        var dto = request.Adapt<Appointment>();

        return await repository.CreateAsync(dto);
    }
}
