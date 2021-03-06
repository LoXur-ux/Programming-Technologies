using System;
using SolvingLibriary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    class Program
    {
        public static double numA;
        public static double numB;
        public static double result = 0;
        public static double preResult = 0;
        
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tКалькулятор Ultimate#\n\n");

            while (true) // Цикл для бесконечной работы программы
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" -- Список команд:" +
                    "\n -- help - Вывод команд и их описания --" +
                    "\n -- exit - Закрыть программу --" +
                    "\n -- add - Вызов метод сложения --\t\tA+B" +
                    "\n -- sub - Вызов метода вычитания --\t\tA-B" +
                    "\n -- mul - Вызов метода перемножения --\t\tA*B" +
                    "\n -- div - Вызов метода деления --\t\tA/B" +
                    "\n -- pow - Вызов метода возведения в степень --\tA^B" +
                    "\n -- roo - Вызов метода нахождения корня --\tB√A" +
                    "\n -- per - Вызов метода нахождения процента --\tA%B" +
                    "\n -- fac - Вызов метода нахождения факториала -- A!");
                Console.ResetColor();

                Console.Write("Введите команду: ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                string command = Console.ReadLine().Trim();
                Console.ResetColor();

                switch (command)
                {
                    case "help":
                        {
                            Help();
                            break;
                        }
                    case "exit":
                        return;
                    case "add":
                        {
                            Choice("+");
                            break;
                        }
                    case "sub":
                        {
                            Choice("-");
                            break;
                        }
                    case "mul":
                        {
                            Choice("*");
                            break;
                        }
                    case "div":
                        {
                            Choice("/");
                            break;
                        }
                    case "pow":
                        {
                            Choice("^");
                            break;
                        }
                    case "roo":
                        {
                            Choice("√");
                            break;
                        }
                    case "per":
                        {
                            Choice("%");
                            break;
                        }
                    case "fac":
                        {
                            numA = EnterNum("A");

                            preResult = result;
                            result = Solving.Main(numA, 0, "!");

                            OutputResult();
                            break;
                        }
                    default:
                        {
                            UnknownCommand();
                            break;
                        }
                }
            }
        }

        static void Choice(string choice) // Вызывает библитеку для подсчета требуемого выражения.
        {
            numA = EnterNum("A");
            numB = EnterNum("B");

            preResult = result;
            result = Solving.Main(numA, numB, choice);

            OutputResult();
        }

        static void OutputResult() // Выводит результат.
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Ответ: {result}");
            Console.ResetColor();
            Console.WriteLine("\n -- Для продолжения нажмите Enter --");
            Console.ReadLine();
            ConsoleClear();
        }

        static double EnterNum(string letter) // Ввод значения переменной.
        {
            bool again = true; // Проверка икслючений / Повторение ввода
            double result = 0;

            do
            {
                again = false;
                Console.Write($"Введите значение ({letter}): ");
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    result = double.Parse(Console.ReadLine().Trim());
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ResetColor();
                    Console.WriteLine(" -- Произошла ошибка. Возможно, вы ввели не цифру или записали дробь через '.' (точку),\n" +
                        "необходимо обозначать дроби через ',' (запятую) --");

                    Console.WriteLine("\n\n -- Введите значение занаво --");
                    again = true;
                }

            } while (again);

            return result;
        }

        static void Help() //Коменда "помощь" - выводит все доступные команды и их особенности.
        {
            Solving.Info();
            ConsoleClear();
        }

        static void UnknownCommand() // Неизвестная команда.
        {
            Console.WriteLine("Команда введена неверно попробуйте снова!");
            ConsoleClear();
        }

        static void ConsoleClear() // Очистка консоли.
        {
            Console.Write(" Очистить консоль? y/n: ");
            string command = Console.ReadLine().Trim();
            if (command == "Y" || command == "y" || command == "yes")
            {
                Console.Clear();
                Console.WriteLine("\t\tКалькулятор Ultimate#\n\n");
            }
            else
                Console.WriteLine("\n");
        }
    }
}
