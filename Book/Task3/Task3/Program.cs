using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = {8, 2, 3, 6, 1, 9 };
            int[] array2 = { 8, 2, 3, 6, 1, 9 };

            Sort sort = new BubbleSort();
            sort.Sort(array1);
            sort = new SortByInserts();
            sort.Sort(array2);

            for (int i = 0; i < array1.Length; i++)
            {
                Console.Write(array1[i] + " ");
            }

            Console.WriteLine();
            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write(array2[i] + " ");
            }
        }
    }
}
