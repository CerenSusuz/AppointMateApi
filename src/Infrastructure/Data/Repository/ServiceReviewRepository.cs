using AppointMateApi.Application.Common.Interfaces;
using AppointMateApi.Domain.Entities;

namespace AppointMateApi.Infrastructure.Data.Repository
{
    public class ServiceReviewRepository(ApplicationDbContext dbContext) : 
        BaseRepository<ServiceReview, ApplicationDbContext>(dbContext), IServiceReviewRepository
    {
    }
}
