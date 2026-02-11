namespace Application.Base;

public interface IServiceHandler<TRequest, TResponse>
{
    Task<TResponse> Handle(TRequest request);
}