using MediatR;
using MikeyaWarehouse.Application.Common.Interfaces;
using MikeyaWarehouse.Application.Inventory.Common;
using MikeyaWarehouse.Domain.PalletAggregate;

namespace MikeyaWarehouse.Application.Inventory.Queries.PalletWeight;

public record GetPalletWeightQuery(Pallet[] Pallets, string Direction = "ASC")
    : IQuery<PalletsWeightResult>;
