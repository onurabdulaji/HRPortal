using HRPortal.Domain.Interfaces.IGenericRepository.ReadGeneric;
using HRPortal.Domain.Interfaces.IGenericRepository.WriteGeneric;
using HRPortal.Persistence.Repositories.GenericRepository.ReadRepository;
using HRPortal.Persistence.Repositories.GenericRepository.WriteRepository;
using Microsoft.Extensions.DependencyInjection;

namespace HRPortal.Persistence.Extensions;

public static class GenericRepositoryExtensions
{
    public static void AddGenericRepositoryPatternExtension(this IServiceCollection services)
    {
        services.AddScoped(typeof(IReadGenericRepository<>), typeof(ReadGenericRepository<>));
        services.AddScoped(typeof(IWriteGenericRepository<>), typeof(WriteGenericRepository<>));
    }
}
