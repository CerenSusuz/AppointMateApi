using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointMateApi.Application.Common.Interfaces;
using AppointMateApi.Domain.Entities;
using Mapster;

namespace AppointMateApi.Application.Features.DistrictManagement.Commands.Create;
public class CreateDistrict: IRequest<int>
{
    public required string Name { get; set; }

    public int CityId { get; set; }

    //TODO:

    public ICollection<AppService>? Services { get; set; }
}

public class CreateDistrictCommandHandler(IDistrictRepository repository) : IRequestHandler<CreateDistrict, int>
{
    public async Task<int> Handle(CreateDistrict request, CancellationToken cancellationToken)
    {
        var dto = request.Adapt<District>();

        return await repository.CreateAsync(dto);
    }
}
