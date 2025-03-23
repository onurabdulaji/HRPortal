using HRPortal.Domain.Entities;
using HRPortal.Domain.Interfaces.IRepositories.IAppUserRepository;
using HRPortal.Persistence.Context.Data;
using HRPortal.Persistence.Repositories.GenericRepository.WriteRepository;

namespace HRPortal.Persistence.Repositories.Repositories.AppUserRepository;

public class WriteAppUserRepository : WriteGenericRepository<AppUser>, IWriteAppUserRepository
{
    public WriteAppUserRepository(AppDbContext context) : base(context)
    {
    }
}
