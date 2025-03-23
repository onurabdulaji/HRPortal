using HRPortal.Domain.Interfaces.IBase;
using HRPortal.Domain.Interfaces.IGenericRepository.WriteGeneric;
using HRPortal.Persistence.Context.Data;
using Microsoft.EntityFrameworkCore;

namespace HRPortal.Persistence.Repositories.GenericRepository.WriteRepository;

public class WriteGenericRepository<T> : IWriteGenericRepository<T> where T : class, IBaseEntity, new()
{
    protected readonly AppDbContext _context;

    public WriteGenericRepository(AppDbContext context)
    {
        _context = context;
    }

    protected DbSet<T> Table { get => _context.Set<T>(); }

    public async Task AddEntitiesRangeAsync(IList<T> entities)
    {
        await Table.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public async Task AddEntityAsync(T entity)
    {
        await Table.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<(bool isSuccess, T entity)> ChangeEntityStatusAsync(T entity)
    {
        entity.Status = !entity.Status;
        Table.Update(entity);
        var result = await _context.SaveChangesAsync();
        return (result > 0, entity);
    }

    public async Task<T> RemoveEntityAsync(T entity)
    {
        Table.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateEntityAsync(T entity)
    {
        Table.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
