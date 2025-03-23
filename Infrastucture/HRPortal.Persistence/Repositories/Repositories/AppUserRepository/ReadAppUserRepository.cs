using HRPortal.Domain.Entities;
using HRPortal.Domain.Interfaces.IRepositories.IAppUserRepository;
using HRPortal.Persistence.Context.Data;
using HRPortal.Persistence.Repositories.GenericRepository.ReadRepository;
using Microsoft.EntityFrameworkCore;

namespace HRPortal.Persistence.Repositories.Repositories.AppUserRepository;

public class ReadAppUserRepository : ReadGenericRepository<AppUser>, IReadAppUserRepository
{
    public ReadAppUserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IList<AppUser>> GetAllActiveAsync(bool trackChanges = false, bool isStatusActive = true, CancellationToken cancellationToken = default)
    {
        IQueryable<AppUser> query = Table.Where(u => u.Status == isStatusActive);

        if (!trackChanges) query = query.AsNoTracking();

        return await query.ToListAsync(cancellationToken);

    }

    public async Task<IList<AppUser>> GetAllAsync(bool trackChanges = false, CancellationToken cancellationToken = default)
    {
        IQueryable<AppUser> query = Table;

        if (!trackChanges) query = query.AsNoTracking();
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<AppUser> GetByIdActiveAsync(Guid id, bool trackChanges = false, bool isStatusActive = true, CancellationToken cancellationToken = default)
    {
        IQueryable<AppUser> query = Table.Where(u => u.Id == id && u.Status == isStatusActive);

        if (!trackChanges) query = query.AsNoTracking();

        return await query.FirstAsync(cancellationToken);

    }

    public async Task<AppUser> GetByIdAsync(Guid id, bool trackChanges = false, CancellationToken cancellationToken = default)
    {
        IQueryable<AppUser> query = Table.Where(u => u.Id == id);

        if (!trackChanges) query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IList<AppUser>> GetUsersByFilterAsync(string userName = null, string email = null, int pageNumber = 1, int pageSize = 10, bool trackChanges = false, CancellationToken cancellationToken = default)
    {
        IQueryable<AppUser> query = Table;

        if (!string.IsNullOrEmpty(userName)) query = Table.Where(u => u.UserName.Contains(userName));

        if (!string.IsNullOrEmpty(email)) query = Table.Where(u => u.Email.Contains(email));

        if (!trackChanges) query = Table.AsNoTracking();

        return await query.Skip((pageSize - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
    }
}
