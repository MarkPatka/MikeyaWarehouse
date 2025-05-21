using MikeyaWarehouse.Domain.PalletAggregate;

namespace MikeyaWarehouse.Application.Inventory.Common;

public record PalletsExpiresResult(List<Pallet[]> Pallets);
