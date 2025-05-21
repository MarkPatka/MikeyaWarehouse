using MikeyaWarehouse.Application.Common.Services;
using MikeyaWarehouse.Domain.PalletAggregate;
using MikeyaWarehouse.Infrastructure.Helpers;

namespace MikeyaWarehouse.Infrastructure.Services;

public class PalletsManagementService 
    : IPalletsManagementService
{
    public Dictionary<DateOnly, List<Pallet>> GroupPalletsByExpirationDate(
        Pallet[] pallets, string direction = "ASC")
    {
        // Getting keys for groups
        var elements = pallets
            .Select(p => p.Expires);
        
        // Distinct keys
        var unicDates = GenericAlgorithms
            .Distinct<DateOnly>(elements);

        // Sorting keys
        var comparer = GenericAlgorithms
            .GetComparer<DateOnly>(direction);

        GenericAlgorithms
            .InsertionSort<DateOnly>(unicDates, comparer);

        // Group pallets by keys
        Dictionary<DateOnly, List<Pallet>> groups = unicDates
            .ToDictionary(date => date, v => new List<Pallet>());

        for (int i = 0; i < pallets.Length; i++)
        {
            var palletsGroup = groups[pallets[i].Expires];
            palletsGroup.Add(pallets[i]);
        }

        foreach (var group in groups)
            SortPalletsByWeight([.. group.Value]);


        return groups;
    }

    public Pallet[] GetSortedPalletsWithTheBoxOfTheMostExpireDate(Pallet[] pallets, int count = 3)
    {
        Pallet[] result = new Pallet[count];
        
        if (pallets == null || pallets.Length == 0)
            return [];

        if (pallets.Length <= count)
            return [.. pallets.OrderByDescending(p => p.Dimensions.Volume)];

        int i = count;
        while (i > 0) 
        {
            result[count - 1] = pallets[count - 1];
            count--;
        }

        int minIndex = GetIndexPalletWithTheBoxOfMinExpireDate(result);
        DateOnly currentMinExpire = result[minIndex].Expires;

        for (; i < pallets.Length; i++)
        {
            DateOnly expire = pallets[i].GetMaxExpireDate();
            if (expire > currentMinExpire)
            {
                result[minIndex] = pallets[i];
                minIndex = GetIndexPalletWithTheBoxOfMinExpireDate(result);
                currentMinExpire = result[minIndex].Expires;
            }
        }

        return [.. result.OrderByDescending(p => p.Dimensions.Volume)];
    }
    private static int GetIndexPalletWithTheBoxOfMinExpireDate(Pallet[] pallets)
    {
        int min = 0;

        for (int i = 1; i < pallets.Length; i++)
        {
            if (pallets[i].Expires < pallets[min].Expires)
            {
                min = i;
            }
        }

        return min;
    }
    
    private static void SortPalletsByWeight(Pallet[] arr)
    {
        if (arr.Length <= 1) return;

        int mid = arr.Length / 2;
        Pallet[] left = new Pallet[mid];
        Pallet[] right = new Pallet[arr.Length - mid];

        Array.Copy(arr, 0, left, 0, mid);
        Array.Copy(arr, mid, right, 0, arr.Length - mid);

        SortPalletsByWeight(left);
        SortPalletsByWeight(right);
        MergeSortedByWeight(arr, left, right);
    }
    private static void MergeSortedByWeight(Pallet[] arr, Pallet[] left, Pallet[] right)
    {
        int i = 0, j = 0, k = 0;

        while (i < left.Length && j < right.Length)
        {
            if (left[i].Dimensions.Weight <= right[j].Dimensions.Weight)
                arr[k++] = left[i++];
            else
                arr[k++] = right[j++];
        }

        while (i < left.Length) arr[k++] = left[i++];
        while (j < right.Length) arr[k++] = right[j++];
    }
}
