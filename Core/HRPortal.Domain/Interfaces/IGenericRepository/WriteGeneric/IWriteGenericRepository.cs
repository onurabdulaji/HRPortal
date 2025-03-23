using HRPortal.Domain.Interfaces.IBase;
using System.Security.Principal;

namespace HRPortal.Domain.Interfaces.IGenericRepository.WriteGeneric;

public interface IWriteGenericRepository<T> where T : class, IBaseEntity, new()
{
    Task AddEntityAsync(T entity);
    Task AddEntitiesRangeAsync(IList<T> entities);
    Task<T> UpdateEntityAsync(T entity);
    Task<T> RemoveEntityAsync(T entity);
    Task<(bool isSuccess, T entity)> ChangeEntityStatusAsync(T entity);
}
