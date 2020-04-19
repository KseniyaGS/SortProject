using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortProject
{
    class BubbleSort
    {
        public double[] Massive { get; set; }
        public BubbleSort(double[] massive)
        {
            Massive = massive;
        }

        public double[] GoSort()
        {
            double temp;
            for (int i = 0; i < Massive.Length; i++)
            {
                for (int j = i + 1; j < Massive.Length; j++)
                {
                    if (Massive[i] > Massive[j])
                    {
                        temp = Massive[i];
                        Massive[i] = Massive[j];
                        Massive[j] = temp;
                    }
                }
            }
            return Massive;
        }
    }
}
