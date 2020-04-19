using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortProject
{
    class ShellSort
    {
        public double[] Massive { get; set; }
        public ShellSort(double[] massive)
        {
            Massive = massive;
        }


        public void GoSort()
        {
            int count = Massive.Length;
            double tmp;
            int j;

            for (int step = count / 2; step > 0; step /= 2)
                for (int i = step; i < count; i++)
                {
                    tmp = Massive[i];
                    for (j = i; j >= step; j -= step)
                    {
                        if (tmp < Massive[j - step])
                            Massive[j] = Massive[j - step];
                        else
                            break;
                    }
                    Massive[j] = tmp;
                }
        }
    }
}
