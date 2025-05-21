using MediatR;

namespace MikeyaWarehouse.Application.Common.Interfaces;

public interface ICommand<out TResponse> 
    : IRequest<TResponse>
{
}
