using Domain.Exceptions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Base;

public class ServiceHandlerDecorator<TRequest, TResponse> : IServiceHandler<TRequest, TResponse>
{
    private readonly IServiceHandler<TRequest, TResponse> _inner;
    private readonly IValidator<TRequest>? _validator;

    public ServiceHandlerDecorator(
        IServiceHandler<TRequest, TResponse> inner,
        IServiceProvider provider)
    {
        _inner = inner;
        _validator = provider.GetService<IValidator<TRequest>>();
    }

    public async Task<TResponse> Handle(TRequest request)
    {
        if (_validator is null)
        {
            return await _inner.Handle(request);
        }

        var validationResult = await _validator.ValidateAsync(request);

        if (validationResult.IsValid)
        {
            return await _inner.Handle(request);
        }

        var errors = validationResult.Errors
            .Select(validationFailure => $"Propriedade: {validationFailure.PropertyName} - Erro: {validationFailure.ErrorMessage}")
            .ToList();

        var message = string.Join(Environment.NewLine, errors);

        throw new BadRequestException(message);
    }
}
