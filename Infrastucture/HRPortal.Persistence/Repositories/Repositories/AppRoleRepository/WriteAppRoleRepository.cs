using HRPortal.Domain.Entities;
using HRPortal.Domain.Interfaces.IRepositories.IAppRoleRepository;
using HRPortal.Persistence.Context.Data;
using HRPortal.Persistence.Repositories.GenericRepository.WriteRepository;

namespace HRPortal.Persistence.Repositories.Repositories.AppRoleRepository;

public class WriteAppRoleRepository : WriteGenericRepository<AppRole>, IWriteAppRoleRepository
{
    public WriteAppRoleRepository(AppDbContext context) : base(context)
    {
    }
}
