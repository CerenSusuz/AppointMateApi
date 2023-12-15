using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointMateApi.Application.Common.Interfaces;
using AppointMateApi.Domain.Entities;

namespace AppointMateApi.Infrastructure.Data.Repository;
public class AppServiceRepository(ApplicationDbContext dbContext) :
    BaseRepository<AppService, ApplicationDbContext>(dbContext), IAppServiceRepository
{
}
