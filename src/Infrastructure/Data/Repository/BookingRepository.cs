using AppointMateApi.Application.Common.Interfaces;
using AppointMateApi.Domain.Entities;

namespace AppointMateApi.Infrastructure.Data.Repository
{
    public class BookingRepository(ApplicationDbContext dbContext) : 
        BaseRepository<Booking, ApplicationDbContext>(dbContext), IBookingRepository
    {
    }
}
