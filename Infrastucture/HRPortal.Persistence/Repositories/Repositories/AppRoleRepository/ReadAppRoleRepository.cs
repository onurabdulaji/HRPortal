using HRPortal.Domain.Entities;
using HRPortal.Domain.Interfaces.IRepositories.IAppRoleRepository;
using HRPortal.Persistence.Context.Data;
using HRPortal.Persistence.Repositories.GenericRepository.ReadRepository;

namespace HRPortal.Persistence.Repositories.Repositories.AppRoleRepository;

public class ReadAppRoleRepository : ReadGenericRepository<AppRole>, IReadAppRoleRepository
{
    public ReadAppRoleRepository(AppDbContext context) : base(context)
    {
    }
}
