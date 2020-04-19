using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortProject
{
    class ExchangeBitSort
    {
        public double[] Massive { get; set; }
        public ExchangeBitSort(double[] massive)
        {
            Massive = massive;
        }

        public int[] GoSort()
        {
            if (!Massive.All(x => x.GetType() == typeof(int)))
            {
                MessageBox.Show("Данная сортировка работает только для целых чисел!", "Предупреждение", MessageBoxButtons.OK);
                return null;
            }

            var massiveInt = Massive.Select(x => Convert.ToInt32(x)).ToArray();

            int i, j;
            var tmp = new int[massiveInt.Length];
            for (int shift = sizeof(long) * 8 - 1; shift > -1; --shift)
            {
                j = 0;
                for (i = 0; i < massiveInt.Length; ++i)
                {
                    var move = (massiveInt[i] << shift) >= 0;
                    if (shift == 0 ? !move : move)
                        Massive[i - j] = Massive[i];
                    else
                        tmp[j++] = massiveInt[i];
                }
                Array.Copy(tmp, 0, Massive, Massive.Length - j, j);
            }

            return massiveInt;
        }
    }
}
