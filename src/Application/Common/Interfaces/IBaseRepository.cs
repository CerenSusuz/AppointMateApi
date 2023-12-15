using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AppointMateApi.Domain.Common;

namespace AppointMateApi.Application.Common.Interfaces;
public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity
{
    Task<List<TEntity>> GetItemsAsync();

    Task<List<TEntity>> GetItemsAsync(
            Expression<Func<TEntity, bool>> expression,
            params Expression<Func<TEntity, object>>[] includes);

    Task<List<TEntity>> GetItemsAsync(
            params Expression<Func<TEntity, object>>[] includes);

    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] includes);

    Task<List<TEntity>> GetItemsAsync(int limit);

    Task<int> CreateAsync(TEntity entity);

    Task Update(TEntity entity);

    Task Delete(Expression<Func<TEntity, bool>> expression);
}
