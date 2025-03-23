using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HRPortal.Application.Extensions;

public static class MediatRExtension
{
    public static void AddMediatorExtension(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}
