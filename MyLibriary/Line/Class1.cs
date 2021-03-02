using System;

namespace MyLibriary
{
    public static class MyLine 
    {
        public static void MatrixInput(double[,] matrix)//Ввод матриц
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"Enter the Matrix value at position [{j + 1}:{i + 1}]: ");
                    matrix[j, i] = double.Parse(Console.ReadLine());
                }
            }
        }

        public static void MatrixOutput(double[,] matrix) //Вывод матрицы
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[j, i] + "\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }





    public static class Matrix
    {
        public static double[,] MatrixAdd(double[,] firstMatrix, double[,] secondMatrix) //Сложение матриц
        {
            if (firstMatrix.GetLength(0) == firstMatrix.GetLength(1) && secondMatrix.GetLength(0) == secondMatrix.GetLength(1) && firstMatrix.GetLength(0) == secondMatrix.GetLength(0))
            {
                for (int i = 0; i < firstMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < firstMatrix.GetLength(0); j++)
                    {
                        firstMatrix[j, i] += secondMatrix[j, i];
                    }
                }
                
            }
            else Console.WriteLine("The Matrixes must be square and equal!");
            return firstMatrix;
        }

        public static double[,] MatrixSubtract(double[,] firstMatrix, double[,] secondMatrix) //Вычитание матриц
        {
            if (firstMatrix.GetLength(0) == firstMatrix.GetLength(1) && secondMatrix.GetLength(0) == secondMatrix.GetLength(1) && firstMatrix.GetLength(0) == secondMatrix.GetLength(0))
            {
                for (int i = 0; i < firstMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < firstMatrix.GetLength(0); j++)
                    {
                        firstMatrix[j, i] -= secondMatrix[j, i];
                    }
                }

                
            }
            else Console.WriteLine("The Matrixes must be square and equal!");
            return firstMatrix;
        }

        public static double[,] MatrixXNumber(double[,] matrix, double x) //Умножение матрицы на число
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[j, i] = matrix[j, i] * x;
                }
            }

            return matrix;
        }

        public static double[,] MatrixMult(double[,] firstMatrix, double[,] secondMatrix) //Перемножение матриц
        {
            double[,] resultMatrix = new double[firstMatrix.GetLength(1), secondMatrix.GetLength(0)];
            if (firstMatrix.GetLength(1) == secondMatrix.GetLength(0))
            {
                double resultCollector = 0;
                for (int i = 0; i < secondMatrix.GetLength(1); i++)
                {
                    for (int j = 0; j < firstMatrix.GetLength(0); j++)
                    {
                        for (int k = 0; k < firstMatrix.GetLength(1); k++)
                        {
                            resultCollector += firstMatrix[k, i] * secondMatrix[j, k];
                        }
                        resultMatrix[j, i] = resultCollector;
                        resultCollector = 0;
                    }
                }
                
            }
            else Console.WriteLine("!The nubmer of columns in the First Matrix must be equal to the number of rows in the Second Mayrix!");
            return resultMatrix;
        }


        public static double Determinant(double[,] matrix)
        {
            double resultDet = 0;

            double generalLine;
            double generalFirstTriangle;
            double generalSecondTriangle;

            double secondLine;
            double secondFirstTriangle;
            double secondSecondTriangle;

            if (matrix.GetLength(0) == 1)
            {
                resultDet = matrix[0, 0];
            }

            if (matrix.GetLength(0) == 2)  //Вычисление det второго порядка
            {
                generalLine = matrix[0, 0] * matrix[1, 1];
                secondLine = matrix[1, 0] * matrix[0, 1];
                resultDet = generalLine - secondLine;
            }

            if (matrix.GetLength(0) == 3) //det третьего порядка
            {
                generalLine = matrix[0, 0] * matrix[1, 1] * matrix[2, 2];
                generalFirstTriangle = matrix[2, 0] * matrix[0, 1] * matrix[1, 2];
                generalSecondTriangle = matrix[0, 2] * matrix[1, 0] * matrix[2, 1];

                secondLine = matrix[2, 0] * matrix[1, 1] * matrix[0, 2];
                secondFirstTriangle = matrix[0, 0] * matrix[2, 1] * matrix[1, 2];
                secondSecondTriangle = matrix[2, 2] * matrix[1, 0] * matrix[0, 1];

                resultDet = (generalLine + generalFirstTriangle + generalSecondTriangle) - (secondLine + secondFirstTriangle + secondSecondTriangle);
            }

            if (matrix.GetLength(0) == 4) //det четвертого порядка
            {
                //Промежуточные массивы
                double[,] firstMinor = new double[(matrix.GetLength(0) - 1), (matrix.GetLength(0) - 1)];     //Minor [1,1]
                double[,] secondMinor = new double[(matrix.GetLength(0) - 1), (matrix.GetLength(0) - 1)];    //Minor [2,1]
                double[,] thirdMinor = new double[(matrix.GetLength(0) - 1), (matrix.GetLength(0) - 1)];     //Minor [3,1]
                double[,] fourthMinor = new double[(matrix.GetLength(0) - 1), (matrix.GetLength(0) - 1)];    //Minor [4,1]

                //Minor [1,1]
                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    for (int j = 0; j < matrix.GetLength(0) - 1; j++)
                    {
                        firstMinor[i, j] = matrix[i + 1, j + 1];
                    }
                }

                //Minor [2,1]
                secondMinor[0, 0] = matrix[0, 1]; secondMinor[0, 1] = matrix[0, 2]; secondMinor[0, 2] = matrix[0, 3];
                secondMinor[1, 0] = matrix[2, 1]; secondMinor[1, 1] = matrix[2, 2]; secondMinor[1, 2] = matrix[2, 3];
                secondMinor[2, 0] = matrix[3, 1]; secondMinor[2, 1] = matrix[3, 2]; secondMinor[2, 2] = matrix[3, 3];

                //Minor [3,1]
                thirdMinor[0, 0] = matrix[0, 1]; thirdMinor[0, 1] = matrix[0, 2]; thirdMinor[0, 2] = matrix[0, 3];
                thirdMinor[1, 0] = matrix[1, 1]; thirdMinor[1, 1] = matrix[1, 2]; thirdMinor[1, 2] = matrix[1, 3];
                thirdMinor[2, 0] = matrix[3, 1]; thirdMinor[2, 1] = matrix[3, 2]; thirdMinor[2, 2] = matrix[3, 3];

                //Minor [4,1]
                fourthMinor[0, 0] = matrix[0, 1]; fourthMinor[0, 1] = matrix[0, 2]; fourthMinor[0, 2] = matrix[0, 3];
                fourthMinor[1, 0] = matrix[1, 1]; fourthMinor[1, 1] = matrix[1, 2]; fourthMinor[1, 2] = matrix[1, 3];
                fourthMinor[2, 0] = matrix[2, 1]; fourthMinor[2, 1] = matrix[2, 2]; fourthMinor[2, 2] = matrix[2, 3];


                //Подсчет первого алг. дополнения
                generalLine = firstMinor[0, 0] * firstMinor[1, 1] * firstMinor[2, 2];
                generalFirstTriangle = firstMinor[2, 0] * firstMinor[0, 1] * firstMinor[1, 2];
                generalSecondTriangle = firstMinor[0, 2] * firstMinor[1, 0] * firstMinor[2, 1];

                secondLine = firstMinor[2, 0] * firstMinor[1, 1] * firstMinor[0, 2];
                secondFirstTriangle = firstMinor[0, 0] * firstMinor[2, 1] * firstMinor[1, 2];
                secondSecondTriangle = firstMinor[2, 2] * firstMinor[1, 0] * firstMinor[0, 1];

                resultDet = matrix[0, 0] * ((generalLine + generalFirstTriangle + generalSecondTriangle) - (secondLine + secondFirstTriangle + secondSecondTriangle));

                //Подсчет второго алг. дополнения
                generalLine = secondMinor[0, 0] * secondMinor[1, 1] * secondMinor[2, 2];
                generalFirstTriangle = secondMinor[2, 0] * secondMinor[0, 1] * secondMinor[1, 2];
                generalSecondTriangle = secondMinor[0, 2] * secondMinor[1, 0] * secondMinor[2, 1];

                secondLine = secondMinor[2, 0] * secondMinor[1, 1] * secondMinor[0, 2];
                secondFirstTriangle = secondMinor[0, 0] * secondMinor[2, 1] * secondMinor[1, 2];
                secondSecondTriangle = secondMinor[2, 2] * secondMinor[1, 0] * secondMinor[0, 1];

                resultDet += matrix[1, 0] * (-1) * ((generalLine + generalFirstTriangle + generalSecondTriangle) - (secondLine + secondFirstTriangle + secondSecondTriangle));

                //Подсчет третьего алг. дополнения
                generalLine = thirdMinor[0, 0] * thirdMinor[1, 1] * thirdMinor[2, 2];
                generalFirstTriangle = thirdMinor[2, 0] * thirdMinor[0, 1] * thirdMinor[1, 2];
                generalSecondTriangle = thirdMinor[0, 2] * thirdMinor[1, 0] * thirdMinor[2, 1];

                secondLine = thirdMinor[2, 0] * thirdMinor[1, 1] * thirdMinor[0, 2];
                secondFirstTriangle = thirdMinor[0, 0] * thirdMinor[2, 1] * thirdMinor[1, 2];
                secondSecondTriangle = thirdMinor[2, 2] * thirdMinor[1, 0] * thirdMinor[0, 1];

                resultDet += matrix[2, 0] * ((generalLine + generalFirstTriangle + generalSecondTriangle) - (secondLine + secondFirstTriangle + secondSecondTriangle));

                //Подсчет четвертого алг. дополнения
                generalLine = fourthMinor[0, 0] * fourthMinor[1, 1] * fourthMinor[2, 2];
                generalFirstTriangle = fourthMinor[2, 0] * fourthMinor[0, 1] * fourthMinor[1, 2];
                generalSecondTriangle = fourthMinor[0, 2] * fourthMinor[1, 0] * fourthMinor[2, 1];

                secondLine = fourthMinor[2, 0] * fourthMinor[1, 1] * fourthMinor[0, 2];
                secondFirstTriangle = fourthMinor[0, 0] * fourthMinor[2, 1] * fourthMinor[1, 2];
                secondSecondTriangle = fourthMinor[2, 2] * fourthMinor[1, 0] * fourthMinor[0, 1];

                resultDet += matrix[3, 0] * (-1) * ((generalLine + generalFirstTriangle + generalSecondTriangle) - (secondLine + secondFirstTriangle + secondSecondTriangle));
            }

            if (matrix.GetLength(0) != matrix.GetLength(1) || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
            {
                Console.WriteLine("The Matrix was entered ");
                Console.WriteLine("The Matrixes nust be square and equal!");
            }
            return resultDet;
        }

        public static double[,] Transposition(double[,] matrix)
        {

            return resultMatrix;
        }
    }
}
