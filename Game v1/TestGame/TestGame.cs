using System;
using GameSetups;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.Eventing.Reader;

namespace Test
{
    class TestGame
    {

        // Переменные:
        // Персонаж:
        static string nameCharactr;// Имя Персонажа и название цейва
        static double hp = 100;    // Кол-во ХП
        static double hpMax = 100; // Максимальное кол-во ХП
        static double atk = 10;    // Атака
        static double mana = 5;    // Кол-во маны
        static double manaMax = 5; // Максимальное кол-во маны
        static double snake = 0;   // Скрытность

        static int live = 1;       // Жизнь
        static int secondLive = 1; // Второй шанс
        static int thirdLive = 0;  // Амулет воскрешения


        // Предметы и инвентарь:
        static int leftHend = 0;    // Экип оружее в левой руке (+) / Щит (-)
        static int rightHend = 0;   // Экип оружее в правой руке
        static int equipArmor = 0;       // Экип броня

        static int key = 0;          // Кол-во ключей

        // Другое:
        static string nameBoss = "Виодмун Тлейфей";     // Имя Глав Босса
        static string nameCastle = "Большой зал";       // Потом - Кретельский Зал

        // HardMod:
        static int hardMod;
        static int food = 500;          // Еда на складе.
        static int water = 800;         // Вода на складе.
        static int hunger = 100;        // Голод.
        static int hungerMax = 100;     // Максимум голод. (100% = полная удовлетворенность).
        static int thirst = 200;        // Жажда.
        static int thirstMax = 200;     // Максимальная жажда. (100% = полная удовлетворенность).
        static int fatigue = 100;       // Усталость.
        static int fatigueMax = 100;    // Максимальная усталость. (100% = полная удовлетворенность).

        ///<summary>
        /// Устанавливает цвет консольного текста.
        /// x - Основной цвет;
        /// x.1 - Темная вариация.
        /// 1 - Синий;
        /// 2 - Красный;
        /// 3 - Серый;
        /// 4 - Голубой;
        /// 5 - Зеленый;
        /// 6 - Берюзовый;
        /// 
        /// 10 - Возврат к стандартному значению.
        ///</summary>
        static void ConsoleColor(double color)
        {
            
            if (color == 1)
                Console.ForegroundColor = System.ConsoleColor.Blue;
            else if (color == 1.1)
                Console.ForegroundColor = System.ConsoleColor.DarkBlue;
            else if (color == 2)
                Console.ForegroundColor = System.ConsoleColor.Red;
            else if (color == 2.1)
                Console.ForegroundColor = System.ConsoleColor.DarkRed;
            else if (color == 3)
                Console.ForegroundColor = System.ConsoleColor.Gray;
            else if (color == 3.1)
                Console.ForegroundColor = System.ConsoleColor.DarkGray;
            else if (color == 4)
                Console.ForegroundColor = System.ConsoleColor.Cyan;
            else if (color == 4.1)
                Console.ForegroundColor = System.ConsoleColor.DarkCyan;
            else if (color == 5)
                Console.ForegroundColor = System.ConsoleColor.Green;
            else if (color == 5.1)
                Console.ForegroundColor = System.ConsoleColor.DarkGreen;
            else if (color == 6)
                Console.ForegroundColor = System.ConsoleColor.Magenta;
            else if (color == 6.1)
                Console.ForegroundColor = System.ConsoleColor.DarkMagenta;
            else if (color == 10)
                Console.ResetColor();
            else
                Console.ResetColor();
        }



        static void BattleRoom(string door)
        {

            int mobMana = 0;
            double mobHP = double.Parse(MobStats.Stat(int.Parse(door), 2));     // Здоровье противника.
            double mobAtk = double.Parse(MobStats.Stat(int.Parse(door), 3));    // Атака противника.
            if (MobStats.Stat(int.Parse(door), 4) != "")
                mobMana = int.Parse(MobStats.Stat(int.Parse(door), 4));         // Мана противника при ее наличии.
            if (key > 2)                                                            // Статистика видна только с третьего ранга.
            {
                Console.WriteLine($"Вы чувствуете противников и их способности." +
                    $"\nУ противника следующие характеристики:");
                ConsoleColor(3);
                Console.Write($"Здоровье: {mobHP};" +
                    $"\nАтака: {mobAtk};");
                if (MobStats.Stat(int.Parse(door), 4) != "")
                    Console.WriteLine($"Мана: {mobMana}");
                if (key > 3)                                                        // Атрибуты видны только с четвертого ранга.
                {
                    if (MobStats.Stat(int.Parse(door), 5) != "")
                        Console.WriteLine($"Атрибуты противника: {MobStats.Stat(int.Parse(door), 5)};");
                    if (MobStats.Stat(int.Parse(door), 6) != "")
                        Console.WriteLine($"Дебаф атрибуты: {MobStats.Stat(int.Parse(door), 6)};");
                }
                ConsoleColor(10);
            }

            





            if (key > 1)
            {
                Console.WriteLine("Вы можете выбрать, каким способом проходить комнату." +
                    "\n1. Самостоятельно;" +
                    "\n2. Отдать свой разум Берсерку;" +
                    "\n3. Отправить Клона." +
                    "\n\n  *Что вы выберете?*");
                string route = Console.ReadLine();

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();

                switch (route)
                {
                    case "1":
                        {
                            Console.WriteLine($"*Вы решаете пойти самостоятельно*");

                            break;
                        }

                    default:
                        break;
                }
            }
        }








        static void Main()
        {
            
            

        }
        
    }
}
