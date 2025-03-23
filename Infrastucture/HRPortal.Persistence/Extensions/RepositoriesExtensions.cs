using HRPortal.Domain.Interfaces.IRepositories.IAppRoleRepository;
using HRPortal.Domain.Interfaces.IRepositories.IAppUserRepository;
using HRPortal.Domain.Interfaces.IRepositories.IEmployeeRepository;
using HRPortal.Persistence.Repositories.Repositories.AppRoleRepository;
using HRPortal.Persistence.Repositories.Repositories.AppUserRepository;
using HRPortal.Persistence.Repositories.Repositories.EmployeeRepository;
using Microsoft.Extensions.DependencyInjection;

namespace HRPortal.Persistence.Extensions;

public static class RepositoriesExtensions
{
    public static void AddRepositoriesExtension(this IServiceCollection services)
    {
        services.AddScoped<IReadAppRoleRepository, ReadAppRoleRepository>();
        services.AddScoped<IWriteAppRoleRepository, WriteAppRoleRepository>();

        services.AddScoped<IReadAppUserRepository, ReadAppUserRepository>();
        services.AddScoped<IWriteAppUserRepository, WriteAppUserRepository>();

        services.AddScoped<IReadEmployeeRepository, ReadEmployeeRepository>();
        services.AddScoped<IWriteEmployeeRepository, WriteEmployeeRepository>();
    }
}
