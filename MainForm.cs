using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            textBoxOutput.Clear();
            double[] inputMassive = textBoxInput.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                                  .ToArray().Select(x => Convert.ToDouble(x))
                                                  .ToArray();
            // Сортировка методом Шелла.
            if (comboBox.SelectedIndex == Convert.ToInt32(SortEnum.ShellSort))
            {
                ShellSort shell = new ShellSort(inputMassive);
                shell.GoSort();
                Output(inputMassive);
            }

            // Обменная поразрядная сортировка.
            if (comboBox.SelectedIndex == Convert.ToInt32(SortEnum.ExchangeBitSort))
            {
                ExchangeBitSort exchangeBitSort = new ExchangeBitSort(inputMassive);
                var resultMassive = exchangeBitSort.GoSort();
                if (resultMassive != null)
                {
                    var oututMassive = resultMassive.Select(x => Convert.ToDouble(x)).ToArray();
                    Output(oututMassive);
                }
            }

            // Пирамидальная сортировка.
            if (comboBox.SelectedIndex == Convert.ToInt32(SortEnum.HeapSort))
            {
                HeapSort heapSort = new HeapSort(inputMassive);
                heapSort.GoSort();
                Output(inputMassive);
            }

            // Быстрая сортировка (метод Хоара).
            if (comboBox.SelectedIndex == Convert.ToInt32(SortEnum.HoaraSort))
            {
                HoaraSort quickSort = new HoaraSort(inputMassive);
                var oututMassive = quickSort.GoSort();
                Output(oututMassive);
            }

            // Сортировка пузырьком.
            if (comboBox.SelectedIndex == Convert.ToInt32(SortEnum.BubbleSort))
            {
                BubbleSort sort = new BubbleSort(inputMassive);
                var oututMassive = sort.GoSort();
                Output(oututMassive);
            }

            // Шейкерная (коктейльная) сортировка.
            if (comboBox.SelectedIndex == Convert.ToInt32(SortEnum.CocktailSort))
            {
                CocktailSort sort = new CocktailSort(inputMassive);
                sort.GoSort();
                Output(inputMassive);
            }

            // Шейкерная (коктейльная) сортировка.
            if (comboBox.SelectedIndex == Convert.ToInt32(SortEnum.InsertionSort))
            {
                InsertionSort sort = new InsertionSort(inputMassive);
                sort.GoSort();
                Output(inputMassive);
            }

            // Сортировка выбором.
            if (comboBox.SelectedIndex == Convert.ToInt32(SortEnum.SelectionSort))
            {
                SelectionSort sort = new SelectionSort(inputMassive);
                sort.GoSort();
                Output(inputMassive);
            }

            // Карманная (блочная) сортировка.
            if (comboBox.SelectedIndex == Convert.ToInt32(SortEnum.BucketSort))
            {
                BucketSort sort = new BucketSort(inputMassive);
                if (sort.GoSort())
                    Output(inputMassive);
            }

            // Сортировка слиянием.
            if (comboBox.SelectedIndex == Convert.ToInt32(SortEnum.MergeSort))
            {
                MergeSort sort = new MergeSort(inputMassive);
                sort.GoSort(inputMassive, 0, inputMassive.Length - 1);
                Output(inputMassive);
            }
        }

        public void Output(double[] inputMassive)
        {
            StringBuilder st = new StringBuilder();
            foreach (var item in inputMassive)
            {
                st.Append(item.ToString() + " ");
            }
            textBoxOutput.Text = st.ToString();
        }

        private void buttonClearInput_Click(object sender, EventArgs e)
        {
            textBoxInput.Clear();
        }

        private void buttonClearOutput_Click(object sender, EventArgs e)
        {
            textBoxOutput.Clear();
        }

        private void textBoxInput_TextChanged(object sender, EventArgs e)
        {
            //Regex regex = new Regex("\\-?\\d+(\\,\\d{ 0,})?\\s*");
            //MatchCollection matches = regex.Matches(textBoxInput.Text);
            //if (matches.Count > 0)
            //{
            //    MessageBox.Show("Неверно введенные данные!");
            //    //textBoxInput.Text = textBoxInput.Text.Remove(textBoxInput.Text.Length-2,1);
            //    comboBox.Enabled = false;
            //    return;
            //}

            if (String.IsNullOrEmpty(textBoxInput.Text))
                comboBox.Enabled = false;
            else
                comboBox.Enabled = true;
        }

        private void textBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 || e.KeyChar <= 57 || e.KeyChar == 32 || e.KeyChar == 45 || e.KeyChar == 44)
                e.Handled = false;
            //!Char.IsDigit(e.KeyChar)
             //|| e.KeyChar != 32 || e.KeyChar != 45 || e.KeyChar != 44
        }
    }
}
