using MediatR;
using MikeyaWarehouse.Application.Common.Interfaces;
using MikeyaWarehouse.Application.Inventory.Common;

namespace MikeyaWarehouse.Application.Inventory.Queries.PalletExpires;

public class GetPalletExpiresQueryHandler
    : IQueryHandler<GetPalletExpiresQuery, PalletsExpiresResult>
{
    public Task<PalletsExpiresResult> Handle(
        GetPalletExpiresQuery request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
