using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointMateApi.Application.Common.Interfaces;
using AppointMateApi.Application.Features.AppointmentHistoryManagement.Commands.Create;
using AppointMateApi.Domain.Entities;
using AppointMateApi.Domain.Enums;
using Mapster;

namespace AppointMateApi.Application.Features.AppUserManagement.Commands.Create;
public class CreateAppUser : IRequest<int>
{
    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public string? PhoneNumber { get; set; }

    public UserRole Role { get; set; }

    public ICollection<Appointment>? Appointments { get; set; }

    public ICollection<AppService>? Services { get; set; }

    public ICollection<Booking>? Bookings { get; set; }

    public ICollection<ServiceReview>? Reviews { get; set; }
}

public class CreateAppUserCommandHandler(IAppUserRepository repository) : IRequestHandler<CreateAppUser, int>
{
    public async Task<int> Handle(CreateAppUser request, CancellationToken cancellationToken)
    {
        var dto = request.Adapt<AppUser>();

        return await repository.CreateAsync(dto);
    }
}
