using HRPortal.Domain.Entities;
using HRPortal.Domain.Interfaces.IRepositories.IAppUserRepository;
using HRPortal.Persistence.Context.Data;
using HRPortal.Persistence.Repositories.GenericRepository.ReadRepository;

namespace HRPortal.Persistence.Repositories.Repositories.AppUserRepository;

public class ReadAppUserRepository : ReadGenericRepository<AppUser>, IReadAppUserRepository
{
    public ReadAppUserRepository(AppDbContext context) : base(context)
    {
    }
}
