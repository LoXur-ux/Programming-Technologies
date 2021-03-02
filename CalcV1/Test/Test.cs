using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using MyLibriary;

namespace Test
{

    class Test
    {
        static public double[,] Cofactor(double[,] array, int column, int line) //Создание алг дополнения
        {
            double[,] newArray = new double[array.GetLength(0) - 1, array.GetLength(0) - 1]; //Массив алг. доп.

            int iAdd = 0; //Пернеменные для пропуска вычеркнутых строк\столбцов
            int jAdd = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (i != line)
                {
                    for (int j = 0; j < array.GetLength(0); j++)
                    {
                        if (j != column)
                        {
                            newArray[jAdd, iAdd] = array[j, i];
                            jAdd++;
                        }
                    }
                    jAdd = 0;
                    iAdd++;
                }
            }
            
            return newArray;
        }

        static double[,] Det(double[,] array)
        {
            double x = 0;
            double det = 0;
            double z = 0;
            double[,] newArray;

            if (array.GetLength(0) > 3)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    newArray = Cofactor(array, 0, i);
                    if (i % 2 != 0) z += 1;
                    Det(newArray);
                    return newArray;
                }
                
            }
            else
            {
                
            }
            
        }

        static void Main(string[] args)
        {
            
            Random rnd = new Random();
            double[,] array = new double[4,4];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    array[j, i] = rnd.Next(0, 20);
                }
            }
            Console.Clear();
            MyLine.MatrixOutput(array);
            Console.WriteLine();

            double result = Det(array);
            Console.WriteLine();
            Console.WriteLine(result);
            
        }
    }
}
