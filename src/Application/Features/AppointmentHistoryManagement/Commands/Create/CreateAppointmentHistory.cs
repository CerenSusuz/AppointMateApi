using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointMateApi.Application.Common.Interfaces;
using AppointMateApi.Application.Features.AppointmentManagement.Commands.Create;
using AppointMateApi.Domain.Entities;
using AppointMateApi.Domain.Enums;
using Mapster;

namespace AppointMateApi.Application.Features.AppointmentHistoryManagement.Commands.Create;
public class CreateAppointmentHistory : IRequest<int>
{
    public AppointmentStatus Status { get; set; }

    public string? Note { get; set; }

    public DateTime ModifiedDate { get; set; }

    public int ModifiedByAppUserId { get; set; }

    public int AppointmentId { get; set; }
}

public class CreateAppointmentHistoryCommandHandler(IAppointmentHistoryRepository repository) : IRequestHandler<CreateAppointmentHistory, int>
{
    public async Task<int> Handle(CreateAppointmentHistory request, CancellationToken cancellationToken)
    {
        var dto = request.Adapt<AppointmentHistory>();

        return await repository.CreateAsync(dto);
    }
}
