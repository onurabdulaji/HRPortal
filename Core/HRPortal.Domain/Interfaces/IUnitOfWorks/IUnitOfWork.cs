using HRPortal.Domain.Interfaces.IBase;
using HRPortal.Domain.Interfaces.IGenericRepository.ReadGeneric;
using HRPortal.Domain.Interfaces.IGenericRepository.WriteGeneric;
using HRPortal.Domain.Interfaces.IRepositories.IAppRoleRepository;
using HRPortal.Domain.Interfaces.IRepositories.IAppUserRepository;
using HRPortal.Domain.Interfaces.IRepositories.IEmployeeRepository;

namespace HRPortal.Domain.Interfaces.IUnitOfWorks;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    IReadGenericRepository<T> GetReadGenericRepository<T>() where T : class, IBaseEntity, new();
    IWriteGenericRepository<T> GetWriteGenericRepository<T>() where T : class, IBaseEntity, new();
    Task<int> SaveAsync();
    IReadAppRoleRepository TGetReadAppRoleRepository();
    IWriteAppRoleRepository TGetWriteAppRoleRepository();
    IReadAppUserRepository TGetReadAppUserRepository();
    IWriteAppUserRepository TGetWriteAppUserRepository();
    IReadEmployeeRepository TGetReadEmployeeRepository();
    IWriteEmployeeRepository TGetWriteEmployeeRepository();

}
