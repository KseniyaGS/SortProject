using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortProject
{
    class InsertionSort
    {
        public double[] Massive { get; set; }
        public InsertionSort(double[] massive)
        {
            Massive = massive;
        }

        public void GoSort()
        {
            int n = Massive.Length;
            for (int i = 1; i < n; ++i)
            {
                double key = Massive[i];
                int j = i - 1;

                while (j >= 0 && Massive[j] > key)
                {
                    Massive[j + 1] = Massive[j];
                    j = j - 1;
                }
                Massive[j + 1] = key;
            }
        }
    }
}
