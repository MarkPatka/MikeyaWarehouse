using MediatR;
using MikeyaWarehouse.Application.Common.Interfaces;
using MikeyaWarehouse.Application.Inventory.Common;

namespace MikeyaWarehouse.Application.Inventory.Queries.PalletVolume;

public class GetPalletVolumeQueryHandler
    : IQueryHandler<GetPalletVolumeQuery, PalletsVolumeResult>
{
    public Task<PalletsVolumeResult> Handle(
        GetPalletVolumeQuery request, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
