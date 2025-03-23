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

namespace HRPortal.Persistence.Repositories.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    protected readonly AppDbContext _context;
    protected readonly Dictionary<Type, object> _repositories = new(); // Singleton Pattern

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

    public IReadAppRoleRepository TGetReadAppRoleRepository()
    {
        throw new NotImplementedException();
    }

    public IWriteAppRoleRepository TGetWriteAppRoleRepository()
    {
        throw new NotImplementedException();
    }

    public IReadAppUserRepository TGetReadAppUserRepository()
    {
        throw new NotImplementedException();
    }

    public IWriteAppUserRepository TGetWriteAppUserRepository()
    {
        throw new NotImplementedException();
    }

    public IReadEmployeeRepository TGetReadEmployeeRepository()
    {
        throw new NotImplementedException();
    }

    public IWriteEmployeeRepository TGetWriteEmployeeRepository()
    {
        throw new NotImplementedException();
    }
}
