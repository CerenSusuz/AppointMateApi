using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AppointMateApi.Application.Common.Interfaces;
using AppointMateApi.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace AppointMateApi.Infrastructure.Data.Repository;
public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
    where TEntity : BaseAuditableEntity
    where TContext : DbContext
{
    protected readonly TContext _dbContext;

    private readonly DbSet<TEntity> _entities;

    public BaseRepository(TContext dbContext)
    {
        _dbContext = dbContext;
        _entities = _dbContext.Set<TEntity>();
    }

    public async Task<List<TEntity>> GetItemsAsync() =>
                await _entities.AsNoTracking().ToListAsync();

    public async Task<List<TEntity>> GetItemsAsync(
               Expression<Func<TEntity, bool>> expression,
               params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _entities.Where(expression).AsNoTracking();

        if (includes.Any())
        {
            query = includes
                .Aggregate(query,
                    (
                        current, includeProperty) => current.Include(includeProperty)
                );
        }

        return await query.ToListAsync();
    }

    public async Task<List<TEntity>> GetItemsAsync(params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _entities.AsNoTracking();
        if (includes.Any())
        {
            query = includes
                .Aggregate(query,
                    (
                        current, includeProperty) => current.Include(includeProperty)
                );
        }

        return await query.ToListAsync();
    }

    public async Task<int> CreateAsync(TEntity entity)
    {
        await _entities.AddAsync(entity);
        _dbContext.SaveChanges();

        return entity.Id;
    }

    public async Task Delete(Expression<Func<TEntity, bool>> expression)
    {
        _entities.RemoveRange(_entities.Where(expression));
       await _dbContext.SaveChangesAsync();
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
    {
        try
        {
            var query = _entities.Where(filter).AsNoTracking();
            if (includes.Any())
            {
                query = includes
                    .Aggregate(query,
                        (
                            current, includeProperty) => current.Include(includeProperty)
                    );
            }

            return await query.FirstAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Unable to find item in database. Error: {ex.Message}");
        }
    }

    public async Task Update(TEntity entity)
    {
        _entities.Update(entity);
       await _dbContext.SaveChangesAsync();
    }

    public async Task<List<TEntity>> GetItemsAsync(int limit) =>
        await _entities
            .Take(limit)
            .AsNoTracking()
            .ToListAsync();
}
