namespace MikeyaWarehouse.Infrastructure.Helpers;

public static class GenericAlgorithms
{
    public static IEnumerable<T> Distinct<T>(IEnumerable<T> elements)
    {
        HashSet<T> dates = [];
        List<T> unicDates = [];
        var enumerator = elements.GetEnumerator();
        while (enumerator.MoveNext())
        {
            if (dates.Add(enumerator.Current))
            {
                unicDates.Add(enumerator.Current);
            }
        }
        return unicDates;
    }

    public static void InsertionSort<T>(
        IEnumerable<T> unicDates, Comparison<T> comparer)
        where T : IComparable
    {
        var list = unicDates.ToList();
        int n = list.Count;
        for (int i = 1; i < n; i++)
        {
            T target = list[i];
            int j = i - 1;

            while (j >= 0 && comparer(list[j], target) > 0)
            {
                list[j + 1] = list[j];
                j--;
            }

            list[j + 1] = target;
        }
    }

    public static Comparison<T> GetComparer<T>(string direction = "ASC")
        where T : IComparable
    {
        Comparison<T> comparer;

        if (string.Equals(direction, "ASC", StringComparison.OrdinalIgnoreCase))
        {
            comparer = (x, y) => x.CompareTo(y);
        }
        else if (string.Equals(direction, "DESC", StringComparison.OrdinalIgnoreCase))
        {
            comparer = (x, y) => y.CompareTo(x);
        }
        else throw new ArgumentException("Invalid direction");


        return comparer;
    }


    public static void MergeSort<T>(T[] array, string direction = "ASC")
        where T : IComparable
    {
        if (array == null || array.Length <= 1)
            return;
        
        T[] temp = new T[array.Length];
        Sort<T>(array, temp, 0, array.Length - 1, GetComparer<T>(direction));
    }





    private static void Sort<T>(
        T[] array, T[] temp, int left, int right, Comparison<T> comparer)
        where T : IComparable
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;

            Sort(array, temp, left, mid, comparer);
            Sort(array, temp, mid + 1, right, comparer);

            Merge(array, temp, left, mid, right, comparer);
        }
    }

    private static void Merge<T>(
        T[] array, T[] temp, 
        int left, int mid, int right, 
        Comparison<T> comparer)
        where T : IComparable
    {
        for (int i = left; i <= right; i++)
        {
            temp[i] = array[i];
        }

        int leftStart = left;
        int rightStart = mid + 1; 
        int current = left;

        while (leftStart <= mid && rightStart <= right)
        {
            if (comparer(temp[leftStart], temp[rightStart]) <= 0)
            {
                array[current] = temp[leftStart];
                leftStart++;
            }
            else
            {
                array[current] = temp[rightStart];
                rightStart++;
            }
            current++;
        }

        while (leftStart <= mid)
        {
            array[current] = temp[leftStart];
            current++;
            leftStart++;
        }
    }
}
