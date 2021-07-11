using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class SortByInserts : Sort
    {
        public void Sort(int[] array)
        {
            for (int i = 2; i < array.Length; i++)
            {
                int j = i;
                while (j > 0 && array[j] > array[j - 1])
                {
                    int temp = array[j - 1];
                    array[j - 1] = array[j];
                    array[j] = temp;
                    j--;
                }
            }
        }
    }
}
