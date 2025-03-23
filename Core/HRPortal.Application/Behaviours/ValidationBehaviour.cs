using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HRPortal.Application.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly ILogger<ValidationBehaviour<TRequest, TResponse>> _logger;
    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidationBehaviour<TRequest, TResponse>> logger)
    {
        _validators = validators ?? throw new ArgumentNullException(nameof(validators));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationFailures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .GroupBy(x => x.ErrorMessage)
            .Select(x => x.First())
            .Where(f => f != null)
            .ToList();

        if (validationFailures.Any())
        {
            var errorMessages = string.Join(", ", validationFailures.Select(e => e.ErrorMessage));
            _logger.LogWarning("Validation failed for request {RequestName}: {ErrorMessages}", typeof(TRequest).Name, errorMessages);
            throw new ValidationException($"Validation failed for {typeof(TRequest).Name}: {errorMessages}");
        }

        return await next();
    }
}
