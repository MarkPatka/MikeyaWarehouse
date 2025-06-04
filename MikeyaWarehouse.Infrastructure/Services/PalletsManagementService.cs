using MikeyaWarehouse.Application.Common.Services;
using MikeyaWarehouse.Domain.Common.Extensions;
using MikeyaWarehouse.Domain.PalletAggregate;
using MikeyaWarehouse.Infrastructure.Helpers;

namespace MikeyaWarehouse.Infrastructure.Services;

public class PalletsManagementService : IPalletsManagementService
{
    public Dictionary<DateOnly, List<Pallet>> GroupPalletsByExpirationDate(
        Pallet[] pallets, string direction = "ASC")
    {

        /// VAR 1
        //var result = pallets
        //    .GroupBy(p => p.Expires)
        //    .OrderBy(p => p.Key)
        //    .ToDictionary(
        //        k => k.Key,
        //        v => v.Select(p => p)
        //              .OrderBy(p => p.Dimensions.Weight));

        /// VAR 2
        // Getting keys for groups
        var elements = pallets
            .Select(p => p.Expires);
        
        // Distinct keys
        var unicDates = GenericAlgorithms
            .Distinct<DateOnly>(elements);

        // Sorting keys
        var sortedDates = GenericAlgorithms
            .InsertionSort<DateOnly>(unicDates, direction);

        // Group pallets by keys
        Dictionary<DateOnly, List<Pallet>> groups = sortedDates
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

    public Pallet[] SortPalletsByExpirationDate(
        Pallet[] pallets, int count = 3)
    {
        Pallet[] result = new Pallet[count];
        
        if (pallets == null || pallets.Length == 0)
            return [];

        if (pallets.Length <= count)
            return [.. pallets.OrderBy(p => p.Dimensions.Volume)];
        
        // init first n elements as they`re presented in the initial array
        int i = count;
        while (i > 0) 
        {
            i--;
            result[i] = pallets[i];
        }

        // get the index of the min element from the max elements array (by expire date)
        int minIndex = GetIndexPalletWithTheBoxOfMinExpireDate(result);
        DateOnly currentMinExpire = result[minIndex].Expires;

        for (; i < pallets.Length; i++)
        {
            // if current pallet expire > current min (from max elements) expire replace it
            DateOnly expire = PalletExtensions.GetMaxExpireDate(pallets[i]);
            if (expire > currentMinExpire)
            {
                result[minIndex] = pallets[i];
                // update min value from the result collection
                minIndex = GetIndexPalletWithTheBoxOfMinExpireDate(result);
                currentMinExpire = result[minIndex].Expires;
            }
        }
        // to avoid overhead of separate sorting algorithms
        return [.. result.OrderBy(p => p.Dimensions.Volume)];
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
