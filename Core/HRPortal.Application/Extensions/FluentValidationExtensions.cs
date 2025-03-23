using FluentValidation;
using HRPortal.Application.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HRPortal.Application.Extensions;

public static class FluentValidationExtensions
{
    public static void AddFluentValidationExtension(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        //services.AddScoped<IValidatorService, ValidatorService>();

        //services.AddScoped<IValidator<CreateAboutDto>, CreateAboutValidator>();
        //services.AddScoped<IValidator<UpdateAboutDto>, UpdateAboutValidator>();

    }
}
