using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Determinant_4_order
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 4;  //Ввод чисел определителя по порядку

            double[,] det = new double[width, width];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write($"Enter Determinal [{i + 1},{j + 1}]: ");
                    det[i, j] = double.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            //Выведение введенного определителя
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(det[i, j] + "\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            //Промежуточные массивы
            double[,] firstMinor = new double[(width - 1), (width - 1)];     //Minor [1,1]
            double[,] secondMinor = new double[(width - 1), (width - 1)];    //Minor [2,1]
            double[,] thirdMinor = new double[(width - 1), (width - 1)];     //Minor [3,1]
            double[,] fourthMinor = new double[(width - 1), (width - 1)];    //Minor [4,1]

            //Minor [1,1]
            for (int i = 0; i < width - 1; i++)
            {
                for (int j = 0; j < width - 1; j++)
                {
                    firstMinor[i, j] = det[i + 1, j + 1];                    
                }
            }

            //Minor [2,1]
            secondMinor[0, 0] = det[0, 1];      secondMinor[0, 1] = det[0, 2];      secondMinor[0, 2] = det[0, 3];
            secondMinor[1, 0] = det[2, 1];      secondMinor[1, 1] = det[2, 2];      secondMinor[1, 2] = det[2, 3];
            secondMinor[2, 0] = det[3, 1];      secondMinor[2, 1] = det[3, 2];      secondMinor[2, 2] = det[3, 3];

            //Minor [3,1]
            thirdMinor[0, 0] = det[0, 1];       thirdMinor[0, 1] = det[0, 2];       thirdMinor[0, 2] = det[0, 3];
            thirdMinor[1, 0] = det[1, 1];       thirdMinor[1, 1] = det[1, 2];       thirdMinor[1, 2] = det[1, 3];
            thirdMinor[2, 0] = det[3, 1];       thirdMinor[2, 1] = det[3, 2];       thirdMinor[2, 2] = det[3, 3];

            //Minor [4,1]
            fourthMinor[0, 0] = det[0, 1];      fourthMinor[0, 1] = det[0, 2];      fourthMinor[0, 2] = det[0, 3];
            fourthMinor[1, 0] = det[1, 1];      fourthMinor[1, 1] = det[1, 2];      fourthMinor[1, 2] = det[1, 3];
            fourthMinor[2, 0] = det[2, 1];      fourthMinor[2, 1] = det[2, 2];      fourthMinor[2, 2] = det[2, 3];


            //Подсчет первого алг. дополнения
            double generalLine = firstMinor[0, 0] * firstMinor[1, 1] * firstMinor[2, 2];
            double generalFirstTriangle = firstMinor[2, 0] * firstMinor[0, 1] * firstMinor[1, 2];
            double generalSecondTriangle = firstMinor[0, 2] * firstMinor[1, 0] * firstMinor[2, 1];

            double secondLine = firstMinor[2, 0] * firstMinor[1, 1] * firstMinor[0, 2];
            double secondFirstTriangle = firstMinor[0, 0] * firstMinor[2, 1] * firstMinor[1, 2];
            double secondSecondTriangle = firstMinor[2, 2] * firstMinor[1, 0] * firstMinor[0, 1];

            double result = det[0,0] * ((generalLine + generalFirstTriangle + generalSecondTriangle) - (secondLine + secondFirstTriangle + secondSecondTriangle));

            //Подсчет второго алг. дополнения
            generalLine = secondMinor[0, 0] * secondMinor[1, 1] * secondMinor[2, 2];
            generalFirstTriangle = secondMinor[2, 0] * secondMinor[0, 1] * secondMinor[1, 2];
            generalSecondTriangle = secondMinor[0, 2] * secondMinor[1, 0] * secondMinor[2, 1];

            secondLine = secondMinor[2, 0] * secondMinor[1, 1] * secondMinor[0, 2];
            secondFirstTriangle = secondMinor[0, 0] * secondMinor[2, 1] * secondMinor[1, 2];
            secondSecondTriangle = secondMinor[2, 2] * secondMinor[1, 0] * secondMinor[0, 1];

            result += det[1, 0] * (-1) * ((generalLine + generalFirstTriangle + generalSecondTriangle) - (secondLine + secondFirstTriangle + secondSecondTriangle));

            //Подсчет третьего алг. дополнения
            generalLine = thirdMinor[0, 0] * thirdMinor[1, 1] * thirdMinor[2, 2];
            generalFirstTriangle = thirdMinor[2, 0] * thirdMinor[0, 1] * thirdMinor[1, 2];
            generalSecondTriangle = thirdMinor[0, 2] * thirdMinor[1, 0] * thirdMinor[2, 1];

            secondLine = thirdMinor[2, 0] * thirdMinor[1, 1] * thirdMinor[0, 2];
            secondFirstTriangle = thirdMinor[0, 0] * thirdMinor[2, 1] * thirdMinor[1, 2];
            secondSecondTriangle = thirdMinor[2, 2] * thirdMinor[1, 0] * thirdMinor[0, 1];

            result += det[2, 0] * ((generalLine + generalFirstTriangle + generalSecondTriangle) - (secondLine + secondFirstTriangle + secondSecondTriangle));

            //Подсчет четвертого алг. дополнения
            generalLine = fourthMinor[0, 0] * fourthMinor[1, 1] * fourthMinor[2, 2];
            generalFirstTriangle = fourthMinor[2, 0] * fourthMinor[0, 1] * fourthMinor[1, 2];
            generalSecondTriangle = fourthMinor[0, 2] * fourthMinor[1, 0] * fourthMinor[2, 1];

            secondLine = fourthMinor[2, 0] * fourthMinor[1, 1] * fourthMinor[0, 2];
            secondFirstTriangle = fourthMinor[0, 0] * fourthMinor[2, 1] * fourthMinor[1, 2];
            secondSecondTriangle = fourthMinor[2, 2] * fourthMinor[1, 0] * fourthMinor[0, 1];

            result += det[3, 0] * (-1) * ((generalLine + generalFirstTriangle + generalSecondTriangle) - (secondLine + secondFirstTriangle + secondSecondTriangle));

            //Вывод резульатат
            Console.WriteLine($"Result = {result}");


            Console.WriteLine("Press any button to continue. . .");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
