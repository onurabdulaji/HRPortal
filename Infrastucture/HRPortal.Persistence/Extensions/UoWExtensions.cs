using HRPortal.Domain.Interfaces.IUnitOfWorks;
using HRPortal.Persistence.Repositories.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace HRPortal.Persistence.Extensions;

public static class UoWExtensions
{
    public static void AddUnitOfWorkExtension(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}