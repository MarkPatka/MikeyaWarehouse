using MediatR;
using MikeyaWarehouse.Application.Common.Interfaces;
using MikeyaWarehouse.Application.Inventory.Common;
using MikeyaWarehouse.Domain.PalletAggregate;

namespace MikeyaWarehouse.Application.Inventory.Queries.PalletExpires;

public record GetPalletExpiresQuery(Pallet[] Pallets,  string Direction = "ACS")
    : IQuery<PalletsExpiresResult>;
