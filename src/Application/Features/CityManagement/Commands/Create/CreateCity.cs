using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointMateApi.Application.Common.Interfaces;
using AppointMateApi.Domain.Entities;
using Mapster;

namespace AppointMateApi.Application.Features.CityManagement.Commands.Create;
public class CreateCity : IRequest<int>
{
    public required string Name { get; set; }

    public required string Country { get; set; }

    //TODO:

    public ICollection<District>? Districts { get; set; }

    public ICollection<AppService>? Services { get; set; }
}

public class CreateCityCommandHandler(ICityRepository repository) : IRequestHandler<CreateCity, int>
{
    public async Task<int> Handle(CreateCity request, CancellationToken cancellationToken)
    {
        var dto = request.Adapt<City>();

        return await repository.CreateAsync(dto);
    }
}
