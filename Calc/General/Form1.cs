using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General
{
    public partial class Form1 : Form
    {
        public int[] leftLenght = new int[] { 3, 3 };   // Актуальная длинна*ширина матрицы.
        public int[] rightLenght = new int[] { 3, 3 };

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0; // Установка хначения по умолчанию.
        }

        private void topLeftPlusBut_Click(object sender, EventArgs e)   // Левая верхняя +.
        {
            MatrixSize(+1, "column", "left");
        }
        private void topLeftMinusBut_Click(object sender, EventArgs e)  // Левая верхняя -.
        {
            MatrixSize(-1, "column", "left");
        }
        private void sideLeftPlusBut_Click(object sender, EventArgs e)  // Левая нижня +.
        {
            MatrixSize(+1, "line", "left");
        }
        private void sideLeftMinusBut_Click(object sender, EventArgs e) // Левая нижня -.
        {
            MatrixSize(-1, "line", "left");
        }


        /// <summary>
        /// Изменяет количество строк/столбцов матрицы.
        /// </summary>
        /// <param name="delta">изменяемая велисина</param>
        /// <param name="lineOrColumn">line - строка; column - столбец</param>
        /// <param name="leftOrRight">сторона</param>
        private void MatrixSize(int delta, string lineOrColumn, string leftOrRight)
        {
            if (leftOrRight == "left")
            {
                if (lineOrColumn == "line")
                    leftLenght[0] += delta;
                else
                    leftLenght[1] += delta;
            }
            else
            {
                if (lineOrColumn == "line")
                    rightLenght[0] += delta;
                else
                    rightLenght[1] += delta;
            }

            for (int i = 0; i < 2; i++)  // Проверка не выходит ли значения за гранциы и правка.
            {
                if (leftLenght[i] > 5)
                    leftLenght[i] = 5;

                if (leftLenght[i] < 3)
                    leftLenght[i] = 3;

                if (rightLenght[i] > 5)
                    rightLenght[i] = 5;

                if (rightLenght[i] < 3)
                    rightLenght[i] = 3;
            }
            MessageBox.Show($"{leftLenght[0]} и {leftLenght[1]}\n{rightLenght[0]} и {rightLenght[1]}");
        }
    }
}
