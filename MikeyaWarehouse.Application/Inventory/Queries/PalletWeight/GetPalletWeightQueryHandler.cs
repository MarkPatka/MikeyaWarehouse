using MediatR;
using MikeyaWarehouse.Application.Common.Interfaces;
using MikeyaWarehouse.Application.Inventory.Common;

namespace MikeyaWarehouse.Application.Inventory.Queries.PalletWeight;

public class GetPalletWeightQueryHandler
    : IQueryHandler<GetPalletWeightQuery, PalletsWeightResult>
{
    public Task<PalletsWeightResult> Handle(
        GetPalletWeightQuery request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
