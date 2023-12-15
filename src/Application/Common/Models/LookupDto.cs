using AppointMateApi.Domain.Entities;

namespace AppointMateApi.Application.Common.Models;

public class LookupDto
{
    public int Id { get; init; }

    public string? Title { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TodoList, LookupDto>();
            CreateMap<TodoItem, LookupDto>();
            CreateMap<Appointment, LookupDto>();
            CreateMap<AppointmentHistory, LookupDto>();
            CreateMap<AppService, LookupDto>();
            CreateMap<AppUser, LookupDto>();
            CreateMap<Booking, LookupDto>();
            CreateMap<City, LookupDto>();
            CreateMap<District, LookupDto>();
            CreateMap<ServiceReview, LookupDto>();
        }
    }
}
