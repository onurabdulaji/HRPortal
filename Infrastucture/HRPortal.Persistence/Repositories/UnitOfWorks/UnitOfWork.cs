using HRPortal.Domain.Interfaces.IBase;
using HRPortal.Domain.Interfaces.IGenericRepository.ReadGeneric;
using HRPortal.Domain.Interfaces.IGenericRepository.WriteGeneric;
using HRPortal.Domain.Interfaces.IRepositories.IAppRoleRepository;
using HRPortal.Domain.Interfaces.IRepositories.IAppUserRepository;
using HRPortal.Domain.Interfaces.IRepositories.IEmployeeRepository;
using HRPortal.Domain.Interfaces.IUnitOfWorks;
using HRPortal.Persistence.Context.Data;
using HRPortal.Persistence.Repositories.GenericRepository.ReadRepository;
using HRPortal.Persistence.Repositories.GenericRepository.WriteRepository;
using HRPortal.Persistence.Repositories.Repositories.AppRoleRepository;
using HRPortal.Persistence.Repositories.Repositories.AppUserRepository;

namespace HRPortal.Persistence.Repositories.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    protected readonly AppDbContext _context;
    protected readonly Dictionary<Type, object> _repositories = new(); // Singleton Pattern

    IReadAppRoleRepository IUnitOfWork.TGetReadAppRoleRepository => throw new NotImplementedException();

    IWriteAppRoleRepository IUnitOfWork.TGetWriteAppRoleRepository => GetOrCreateRepository<IWriteAppRoleRepository, WriteAppRoleRepository>();

    IReadAppUserRepository IUnitOfWork.TGetReadAppUserRepository => throw new NotImplementedException();

    IWriteAppUserRepository IUnitOfWork.TGetWriteAppUserRepository =>  GetOrCreateRepository<IWriteAppUserRepository, WriteAppUserRepository>();

    IReadEmployeeRepository IUnitOfWork.TGetReadEmployeeRepository => throw new NotImplementedException();

    IWriteEmployeeRepository IUnitOfWork.TGetWriteEmployeeRepository => throw new NotImplementedException();

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    private TRepo GetOrCreateRepository<TInterface, TRepo>() where TRepo : class, TInterface
    {
        if (!_repositories.TryGetValue(typeof(TRepo), out var repo))
        {
            repo = Activator.CreateInstance(typeof(TRepo), _context);
            _repositories[typeof(TInterface)] = repo;
        }
        return (TRepo)repo;
    }

    public IReadGenericRepository<T> GetReadGenericRepository<T>()
        where T : class, IBaseEntity, new()
    {
        return GetOrCreateRepository<IReadGenericRepository<T>, ReadGenericRepository<T>>();
    }

    public IWriteGenericRepository<T> GetWriteGenericRepository<T>()
       where T : class, IBaseEntity, new()
    {
        return GetOrCreateRepository<IWriteGenericRepository<T>, WriteGenericRepository<T>>();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _context.DisposeAsync();
    }

    public async Task<int> SaveAsync()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Database CRUD Error : {ex.Message}");
        }

    }
}
