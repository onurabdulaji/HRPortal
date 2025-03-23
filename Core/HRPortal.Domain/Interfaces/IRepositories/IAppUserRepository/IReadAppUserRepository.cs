using HRPortal.Domain.Entities;
using HRPortal.Domain.Interfaces.IGenericRepository.ReadGeneric;

namespace HRPortal.Domain.Interfaces.IRepositories.IAppUserRepository;

public interface IReadAppUserRepository : IReadGenericRepository<AppUser>
{
    Task<IList<AppUser>> GetAllAsync(bool trackChanges = false, CancellationToken cancellationToken = default);
    Task<IList<AppUser>> GetAllActiveAsync(bool trackChanges = false, bool isStatusActive = true, CancellationToken cancellationToken = default);
    Task<AppUser> GetByIdActiveAsync(Guid id, bool trackChanges = false, bool isStatusActive = true, CancellationToken cancellationToken = default);
    Task<AppUser> GetByIdAsync(Guid id, bool trackChanges = false, CancellationToken cancellationToken = default);
    Task<IList<AppUser>> GetUsersByFilterAsync(string userName = null, string email = null, int pageNumber = 1, int pageSize = 10, bool trackChanges = false, CancellationToken cancellationToken = default);

}
