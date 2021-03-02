using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Determinant_3_order
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] det = new double[3,3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Enter Determinal [{i+1},{j+1}]: ");
                    det[i, j] = double.Parse(Console.ReadLine());                     
                }
            }
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(det[i,j] + "\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            double generalLine = det[0, 0] * det[1, 1] * det[2, 2];
            double generalFirstTriangle = det[2, 0] * det[0, 1] * det[1, 2];
            double generalSecondTriangle = det[0, 2] * det[1, 0] * det[2, 1];

            double secondLine = det[2, 0] * det[1, 1] * det[0, 2];
            double secondFirstTriangle = det[0, 0] * det[2, 1] * det[1, 2];
            double secondSecondTriangle = det[2, 2] * det[1, 0] * det[0, 1];

            double result = (generalLine + generalFirstTriangle + generalSecondTriangle) - (secondLine + secondFirstTriangle + secondSecondTriangle);

            Console.WriteLine($"Result = {result}");


            Console.WriteLine("Press any button to continue. . .");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
