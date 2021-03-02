using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.WindowsForms;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace Practic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // План Перехват!
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!(c >= '0' && c <= '9' || c == '\b'))
                e.Handled = true;
        }

        // Ассинхронное выполнение блока с запретом ввода букв. 
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            textBox1.KeyPress += TextBox_KeyPress;
        }


        // Управление включеним кнопки.
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                button1.Enabled = true;
                button1.BackColor = Color.FromArgb(240, 255, 255);
            }
            else
            {
                button1.Enabled = false;
                button1.BackColor = Color.FromArgb(220, 220, 220);
            }
        }

        // Кнопка действия, присваивания значения n.
        private void button1_Click(object sender, EventArgs e)
        {
            n = double.Parse(textBox1.Text);
            button1.Enabled = false;
            label1.Visible = true;
            richTextBox1.Visible = true;
            button2.Visible = true;
            Graph();
        }

        // Кол-во повторений.
        public double n = 0;

        private async void Graph()
        {
            // Присваивание pv окна plotViewe'ра.
            PlotView pv = plotView1;

            // Присваивание названия окну Графика
            pv.Model = new PlotModel { Title = "HomeWork" };

            // Создание массива точек.
            FunctionSeries firstFS = new FunctionSeries();
            FunctionSeries secondFS = new FunctionSeries();

            // Добавление осей X-Y, потому что программа в какой-то момент перестала работать без их прямого объявления.
            pv.Model.Axes.Add(new LinearAxis
            {
                Key = "xAxis",
                Position = AxisPosition.Bottom,
                Title = "X Axis"
            });
            pv.Model.Axes.Add(new LinearAxis
            {
                Key = "yAxis",
                Position = AxisPosition.Left,
                Title = "Y Axis"
            });



            if (n != 0)
            {
                await Task.Run(() =>
                {
                    Random x = new Random();

                    double[] arrayX = new double[(int)n * 2];
                    double y = 0;

                    // Генерация точек x.
                    for (int i = 0; i < n; i++)
                    {
                        arrayX[i] = x.Next(-20, 20);

                        if (arrayX[i] < 6 && arrayX[i] >= 1)
                            for (double j = arrayX[i] - -1; j < arrayX[i] + 1; j += .01)
                                arrayX[(int)n + i] = j;

                        if (arrayX[i] < 0 && arrayX[i] >= -3)
                            for (double j = arrayX[i] - -1; j < arrayX[i] + 1; j += .01)
                                arrayX[(int)n + i] = j;
                    }

                    // Сотрировка точек по возрастанию.
                    Array.Sort(arrayX);

                    // Построение графиков.
                    for (int i = 0; i < 2 * n; i++)
                    {
                        if (arrayX[i] > 0)
                        {
                                y = 1 / Math.Pow(Math.Log(arrayX[i]), 2);
                                firstFS.Points.Add(new DataPoint(arrayX[i], y));
                        }
                            
                        if (arrayX[i] < 0)
                        {
                            double ctg = 1.0 / Math.Tan(1 / arrayX[i]);
                            y = Math.Pow(3, ctg);
                            secondFS.Points.Add(new DataPoint(arrayX[i], y));
                        }

                        // Вывод координат точек на панель "Сгенерировано".
                        richTextBox1.Text += $"\r\nСгенерировано: ({arrayX[i]}; {y})";
                    }

                    pv.Model.Series.Add(firstFS);
                    pv.Model.Series.Add(secondFS);
                }
                );
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Сгенерировано: (X; Y)";
        }
    }
}
