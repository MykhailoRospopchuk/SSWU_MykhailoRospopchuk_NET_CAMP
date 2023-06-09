//Class that implements quicksort for Generic classes with ability choice pivot element
namespace exercise_1
{

    internal static class QuickSortGeneric<T> where T : IComparable
    {
        public static void QuickSortAlgorithm(T[] arr, int low, int high, PivotType pivotType)
        {
            if (low < high)
            {
                int pivotIndex;

                switch (pivotType)
                {
                    case PivotType.First:
                        pivotIndex = low;
                        break;
                    case PivotType.Arbitrary:
                        pivotIndex = new Random().Next(low, high + 1);
                        break;
                    case PivotType.Median:
                        pivotIndex = GetMedianIndex(arr, low, high);
                        break;
                    case PivotType.End:
                        pivotIndex = high;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(pivotType), pivotType, "Invalid pivot type.");
                }

                // Partition the array
                int pivotFinalIndex = Partition(arr, low, high, pivotIndex);

                // Recursive calls for the sub-arrays
                QuickSortAlgorithm(arr, low, pivotFinalIndex - 1, pivotType);
                QuickSortAlgorithm(arr, pivotFinalIndex + 1, high, pivotType);
            }
        }

        static int Partition(T[] arr, int low, int high, int pivotIndex)
        {
            T pivotValue = arr[pivotIndex];
            Swap(arr, pivotIndex, high);
            int i = low;

            for (int j = low; j < high; j++)
            {
                if (arr[j].CompareTo(pivotValue) < 0)
                {
                    Swap(arr, i, j);
                    i++;
                }
            }

            Swap(arr, i, high);
            return i;
        }

        static int GetMedianIndex(T[] arr, int low, int high)
        {
            int mid = (low + high) / 2;

            if (arr[low].CompareTo(arr[mid]) <= 0)
            {
                if (arr[mid].CompareTo(arr[high]) <= 0)
                    return mid;
                else if (arr[low].CompareTo(arr[high]) <= 0)
                    return high;
                else
                    return low;
            }
            else
            {
                if (arr[low].CompareTo(arr[high]) <= 0)
                    return low;
                else if (arr[mid].CompareTo(arr[high]) <= 0)
                    return high;
                else
                    return mid;
            }
        }

        static void Swap(T[] arr, int i, int j)
        {
            T temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static void PrintArray(T[] arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
