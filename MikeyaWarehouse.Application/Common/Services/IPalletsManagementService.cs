using MikeyaWarehouse.Domain.PalletAggregate;

namespace MikeyaWarehouse.Application.Common.Services;

public interface IPalletsManagementService
{
    //Сгруппировать все паллеты по сроку годности, отсортировать по возрастанию срока годности, в каждой группе отсортировать паллеты по весу
    public Dictionary<DateOnly, List<Pallet>> GroupPalletsByExpirationDate(
        Pallet[] pallets, string direction = "ASC");
    //3 паллеты, которые содержат коробки с наибольшим сроком годности, отсортированные по возрастанию объема
    public Pallet[] GetSortedPalletsWithTheBoxOfTheMostExpireDate(Pallet[] pallets, int count = 3);
}
