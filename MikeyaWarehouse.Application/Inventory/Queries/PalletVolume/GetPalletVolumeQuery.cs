using MediatR;
using MikeyaWarehouse.Application.Common.Interfaces;
using MikeyaWarehouse.Application.Inventory.Common;
using MikeyaWarehouse.Domain.PalletAggregate;

namespace MikeyaWarehouse.Application.Inventory.Queries.PalletVolume;

public record GetPalletVolumeQuery(Pallet[] Pallets, string Direction = "ACS")
    : IQuery<PalletsVolumeResult>;
