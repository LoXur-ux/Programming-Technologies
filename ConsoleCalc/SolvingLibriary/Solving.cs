using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvingLibriary
{
    public class Solving
    {
        public static double Main(double numA, double numB, string method)
        {
            switch (method)
            {
                case "+":
                    return numA + numB;
                case "-":
                    return numA - numB;
                case "*":
                    return numA * numB;
                case "/":
                    {
                        if (numB == 0)
                        {
                            Console.WriteLine(" -- Деление на ноль невозможно. Результату присвоено значение NaN (не число) --");
                            return double.NaN;
                        }
                        else
                            return numA / numB;
                    }
                case "^":
                    return Math.Pow(numA, numB);
                case "√":
                    return Math.Pow(numA, 1.0 / numB);
                case "%":
                    {
                        if (numB == 0)
                        {
                            return 0;
                        }
                        return numA / numB;
                    }
                case "!":
                    {
                        int k = (int)numA;
                        double res = 1;
                        for (int i = 2; i <= k; i++)
                            res *= i;
                        return res;
                    }

                default:
                    return 0;
            }
        }

        public static void Info() // Вывод домтупных команд с объяснением
        {
            Console.WriteLine("\n\t\t Help#");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" -Список комманд и их особенности-");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" -- add - addition -");
            Console.ResetColor();
            Console.WriteLine(" команда выполняет сложение двух чисел A и B --");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" -- sub - subtraction -");
            Console.ResetColor();
            Console.WriteLine(" команда выполняет вычитание двух чисел из A B");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" -- mul - multiplication -");
            Console.ResetColor();
            Console.WriteLine(" команда выполняет умножение двух чисел A и B --");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" -- div - division -");
            Console.ResetColor();
            Console.Write(" команда выполняет деление двух чисел A на B,");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n   если число B равно нулю, результату будет присвоено NaN (не число) --");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" -- pow - power -");
            Console.ResetColor();
            Console.WriteLine(" команда выполняет возведение числа A в B --");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" -- roo - root -");
            Console.ResetColor();
            Console.WriteLine(" команда находит корень B числа A --");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" -- per - percent -");
            Console.ResetColor();
            Console.Write(" команда находит процент числа B относительно A,");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n   если число B равно нулю, результату будет присвоено значение нуля --");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" -- fac - factorial -");
            Console.ResetColor();
            Console.WriteLine(" команда находит факториал числа A --");
        }
    }
}
