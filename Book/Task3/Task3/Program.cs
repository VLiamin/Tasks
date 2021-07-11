using System;

namespace Task3
{
    class Program
    {
        protected Program()
        {

        }
        static void Main(string[] args)
        {
            int[] array1 = {8, 2, 3, 6, 1, 9 };
            int[] array2 = { 8, 2, 3, 6, 1, 9 };

            Sort sort = new BubbleSort();
            sort.Sort(array1);
            sort = new SortByInserts();
            sort.Sort(array2);
        }
    }
}
