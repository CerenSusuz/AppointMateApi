using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointMateApi.Application.Common.Interfaces;
using AppointMateApi.Domain.Entities;
using Mapster;

namespace AppointMateApi.Application.Features.ServiceReviewManagement.Commands.Create;
public class CreateServiceReview : IRequest<int>
{
    public required string Title { get; set; }

    public string? Comment { get; set; }

    public int Rating { get; set; }

    public int AppServiceId { get; set; }

    public int AppUserId { get; set; }
}

public class CreateDistrictCommandHandler(IServiceReviewRepository repository) : IRequestHandler<CreateServiceReview, int>
{
    public async Task<int> Handle(CreateServiceReview request, CancellationToken cancellationToken)
    {
        var dto = request.Adapt<ServiceReview>();

        return await repository.CreateAsync(dto);
    }
}
