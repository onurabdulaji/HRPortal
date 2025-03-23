using HRPortal.Application.Interfaces.Managers.AppRoleManager;
using HRPortal.Application.Interfaces.Managers.AppUserManager;
using HRPortal.Application.Interfaces.Managers.EmployeeManager;
using HRPortal.Application.Interfaces.Services.AppRoleService;
using HRPortal.Application.Interfaces.Services.AppUserService;
using HRPortal.Application.Interfaces.Services.EmployeeService;
using Microsoft.Extensions.DependencyInjection;

namespace HRPortal.Application.Extensions;

public static class ServiceManagerExtensions
{
    public static void AddServiceAndManagersExtensions(this IServiceCollection services)
    {
        services.AddScoped<IReadAppRoleService, ReadAppRoleManager>();
        services.AddScoped<IWriteAppRoleService, WriteAppRoleManager>();

        services.AddScoped<IReadAppUserService, ReadAppUserManager>();
        services.AddScoped<IWriteAppUserService, WriteAppUserManager>();

        services.AddScoped<IReadEmployeeService, ReadEmployeeManager>();
        services.AddScoped<IWriteEmployeeService, WriteEmployeeManager>();
    }
}
