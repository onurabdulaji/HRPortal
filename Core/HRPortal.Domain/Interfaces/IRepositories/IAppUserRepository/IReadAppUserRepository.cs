using HRPortal.Domain.Entities;
using HRPortal.Domain.Interfaces.IGenericRepository.ReadGeneric;

namespace HRPortal.Domain.Interfaces.IRepositories.IAppUserRepository;

public interface IReadAppUserRepository : IReadGenericRepository<AppUser>
{
}
