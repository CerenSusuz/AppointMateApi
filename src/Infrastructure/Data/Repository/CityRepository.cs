using AppointMateApi.Application.Common.Interfaces;
using AppointMateApi.Domain.Entities;

namespace AppointMateApi.Infrastructure.Data.Repository
{
    public class CityRepository(ApplicationDbContext dbContext) : 
        BaseRepository<City, ApplicationDbContext>(dbContext), ICityRepository
    {
    }
}
