using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibriary;


namespace Matrixes
{
    class Matrix
    {
        static void Main(string[] args)
        {
            int end = 0;
            while (end == 0)
            {

                //Ввод ширины и высоты первой и второй матрицы
                Console.Write("Enter the width of the first Matrix: ");
                int firstMatrixWidth = int.Parse(Console.ReadLine());
                Console.Write("Enter the height of the first Matrix: ");
                int firstMatrixHeight = int.Parse(Console.ReadLine());

                Console.WriteLine("If you only need one Matrix, then enter units.");
                Console.Write("Enter the width of the second Matrix: ");
                int secondMatrixWidth = int.Parse(Console.ReadLine());
                Console.Write("Enter the height of the first Matrix: ");
                int secondMatrixHeight = int.Parse(Console.ReadLine());

                double[,] firstMatrix = new double[firstMatrixWidth, firstMatrixHeight];
                double[,] secondMatrix = new double[secondMatrixWidth, secondMatrixHeight];

                for (int i = 0; i < firstMatrixHeight; i++) //Ввод первой матрицы
                {
                    for (int j = 0; j < firstMatrixWidth; j++)
                    {
                        Console.Write($"Enter the First Matrix value at position [{i + 1}:{j + 1}]: ");
                        firstMatrix[j, i] = double.Parse(Console.ReadLine());
                    }
                }


                for (int i = 0; i < secondMatrixHeight; i++) //Ввод второй матрицы
                {
                    for (int j = 0; j < secondMatrixWidth; j++)
                    {
                        Console.Write($"Enter the Second Matrix value at position [{i + 1}:{j + 1}]: ");
                        secondMatrix[j, i] = double.Parse(Console.ReadLine());
                    }
                }

                //Вывод первой матрицы на экран
                Console.Clear();
                Console.WriteLine("The First Matrix: ");
                for (int i = 0; i < firstMatrixHeight; i++)
                {
                    for (int j = 0; j < firstMatrixWidth; j++)
                    {
                        Console.Write(firstMatrix[j,i] + "\t");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                }

                Console.WriteLine(); //Вывод второй матрицы на экран
                Console.WriteLine();
                Console.WriteLine("The Second Matrix: ");
                for (int i = 0; i < secondMatrixHeight; i++)
                {
                    for (int j = 0; j < secondMatrixWidth; j++)
                    {
                        Console.Write(secondMatrix[j, i] + "\t");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                }


                Console.Write("Select an action: +, x, *, end: "); //Выбор действия

                switch (Console.ReadLine()) 
                {
                    case "+": //Сложение
                        {                            
                            Console.WriteLine();
                            if (firstMatrixHeight == firstMatrixWidth && secondMatrixHeight == secondMatrixWidth && firstMatrixHeight == secondMatrixHeight)
                            {
                                double[,] additionMatrix = new double[firstMatrixHeight, firstMatrixWidth];
                                for (int i = 0; i < firstMatrixHeight; i++)
                                {
                                    for (int j = 0; j < firstMatrixWidth; j++)
                                    {
                                        additionMatrix[j, i] = firstMatrix[j, i] + secondMatrix[j, i];
                                    }
                                }
                                Console.WriteLine("The result: ");

                                for (int i = 0; i < firstMatrixHeight; i++)
                                {
                                    for (int j = 0; j < firstMatrixWidth; j++)
                                    {
                                        Console.Write(additionMatrix[j, i] + "\t");
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("The Matrixes nust be square and equal!");
                                Console.WriteLine("Enter the new Matrixes.");
                                Console.Clear();
                                break;                               
                            }
                            break;
                        }

                    case ("x"):   //Умножение на число
                        {
                            Console.WriteLine();
                            Console.WriteLine("!This method only works with the First Matrix!");

                            Console.WriteLine();
                            Console.Write("Enter a multiplier: ");
                            double multiplier = double.Parse(Console.ReadLine());

                            for (int i = 0; i < firstMatrixHeight; i++)
                            {
                                for (int j = 0; j < firstMatrixWidth; j++)
                                {
                                    firstMatrix[j, i] = firstMatrix[j, i] * multiplier;
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine("Result: ");
                            for (int i = 0; i < firstMatrixHeight; i++)
                            {
                                for (int j = 0; j < firstMatrixWidth; j++)
                                {
                                    Console.Write(firstMatrix[j,i] + "\t");
                                }
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                            }
                            for (int i = 0; i < 25; i++)
                            {
                                Console.Write("_");
                            }
                            break;
                        };
                    case "X":
                        goto case "x";


                    case "*":
                        {
                            if (firstMatrixHeight == secondMatrixWidth)
                            {
                                double resultCollector = 0;
                                double[,] resultMatrix = new double[firstMatrixWidth, secondMatrixHeight];
                                for (int i = 0; i < secondMatrixHeight; i++)
                                {
                                    for (int j = 0; j < firstMatrixWidth; j++) //По Результату
                                    {
                                        for (int k = 0; k < firstMatrixHeight; k++)
                                        {
                                            resultCollector += firstMatrix[k, i] * secondMatrix[j, k];
                                        }
                                        resultMatrix[j, i] = resultCollector;
                                        resultCollector = 0;
                                    }
                                }
                                Console.WriteLine("Result Matrix: ");
                                for (int i = 0; i < firstMatrixHeight; i++)
                                {
                                    for (int j = 0; j < secondMatrixWidth; j++)
                                    {
                                        Console.Write(resultMatrix[j,i] + "\t");
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("!The nubmer of columns in the First Matrix must be equal to the number of rows in the Second Mayrix!");
                                Console.WriteLine("Enter the new Matrixes");
                            }
                            break;
                        }

                    case "det":
                        {
                            double result = MyLibriary.Matrix.Determinant(firstMatrix);

                            Console.WriteLine($"The result: {result}");
                            break;
                        }
                    case "Determinant":
                        goto case "det";
                    case "determinant":
                        goto case "det";
                    case "Det":
                        goto case "det";


                    case "A^-1": //Обратная матрица
                        {
                            double resultDet = MyLibriary.Matrix.Determinant(firstMatrix);

                            if (resultDet == 0) //det = 0
                            {
                                Console.WriteLine();
                            }

                            else //det != 0
                            {

                            }

                            break;
                        }
                    case "-1":
                        goto case "A^-1";


                    case "end": //Выход из программы
                        {
                            Console.WriteLine("The proggram will be closed!");
                            Console.Write("Comfirm your choise: 1 - yes, 2 - no ");
                            int comfirm = int.Parse(Console.ReadLine());

                            if (comfirm == 1)
                            {
                                end++;
                                Console.WriteLine("The program will be closed. Bye.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("The program will continue to work! Thenks.");
                            }
                            break;
                        }

                    case "End":
                        goto case "end";

                    case "END":
                        goto case "end";


                    default:
                        {
                            Console.WriteLine();
                            break;
                        }
                }
                for (int i = 0; i < 25; i++)
                {
                    Console.Write("_");
                }
                Console.WriteLine("\nPress any button to continue. . .");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
