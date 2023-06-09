//Class that implements quicksort for int type array with ability choice pivot element
namespace exercise_1
{

    internal static class QuickSort
    {
        public static void QuickSortAlgorithm(int[] arr, int low, int high, PivotType pivotType)
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

        static int Partition(int[] arr, int low, int high, int pivotIndex)
        {
            int pivotValue = arr[pivotIndex];
            Swap(arr, pivotIndex, high);
            int i = low;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivotValue)
                {
                    Swap(arr, i, j);
                    i++;
                }
            }

            Swap(arr, i, high);
            return i;
        }

        static int GetMedianIndex(int[] arr, int low, int high)
        {
            int mid = (low + high) / 2;

            if (arr[low] <= arr[mid])
            {
                if (arr[mid] <= arr[high])
                    return mid;
                else if (arr[low] <= arr[high])
                    return high;
                else
                    return low;
            }
            else
            {
                if (arr[low] <= arr[high])
                    return low;
                else if (arr[mid] <= arr[high])
                    return high;
                else
                    return mid;
            }
        }

        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        public static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }

}
