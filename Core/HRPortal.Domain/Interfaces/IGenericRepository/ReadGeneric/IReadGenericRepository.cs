using HRPortal.Domain.Interfaces.IBase;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace HRPortal.Domain.Interfaces.IGenericRepository.ReadGeneric;

public interface IReadGenericRepository<T> where T : class, IBaseEntity, new()
{
    Task<IList<T>> GetAllEntitiesAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false);

    Task<T> GetEntityAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false);
    Task<int> CountEntitiesAsync(Expression<Func<T, bool>>? predicate = null);
    IQueryable<T> FindEntity(Expression<Func<T, bool>> predicate, bool enableTracking = false);
}



