using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortProject
{
    class BucketSort
    {
        public double[] Massive { get; set; }
        public BucketSort(double[] massive)
        {
            Massive = massive;
        }

        public bool GoSort()
        {
            if (!Massive.All(x => x > 0) && !Massive.All(x => x.GetType() == typeof(int)))
            {
                MessageBox.Show("Данная сортировка работает только для положительных целых чисел!", "Предупреждение", MessageBoxButtons.OK);
                return false;
            }

            int[] massiveInt = Massive.Select(x => Convert.ToInt32(x))
                                                          .ToArray();
            //поиск максимального элемента массива
            int maxValue = massiveInt[0];

            for (int k = 1; k < massiveInt.Length; k++)
            {
                if (massiveInt[k] > maxValue)
                    maxValue = massiveInt[k];
            }

            int i, j;
            //создадим вспомогательный массив
            int[] bucket = new int[maxValue + 1];
            //распределим числа по карманам
            for (i = 0; i < massiveInt.Length; i++)
            {
                bucket[massiveInt[i]]++;
            }

            //отсортируем числа в карманах используя сортировку подсчетом
            for (i = 0, j = 0; i < bucket.Length; i++)
            {
                for (; bucket[i] > 0; (bucket[i])--)
                {
                    massiveInt[j++] = i;
                }
            }

            return true;
        }
    }
}
