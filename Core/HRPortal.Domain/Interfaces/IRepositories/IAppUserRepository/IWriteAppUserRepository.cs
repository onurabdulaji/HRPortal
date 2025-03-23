using HRPortal.Domain.Entities;
using HRPortal.Domain.Interfaces.IGenericRepository.WriteGeneric;

namespace HRPortal.Domain.Interfaces.IRepositories.IAppUserRepository;

public interface IWriteAppUserRepository : IWriteGenericRepository<AppUser>
{
}