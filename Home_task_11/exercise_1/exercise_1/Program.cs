namespace exercise_1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //Checking the operation of the algorithm on the array of int

            int[] arr1 = { 9, 2, 5, 4, 7, 1, 8, 3, 6, 4 };
            int[] arr2 = { 9, 2, 5, 4, 7, 1, 8, 3, 6, 4 };
            int[] arr3 = { 9, 2, 5, 4, 7, 1, 8, 3, 6, 4 };
            int[] arr4 = { 9, 2, 5, 4, 7, 1, 8, 3, 6, 4 };
            Console.WriteLine("Unsorted array:");
            QuickSort.PrintArray(arr1);

            // Quick Sort using the first element as the pivot
            Console.WriteLine("Sorted array using the first element as the pivot:");
            QuickSortGeneric<int>.QuickSortAlgorithm(arr1, 0, arr1.Length - 1, PivotType.First);
            
            QuickSort.PrintArray(arr1);

            // Quick Sort using an arbitrary element as the pivot
            Console.WriteLine("Sorted array using an arbitrary element as the pivot:");
            QuickSortGeneric<int>.QuickSortAlgorithm(arr2, 0, arr2.Length - 1, PivotType.Arbitrary);
            
            QuickSort.PrintArray(arr2);

            // Quick Sort using the median element as the pivot
            Console.WriteLine("Sorted array using the median element as the pivot:");
            QuickSortGeneric<int>.QuickSortAlgorithm(arr3, 0, arr3.Length - 1, PivotType.Median);
            
            QuickSort.PrintArray(arr3);

            // Quick Sort using the end element as the pivot
            Console.WriteLine("Sorted array using the median element as the pivot:");
            QuickSortGeneric<int>.QuickSortAlgorithm(arr4, 0, arr4.Length - 1, PivotType.End);
            
            QuickSort.PrintArray(arr4);


            //Checking the operation of the algorithm on the array of object that implement IComparable interface

            Console.WriteLine("Sorting with Generic type algorithm\n");

            Person[] personArray1 = new Person[]
            {
                new Person("Anton", 22),
                new Person("Oleg", 5),
                new Person("Victor", 45),
                new Person("Olga", 41),
                new Person("Tatyana", 33),
                new Person("Boris", 17),
                new Person("Kaban", 99),
                new Person("Baran", 17),
            };
            Console.WriteLine("Unsorted array:");
            QuickSortGeneric<Person>.PrintArray(personArray1);

            Console.WriteLine("Sorted array using the first element as the pivot:");
            QuickSortGeneric<Person>.QuickSortAlgorithm(personArray1, 0, personArray1.Length - 1, PivotType.Arbitrary);
            
            QuickSortGeneric<Person>.PrintArray(personArray1);

            Person[] personArray2 = new Person[]
            {
                new Person("Anton", 22),
                new Person("Oleg", 5),
                new Person("Victor", 45),
                new Person("Olga", 41),
                new Person("Tatyana", 33),
                new Person("Boris", 17),
                new Person("Kaban", 99),
                new Person("Baran", 17),
            };

            Console.WriteLine("Sorted array using the median element as the pivot:");
            QuickSortGeneric<Person>.QuickSortAlgorithm(personArray2, 0, personArray2.Length - 1, PivotType.Median);
            
            QuickSortGeneric<Person>.PrintArray(personArray2);
        }
    }
}
