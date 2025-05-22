using MikeyaWarehouse.Domain.PalletAggregate;

namespace MikeyaWarehouse.Application.Common.Services;

public interface IPalletsManagementService
{
    //Сгруппировать все паллеты по сроку годности, отсортировать по возрастанию срока годности, в каждой группе отсортировать паллеты по весу

    /// <summary>
    /// Solves Tasks:
    /// <br />
    /// 1. Сгруппировать все паллеты по сроку годности;
    /// <br />
    /// 2. Отсортировать по возрастанию срока годности;
    /// <br />
    /// 3. В каждой группе отсортировать паллеты по весу.
    /// </summary>
    /// <param name="pallets">Unsorted batch of pallets</param>
    /// <param name="direction">Sorting direction. Allowed parameters: "ASC", "DESC"</param>
    /// <remarks>
    /// Ensure that the direction value is a one of two allowed options.
    /// </remarks>
    /// <returns>
    /// <br />Все паллеты сгруппированные по сроку годности; 
    /// <br />Все группы отсортированные по возрастанию срока годности;
    /// <br />В каждой группе паллеты отсортированы по весу.
    /// </returns>
    public Dictionary<DateOnly, List<Pallet>> GroupPalletsByExpirationDate(
        Pallet[] pallets, string direction = "ASC");

    /// <summary>
    /// <br />
    /// 1. Find the pallets of the largest expire date;
    /// <br />
    /// 2. Sorts them in an ascending order;
    /// </summary>
    /// <param name="pallets">Unsorted batch of pallets with a similar expire date</param>
    /// <param name="count">The number of pallets to return, sorted in ascending order by theirs volume</param>
    /// <returns>
    /// <br />"count" паллеты, которые содержат коробки с наибольшим сроком годности;
    /// <br />(Паллеты) отсортированные по возрастанию объема.
    /// </returns>
    public Pallet[] SortPalletsByExpirationDate(Pallet[] pallets, int count = 3);
}
