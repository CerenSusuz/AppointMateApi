using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointMateApi.Application.Common.Interfaces;
using AppointMateApi.Domain.Entities;
using AppointMateApi.Domain.Enums;
using Mapster;

namespace AppointMateApi.Application.Features.BookingManagement.Commands.Create;
public class CreateBooking : IRequest<int>
{
    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public bool? IsConfirmed { get; set; }

    public bool? IsCancelled { get; set; }

    public string? Note { get; set; }

    public int AppServiceId { get; set; }

    public int AppUserId { get; set; }
}

public class CreateBookingCommandHandler(IBookingRepository repository) : IRequestHandler<CreateBooking, int>
{
    public async Task<int> Handle(CreateBooking request, CancellationToken cancellationToken)
    {
        var dto = request.Adapt<Booking>();

        return await repository.CreateAsync(dto);
    }
}
