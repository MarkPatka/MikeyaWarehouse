using MediatR;

namespace MikeyaWarehouse.Application.Common.Interfaces;

public interface IQuery<out TResponse> 
    : IRequest<TResponse>
{
}
