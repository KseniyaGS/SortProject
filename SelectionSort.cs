using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortProject
{
    class SelectionSort
    {
        public double[] Massive { get; set; }
        public SelectionSort(double[] massive)
        {
            Massive = massive;
        }

        public void GoSort()
        {
            int n = Massive.Length;

            // One by one move boundary of unsorted subarray 
            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array 
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (Massive[j] < Massive[min_idx])
                        min_idx = j;

                // Swap the found minimum element with the first 
                // element 
                double temp = Massive[min_idx];
                Massive[min_idx] = Massive[i];
                Massive[i] = temp;
            }
        }
    }
}
