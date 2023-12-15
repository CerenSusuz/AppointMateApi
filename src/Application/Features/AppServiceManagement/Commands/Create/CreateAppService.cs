using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointMateApi.Application.Common.Interfaces;
using AppointMateApi.Domain.Entities;
using AppointMateApi.Domain.Enums;
using Mapster;

namespace AppointMateApi.Application.Features.AppServiceManagement.Commands.Create;
public class CreateAppService : IRequest<int>
{
    public required string Name { get; set; }

    public required string Description { get; set; }

    public required string Address { get; set; }

    public int CityId { get; set; }

    public int DistrictId { get; set; }

    public int AppUserId { get; set; }

    //TODO:

    public ICollection<Appointment>? Appointments { get; set; }

    public ICollection<Booking>? Bookings { get; set; }

    public ICollection<ServiceReview>? Reviews { get; set; }
}

public class CreateAppServiceCommandHandler(IAppServiceRepository repository) : IRequestHandler<CreateAppService, int>
{
    public async Task<int> Handle(CreateAppService request, CancellationToken cancellationToken)
    {
        var dto = request.Adapt<AppService>();

        return await repository.CreateAsync(dto);
    }
}
