using MikeyaWarehouse.Contracts.DTO;
using MikeyaWarehouse.Domain.ContractorsAggregate;

namespace MikeyaWarehouse.Application.Common.Persistence;

public interface IContractorsRepository : IGenericRepository<Contractor>
{
    public Task<IEnumerable<ShipmentModel>> GetShipmentsWithContractorsAsync();
    
}
