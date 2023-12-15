using AppointMateApi.Application.Common.Interfaces;
using AppointMateApi.Domain.Entities;

namespace AppointMateApi.Infrastructure.Data.Repository
{
    public class DistrictRepository(ApplicationDbContext dbContext) : 
        BaseRepository<District, ApplicationDbContext>(dbContext), IDistrictRepository
    {
    }
}
