using HRPortal.Domain.Entities;
using HRPortal.Domain.Enums;
using HRPortal.Domain.Interfaces.IRepositories.IAppRoleRepository;
using HRPortal.Persistence.Context.Data;
using HRPortal.Persistence.Repositories.GenericRepository.WriteRepository;

namespace HRPortal.Persistence.Repositories.Repositories.AppRoleRepository;

public class WriteAppRoleRepository : WriteGenericRepository<AppRole>, IWriteAppRoleRepository
{
    public WriteAppRoleRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<AppRole> CreateRole(AppRole appRole)
    {
        if (!Enum.IsDefined(typeof(Roles), appRole.Roles))
        {
            throw new ArgumentException("Invalid role specified.");
        }
        await Table.AddAsync(appRole);
        await _context.SaveChangesAsync();
        return appRole;
    }
}
