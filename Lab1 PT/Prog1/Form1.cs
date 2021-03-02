using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label11.Text = "";
            label13.Text = "";
        }

        int i = 0;

        private void button3_Click(object sender, EventArgs e) // Пуск.
        {
            button3.Enabled = false;
            label11.Text = "";
            if (numericUpDown4.Value < numericUpDown5.Value)
            {
                label11.Text = "Макс значение не м.б. меньше мин значения!";
                return;
            }
            int count, current = 0;
            count = (Convert.ToInt32(numericUpDown2.Value) - Convert.ToInt32(numericUpDown1.Value)) / Convert.ToInt32(numericUpDown3.Value) + 1;
            for (int n = Convert.ToInt32(numericUpDown1.Value);
                    n <= Convert.ToInt32(numericUpDown2.Value);
                    n += Convert.ToInt32(numericUpDown3.Value))
            {
                int[] vptr = new int[n]; Random rand = new Random();

                for (int j = 0; j < n; j++)
                    vptr[j] = rand.Next(Convert.ToInt32(numericUpDown5.Value), Convert.ToInt32(numericUpDown4.Value));
                if (checkBox1.Checked)
                {
                    dataGridView1.ColumnCount = n + 1;
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = "Исходный массив";
                    for (int j = 0; j < n; j++)
                        dataGridView1.Rows[i].Cells[j + 1].Value = vptr[j];
                    i++;
                }
                sort(vptr, n);
                current += 1; progressBar1.Value = 100 * current / count;
            }
        }

        private void sort(int[] p, int n)
        {
            int k = 0, sr = 0, obm = 0, m = 0;
            for (int j = 0; j < n; j++)
            {
                if (p[j] == 0)
                    k++;
                else
                    p[j - k] = p[j];
            }
            n -= k; sr += n;
            if (n == 0)
            {
                label11.Text = "В массиве одни нули";
                return;
            }
            for (m = 0; m < n - 1; m++)
                for (int j = m + 1; j < n; j++)
                {
                    if (p[m] > 0 && p[j] > 0 && p[m] < p[j])
                    {
                        swap(ref p[m], ref p[j]); obm++;
                    }
                    if (p[m] < 0 && p[j] < 0 && p[m] > p[j])
                    {
                        swap(ref p[m], ref p[j]); obm++;
                    }
                    sr += 6;
                }
            if (checkBox1.Checked)
            {
                dataGridView1.AutoResizeColumns();
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = "Получен массив";
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j + 1].Value = p[j];
                }
                i++;
            }
            if (Convert.ToInt32(numericUpDown1.Value) == Convert.ToInt32(numericUpDown2.Value))
            {
                label11.Text = "Количество сравнений=" + Convert.ToString(sr) + " Количество обменов=" + Convert.ToString(obm);
            }
            if (checkBox2.Checked)
            {
                chart1.Series[0].Points.AddXY(n, sr);
                chart2.Series[0].Points.AddXY(n, obm);
            }
        }

        void swap(ref int x, ref int y)
        {
            int z = x;
            x = y;
            y = z;
        }

        private void button4_Click(object sender, EventArgs e) // Сброс.
        {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            i = 0;
            button3.Enabled = true;
        }

        int n, m;
        private void button2_Click(object sender, EventArgs e) // Matrix Start
        {
            int k = 0;
            button2.Enabled = false;
            if (numericUpDown8.Value > numericUpDown7.Value)
            {
                label13.Text = "Макс значение не м.б. меньше мин значения!";
                return;
            }
            // Линии
            n = Convert.ToInt32(numericUpDown6.Value);
            // Столбики
            m = Convert.ToInt32(numericUpDown6.Value);
            int[,] ptr;
            ptr = new int[n, m];
            Random rand = new Random();
            dataGridView2.AutoResizeColumns();
            dataGridView2.ColumnCount = n;

            for (int i = 0; i < n; i++)
            {
                dataGridView2.Rows.Add();
                for (int j = 0; j < m; j++)
                {
                    ptr[i, j] = rand.Next(Convert.ToInt32(numericUpDown8.Value), Convert.ToInt32(numericUpDown7.Value));
                    dataGridView2.Rows[i].Cells[j].Value = ptr[i, j];
                }
            }
            k = 0;

            List<int> kickList = new List<int>();

            // Проверка на нули выше глав. диагонали.
            for (int x = 0; x < n; x++)
                for (int y = 0; y < m && y > x; y++)
                    if (ptr[x, y] == 0 && y > x)
                    {
                        k++;
                        kickList.Add(x);
                        break;
                    }
            
            label13.Text = $"Удалено {k} строк:\n";
            foreach (int i in kickList)
                label13.Text += $"{i + 1}, ";

            dataGridView3.AutoResizeColumns();
            dataGridView3.ColumnCount = n;

            int kickRowValue = 0;
            for (int i = 0; i < n; i++)
            {
                if (KickCheck(kickList, i))
                {
                    kickRowValue++;
                    continue;
                }
                if (i - kickRowValue == 2)
                {
                    for (int j = 0; j < m; j++)
                    {
                        dataGridView3.Rows.Add();
                        dataGridView3.Rows[2].Cells[j].Value = Convert.ToInt32(dataGridView3.Rows[0].Cells[j].Value) - Convert.ToInt32(dataGridView3.Rows[1].Cells[j].Value);
                    }
                        
                    kickRowValue++;
                }
                else
                    for (int j = 0; j < m; j++)
                    {
                        dataGridView3.Rows.Add();
                        dataGridView3.Rows[i].Cells[j].Value = ptr[i - kickRowValue, j];
                    }
                        
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
            button2.Enabled = true;
            label13.Text = "";
        }
        
        // Проверка на совпадение с вылетевшими строчками.
        private bool KickCheck(List<int> list, int x)
        {
            foreach (int i in list)
                if (i == x)
                    return true;
            return false;
        }

    }
}
