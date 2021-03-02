using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GameSetups;

namespace Game_v1
{
    class Game
    {
        // Пометки:
        // !!      - требуется балансировка или доработка.
        // !!!     - требуется пересмотр процесса.
        // !!(!)   - требуется обдумка

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


        // Данные о том, есть ли оружие.
        static int HaveWeapon(int numWeapon)
        {
            int[] haveWeapon = new int[15]
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            return haveWeapon[numWeapon];
        }
        static void PersonalRoom()
        {

            Console.WriteLine("Вы осматриваетесь." +
            "\nВы чувствуете, что здесь безопасно." +
            "\nБогато украшеная комната с огромной, на вид, очень мягкой кроватью." +
            "\nВсе обделанно так, будто здесь должен жить какой-нибудь [Король]." +
            "\nСлева от вас [Кухня], справа коридор, пройдя по нему можно попасть в [Оружейную] и [Уборную]." +
            "\nБольшое количество столов, подушек и шкафчиков - все, кажется, сделано так, чтобы вам было максимально комфортно.");
            Console.WriteLine("\n\nНажмите любую клавишу для продолжения...");
            Console.ReadLine();
            Console.Clear();

            while (true)
            {
                Console.WriteLine("*Что делать?*" +
                    "\nПоспать (1);" +
                    "\nПойти на Кухню (2);" +
                    "\nПойти в Оружейную (3);" +
                    "\nВернуться в [Глаынй Зал] (0);");

                string route = Console.ReadLine();
                Console.WriteLine("\n\nНажмите любую клавишу для продолжения...");
                Console.ReadLine();
                Console.Clear();

                switch (route)
                {
                    case "1": // Сон
                        {

                            break;
                        }
                    case "2": // Кухня
                        {
                            break;
                        }
                    case "3": // Оружейная
                        {
                            WeaponRoom();
                            break;
                        }
                    case "exit":
                        {
                            return;
                        }
                    case "0":
                        goto case "exit";

                    default:
                        {
                            Console.WriteLine("Такой комнаты не существует");
                            break;
                        }
                }
            }



            static void WeaponRoom() //     !!!!!!!!    СКОПИРОВАТЬ ТОЛЬКО ВЕАПОН   !!!!!!!!
            {

                while (true)
                {
                    Console.WriteLine("Что вам нужно?" +
                    "\nОружие? (1)" +
                    "\nЩиты? (2)" +
                    "\nБроня? (3)" +
                    "\nИли ввы хотите уйти? (exit)");

                    string route = Console.ReadLine();
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadLine();
                    Console.Clear();

                    switch (route)
                    {
                        case "1": // Оружие
                            {
                                Console.WriteLine("*Вы подходите к Стелажам с Оружием*" +
                                    "\n*Хотите осмотреть Оружее?*");

                                route = Console.ReadLine();
                                if (route == "да" || route == "Да" || route == "1" || route == "y")
                                {
                                    for (int i = 0; i < int.Parse(Inventory.Weapon(0, 10)); i++)
                                        Console.WriteLine((i + 1) + " Название: " + Inventory.Weapon(i, 0));

                                    Console.WriteLine("Выберете оружее, характеристики и описание которого хотите посмотреть.");
                                    int choiceWeapon = int.Parse(Console.ReadLine());
                                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                                    Console.ReadLine();
                                    Console.Clear();

                                    Console.WriteLine("Название: " + Inventory.Weapon(choiceWeapon - 1, 0));
                                    Console.WriteLine("Урон: " + Inventory.Weapon(choiceWeapon - 1, 1));
                                    if (Inventory.Weapon(choiceWeapon - 1, 2) != "")
                                        Console.WriteLine("Атрибут: " + Inventory.Weapon(choiceWeapon - 1, 2));
                                    Console.WriteLine("Тип: " + Inventory.Weapon(choiceWeapon - 1, 3));
                                    Console.WriteLine("Описание: " + Inventory.Weapon(choiceWeapon - 1, 4));

                                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                                    Console.ReadLine();
                                    Console.Clear();

                                    Console.WriteLine("*Хотите поменять текущее оружее?*");

                                    route = Console.ReadLine();

                                    if (route == "да" || route == "Да" || route == "1" || route == "y")
                                    {
                                        Console.WriteLine("На какое?");
                                        for (int i = 0; i < int.Parse(Inventory.Weapon(0, 10)); i++)
                                            Console.WriteLine((i + 1) + " Название: " + Inventory.Weapon(i, 0));

                                        choiceWeapon = int.Parse(Console.ReadLine());
                                        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                                        Console.ReadLine();
                                        Console.Clear();

                                        ChoiceWeapon(choiceWeapon);
                                        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                                        Console.ReadLine();
                                        Console.Clear();

                                    }
                                    else
                                        Console.WriteLine($"*Вы отказались*");
                                }
                                else
                                    Console.WriteLine($"*Вы отказались*");

                                break;
                            }

                        case "2": // Щиты
                            {
                                Console.WriteLine("*Вы подходите к Стелажам с Щитами*" +
                                    "\n*Хотите их осмотреть?*");

                                route = Console.ReadLine();
                                if (route == "да" || route == "Да" || route == "1" || route == "y")
                                {
                                    for (int i = 0; i < int.Parse(Inventory.Shild(0, 10)); i++)
                                        Console.WriteLine((i + 1) + " Название: " + Inventory.Shild(i, 0));

                                    Console.WriteLine("Выберете оружее, характеристики и описание которого хотите посмотреть.");
                                    int choiceShild = int.Parse(Console.ReadLine()) - 1;

                                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                                    Console.ReadLine();
                                    Console.Clear();

                                    Console.WriteLine("Название: " + Inventory.Shild(choiceShild, 0));
                                    Console.WriteLine("Защита: " + Inventory.Shild(choiceShild, 1) + "%");
                                    if (Inventory.Shild(choiceShild, 2) != "")
                                        Console.WriteLine("Атрибут: " + Inventory.Shild(choiceShild, 2));
                                    Console.WriteLine("Описание: " + Inventory.Shild(choiceShild, 3));

                                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                                    Console.ReadLine();
                                    Console.Clear();

                                    Console.WriteLine("*Хотите взять Щит?*");
                                    route = Console.ReadLine();
                                    if (route == "да" || route == "Да" || route == "1" || route == "y")
                                    {
                                        Console.WriteLine("*На какое?*");
                                        for (int i = 0; i < int.Parse(Inventory.Shild(0, 10)); i++)
                                            Console.WriteLine($"{i + 1} Название: {Inventory.Shild(i, 0)}");
                                        choiceShild = int.Parse(Console.ReadLine());
                                        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                                        Console.ReadLine();
                                        Console.Clear();

                                        ChoiсeShild(choiceShild);
                                        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                }
                                else
                                    Console.WriteLine($"*Вы отказались*");

                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine($"*Вы подходите к Стелажам с Броней*" +
                                    $"\n*Хотите осмотреть Броню?*");

                                route = Console.ReadLine();
                                if (route == "да" || route == "Да" || route == "1" || route == "y")
                                {
                                    for (int i = 0; i < int.Parse(Inventory.Armor(0, 10)); i++)
                                        Console.WriteLine($"{i + 1} Название: {Inventory.Armor(i, 0)}.");
                                    Console.WriteLine($"*Выберете Броню, характеристики которой хотите посмотреть*");
                                    int choiceArmor = int.Parse(Console.ReadLine());

                                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                                    Console.ReadLine();
                                    Console.Clear();

                                    Console.WriteLine($"Название: {Inventory.Armor(choiceArmor - 1, 0)}." +
                                        $"\nЗащита: {Inventory.Armor(choiceArmor - 1, 1)}." +
                                        $"\nИздаваемый шум: {Inventory.Armor(choiceArmor - 1, 2)}.");
                                    if (Inventory.Armor(choiceArmor - 1, 3) != "")
                                        Console.WriteLine($"Атрибут Защиты: {Inventory.Armor(choiceArmor - 1, 3)}.");
                                    if (Inventory.Armor(choiceArmor - 1, 4) != "")
                                        Console.WriteLine($"Атрибут Дэбафа: {Inventory.Armor(choiceArmor - 1, 4)}");
                                    Console.WriteLine($"Описание: \nInventory.Armor(choiceArmor - 1, 5)");

                                    Console.WriteLine($"*Хотите экипировать выбранную Броню?*");
                                    route = Console.ReadLine();

                                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                                    Console.ReadLine();
                                    Console.Clear();

                                    if (route == "да" || route == "Да" || route == "1" || route == "y")
                                    {
                                        // При не надетой броне
                                        if (equipArmor == 0)
                                        {
                                            equipArmor = choiceArmor;
                                            Console.WriteLine($"*Вы экипировали {Inventory.Armor(equipArmor, 0)}.*");
                                            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                                            Console.ReadLine();
                                            Console.Clear();
                                        }
                                        // При занятом слоте брони.
                                        else
                                        {
                                            Console.WriteLine($"На вас уже надета Броня - {Inventory.Armor(equipArmor, 0)}." +
                                                $"*Хотите заменить ее?*");
                                            if (route == "да" || route == "Да" || route == "1" || route == "y")
                                            {
                                                equipArmor = choiceArmor;
                                                Console.WriteLine($"*Вы экипировали {Inventory.Armor(equipArmor, 0)}.*");
                                                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                                                Console.ReadLine();
                                                Console.Clear();
                                            }
                                            else
                                                Console.WriteLine($"*Вы отказались*");
                                        }
                                    }
                                    else
                                        Console.WriteLine($"*Вы отказались*");
                                }
                                else
                                    Console.WriteLine($"*Вы отказались*");
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }


            static string Nightmers(int maxKey, int num)
            {
                string[,] nightmers = new string[10, 3];

                /*
                 * [i, *] - Количество Ключей
                 * [*, j] - Номер кашмара
                 */
                nightmers[0, 0] = "";

                nightmers[1, 0] = "";

                nightmers[2, 0] = "";

                nightmers[3, 0] = "";

                nightmers[4, 0] = "";

                nightmers[5, 0] = "";

                nightmers[6, 0] = "";

                nightmers[7, 0] = "";

                nightmers[8, 0] = "";

                nightmers[9, 0] = "";

                return nightmers[maxKey - 1, num - 1];
            }

            static void ChoiceWeapon(int choiceWeapon)
            {
                string route;
                // При свобожных руках
                if (leftHend == 0 && rightHend == 0)
                {
                    Console.WriteLine("Обе ваших Руки свободны.");

                    if (Inventory.Weapon(choiceWeapon - 1, 3) == "Двуручное")
                    {
                        Console.WriteLine("Обе руки будут заняты." +
                            "\nПринять?");
                        route = Console.ReadLine();
                        if (route == "да" || route == "Да" || route == "1" || route == "y")
                        {
                            Console.WriteLine($"Вы экиперуете {Inventory.Weapon(choiceWeapon - 1, 0)} в обе руки." +
                                $"\n*Обе руки заняты*");
                            leftHend = choiceWeapon;
                            rightHend = choiceWeapon;
                        }
                        else
                            Console.WriteLine("*Вы отказались*");
                    }
                    else
                    {
                        Console.WriteLine($"*Для какой руки вы хотите экипировать {Inventory.Weapon(choiceWeapon - 1, 0)}*");
                        Console.WriteLine("Left/Right || l/r || Левая/Правая || л/п");
                        route = Console.ReadLine();

                        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                        Console.ReadLine();
                        Console.Clear();

                        switch (route)
                        {
                            case "Left":
                                {
                                    leftHend = choiceWeapon;
                                    Console.WriteLine($"Вы экипировали {Inventory.Weapon(choiceWeapon - 1, 0)} для Левой руки.");
                                    break;
                                }
                            case "Right":
                                {
                                    rightHend = choiceWeapon;
                                    Console.WriteLine($"Вы экипировали {Inventory.Weapon(choiceWeapon - 1, 0)} для Правой руки.");
                                    break;
                                }
                            case "l":
                                goto case "Left";
                            case "r":
                                goto case "Right";
                            case "л":
                                goto case "Left";
                            case "п":
                                goto case "Right";
                            case "Левая":
                                goto case "Left";
                            case "Правая":
                                goto case "Right";
                            default:
                                {
                                    Console.WriteLine("*Выбор некоректен*");
                                    break;
                                }
                        }
                    }
                }
                else
                {
                    if (leftHend >= 0 && rightHend >= 0)
                    {
                        // При занятых обеих руках Двуручным оружием.
                        if (leftHend == rightHend && Inventory.Weapon(rightHend, 3) == "Двуручное")
                        {
                            Console.WriteLine($"Обе ваших руки заняты {Inventory.Weapon(rightHend, 0)}." +
                                $"\nЧтобы взять выбранное оружие, вам необходимо оставить то, которое сейчас с вами." +
                                $"\nПринять?");
                            route = Console.ReadLine();
                            if (route == "да" || route == "Да" || route == "1" || route == "y")
                            {
                                // При занятых обеих руках Двуручным оружием. Выбранное - двуручное
                                if (Inventory.Weapon(choiceWeapon - 1, 3) == "Двуручное")
                                {
                                    leftHend = choiceWeapon;
                                    rightHend = choiceWeapon;
                                    Console.WriteLine($"Вы экиперуете {Inventory.Weapon(choiceWeapon - 1, 0)}*");
                                }
                                // Выбранное - одноручное 
                                else
                                {
                                    leftHend = 0;
                                    rightHend = 0;
                                    Console.WriteLine($"*В какую руку вы хотите взять {Inventory.Weapon(choiceWeapon - 1, 0)}*");
                                    Console.WriteLine("Left/Right || l/r || Левая/Правая || л/п");
                                    route = Console.ReadLine();

                                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                                    Console.ReadLine();
                                    Console.Clear();

                                    switch (route)
                                    {
                                        case "Left":
                                            {
                                                leftHend = choiceWeapon;
                                                Console.WriteLine($"Вы экипировали {Inventory.Weapon(choiceWeapon - 1, 0)} для Левой руки.");
                                                break;
                                            }
                                        case "Right":
                                            {
                                                rightHend = choiceWeapon;
                                                Console.WriteLine($"Вы экипировали {Inventory.Weapon(choiceWeapon - 1, 0)} для Правой руки.");
                                                break;
                                            }
                                        case "l":
                                            goto case "Left";
                                        case "r":
                                            goto case "Right";
                                        case "л":
                                            goto case "Left";
                                        case "п":
                                            goto case "Right";
                                        case "Левая":
                                            goto case "Left";
                                        case "Правая":
                                            goto case "Right";
                                        default:
                                            {
                                                Console.WriteLine("*Выбор некоректен*");
                                                break;
                                            }
                                    }

                                }
                            }
                            else
                                Console.WriteLine("*Вы отказались*");
                        }
                        else
                        {
                            Console.WriteLine($"В правой руке у вас экиперовано {Inventory.Weapon(rightHend, 0)}," +
                                $"\nа в левой {Inventory.Weapon(leftHend, 0)}");
                            Console.WriteLine($"*В какую руку вы хотите взять {Inventory.Weapon(choiceWeapon - 1, 0)}?*");
                            Console.WriteLine("Left/Right || l/r || Левая/Правая || л/п");
                            route = Console.ReadLine();

                            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                            Console.ReadKey();
                            Console.Clear();

                            switch (route)
                            {
                                case "Left":
                                    {
                                        leftHend = choiceWeapon;
                                        Console.WriteLine($"Вы экипировали {Inventory.Weapon(choiceWeapon - 1, 0)} для Левой руки.");
                                        break;
                                    }
                                case "Right":
                                    {
                                        rightHend = choiceWeapon;
                                        Console.WriteLine($"Вы экипировали {Inventory.Weapon(choiceWeapon - 1, 0)} для Правой руки.");
                                        break;
                                    }
                                case "l":
                                    goto case "Left";
                                case "r":
                                    goto case "Right";
                                case "л":
                                    goto case "Left";
                                case "п":
                                    goto case "Right";
                                case "Левая":
                                    goto case "Left";
                                case "Правая":
                                    goto case "Right";
                                default:
                                    {
                                        Console.WriteLine("*Выбор некоректен*");
                                        break;
                                    }
                            }
                        }
                    }
                    else
                    {
                        // При занятой левой руке
                        if (leftHend >= 0)
                        {
                            Console.WriteLine($"Левая рука занята {Inventory.Weapon(leftHend, 0)}, " +
                                $"\nвы можете экипировать {Inventory.Weapon(choiceWeapon - 1, 0)} для Правой." +
                                $"\nили убрать оружие для Левой руки." +
                                $"\n*Экипировать в Правую?*");
                            route = Console.ReadLine();
                            if (route == "да" || route == "Да" || route == "1" || route == "y")
                            {
                                rightHend = choiceWeapon;
                                Console.WriteLine($"Вы экипировали {Inventory.Weapon(choiceWeapon - 1, 0)} для Правой руки.");
                            }
                            else
                            {
                                Console.WriteLine("*Снять оружие с Левой и использовать выбранное?*");
                                if (route == "да" || route == "Да" || route == "1" || route == "y")
                                {
                                    leftHend = choiceWeapon;
                                    Console.WriteLine($"Вы экипировали {Inventory.Weapon(choiceWeapon - 1, 0)} для Левой руки.");
                                }
                                else
                                    Console.WriteLine("*Вы отказались экипировать это оружие*");
                            }

                        }
                        // При занятой правой руке
                        if (rightHend >= 0)
                        {
                            Console.WriteLine($"Правая рука занята {Inventory.Weapon(rightHend, 0)}, " +
                                $"\nвы можете экипировать {Inventory.Weapon(choiceWeapon - 1, 0)} для Левой." +
                                $"\nили убрать оружие для Правой руки." +
                                $"\n*Экипировать для Левой?*");
                            route = Console.ReadLine();
                            if (route == "да" || route == "Да" || route == "1" || route == "y")
                            {
                                leftHend = choiceWeapon;
                                Console.WriteLine($"Вы экипировали {Inventory.Weapon(choiceWeapon - 1, 0)} для Левой руки.");
                            }
                            else
                            {
                                Console.WriteLine("*Снять оружие для Правой и экипировать для нее?*");
                                if (route == "да" || route == "Да" || route == "1" || route == "y")
                                {
                                    rightHend = choiceWeapon;
                                    Console.WriteLine($"Вы экипировали {Inventory.Weapon(choiceWeapon - 1, 0)} для Правой руки.");
                                }
                                else
                                    Console.WriteLine("*Вы отказались экипировать это оружие*");
                            }
                        }
                    }
                }
            }
            static void ChoiсeShild(int choiceShild)
            {
                string route;
                // При свободной левой руке.
                if (leftHend == 0)
                {
                    Console.WriteLine($"*Вы можете экипировать {Inventory.Shild(choiceShild, 0)} для Левой руки*" +
                        $"\n*Экипировать?*");
                    route = Console.ReadLine();
                    if (route == "да" || route == "Да" || route == "1" || route == "y")
                    {
                        leftHend = choiceShild * -1;
                        Console.WriteLine($"*Вы экипировали {Inventory.Shild(leftHend * -1, 0)} для Левой руки*");

                        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                        Console.WriteLine("*Вы отказались*");
                }
                // При экипированном оружии.
                else if (leftHend > 0)
                {
                    // При оружии типа "Двуручное"
                    if (Inventory.Weapon(leftHend, 3) == "Двуручное")
                    {
                        Console.WriteLine($"У вас экипировано Двуручное оружее - {Inventory.Weapon(leftHend, 0)}." +
                            $"\n*Заменить его? (Экипированное оружее будет оставлено на складе)*");
                        route = Console.ReadLine();
                        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                        Console.ReadLine();
                        Console.Clear();

                        if (route == "да" || route == "Да" || route == "1" || route == "y")
                        {
                            leftHend = choiceShild * -1;
                            rightHend = 0;
                            Console.WriteLine("*Вы экипировали Щит*");
                        }
                        else
                            Console.WriteLine($"*Вы отказались*");
                    }
                    else
                    {
                        Console.WriteLine($"Для Левой руки уже экипировано Оружее - {Inventory.Weapon(leftHend, 0)}." +
                            $"\n*Заменить его?*");
                        route = Console.ReadLine();
                        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                        Console.ReadLine();
                        Console.Clear();

                        if (route == "да" || route == "Да" || route == "1" || route == "y")
                        {
                            leftHend = choiceShild * -1;
                            Console.WriteLine($"*Вы экипировали Щит*");
                        }
                        else
                            Console.WriteLine($"*Вы отказались*");
                    }
                }
                // При экипированном другом щите.
                else
                {
                    Console.WriteLine($"У вас уже экипирован Щит - {Inventory.Shild(leftHend * -1, 0)}." +
                        $"\n*Заменить его?*");
                    route = Console.ReadLine();
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadLine();
                    Console.Clear();

                    if (route == "да" || route == "Да" || route == "1" || route == "y")
                    {
                        leftHend = choiceShild * -1;
                        Console.WriteLine($"*Вы экипировали Щит*");
                    }
                    else
                        Console.WriteLine($"*Вы отказались*");
                }
            }
        }


        // Сохранения                   !!(!)  Переделать все сейвы/Подогнать под новое
        static void CreateSaveFile()
        {
            string folder;
            // Создание файлов-сохранений.
            for (int i = 0; i < 5; i++)
            {
                folder = @$"C:\Users\{Environment.UserName}\Documents\My Games\NewGame\Saves\save{i + 1}";
                Directory.CreateDirectory(folder);
                string pathSave = @$"C:\Users\danma\Documents\My Games\NewGame\Saves\save{i + 1}\SaveChar.save";
                using (FileStream fileSave = new FileStream(pathSave, FileMode.OpenOrCreate));
                pathSave = @$"C:\Users\danma\Documents\My Games\NewGame\Saves\save{i + 1}\SaveInventory.save";
                using (FileStream fileSave = new FileStream(pathSave, FileMode.OpenOrCreate));
                pathSave = @$"C:\Users\danma\Documents\My Games\NewGame\Saves\save{i + 1}\SaveHardMod.save";
                using (FileStream fileSave = new FileStream(pathSave, FileMode.OpenOrCreate));
            }
        }
        static void ShowSave()
        {
            // Показ файлов-сохранений.
            for (int i = 0; i < 5; i++)
            {
                string pathSave = @$"C:\Users\{Environment.UserName}\Documents\My Games\NewGame\Save{i + 1}.save";
                using (FileStream fileSave = new FileStream(pathSave, FileMode.Open))
                using (StreamReader readerSave = new StreamReader(fileSave))
                {
                    if (readerSave.ReadToEnd() == "")
                    {
                        Console.WriteLine($"№{i + 1} Name: []");
                        Console.WriteLine("*Файл пуст*\n");
                    }
                    else
                    {
                        fileSave.Seek(0, 0);
                        Console.WriteLine($"№{i + 1} Name: [{readerSave.ReadLine()}]" +
                            $"\nameCharactr = {readerSave.ReadLine()}" +
                            $"\nhp = {readerSave.ReadLine()}" +
                            $"\natk = {readerSave.ReadLine()}" +
                            $"\nmana = {readerSave.ReadLine()}" +
                            $"\nsnake = {readerSave.ReadLine()}");
                    }
                }
            }
            Console.ReadKey();
        }
        static void SaveProcess(string numSave)
        {

            string pathSave = @$"C:\Users\{Environment.UserName}\Documents\My Games\NewGame\Save{numSave}.save";
            using (FileStream file = new FileStream(pathSave, FileMode.Open))
            using (StreamReader readerSave = new StreamReader(file))
            {
                // Если файл с сохранением пуст.
                if (readerSave.ReadToEnd() == "")
                {
                    Console.WriteLine("*Используется новое сохранение*");
                    for (int i = 0; i < 4; i++)
                    {
                        Thread.Sleep(450);
                        Console.Write("\t . ");
                    }

                    Console.Write("\nИмя Сохранения: ");
                    string nameSave = Console.ReadLine();

                    using (StreamWriter writerSave = new StreamWriter(file))
                    {
                        writerSave.WriteLine(nameSave + "\n" +
                           hp + "\n" +
                           atk);
                    }
                    Console.WriteLine("\n*Игра сохранена*\n");
                }
                else
                {
                    Console.WriteLine("*Сохранеие уже существует*");
                    Console.Write("*Перезаписать?*\n");
                    string choise = Console.ReadLine();
                    if (choise == "1" || choise == "y" || choise == "yes" || choise == "Да")
                    {
                        Console.Write("Имя Сохранения: ");
                        string nameSave = Console.ReadLine();

                        // Полная очистка файла.
                        file.SetLength(0);

                        Console.WriteLine("*Сохранение перезаписывается*");
                        for (int i = 0; i < 4; i++)
                        {
                            Thread.Sleep(450);
                            Console.Write("\t . ");
                        }

                        using (StreamWriter writerSave = new StreamWriter(file))
                        {
                            writerSave.WriteLine(nameSave + "\n" +
                               nameCharactr + "\n" +
                               hp + "\n" +
                               atk + "\n" +
                               mana + "\n" +
                               snake + "\n" +
                               live + "\n" +
                               secondLive + "\n" +
                               thirdLive + "\n" +

                               key + "\n" +

                               nameBoss + "\n" +
                               nameCastle);
                        }
                        Console.WriteLine("\n*Игра сохранена*\n");

                    }
                    else
                    {
                        Console.WriteLine("*Файл не был перезаписан*");
                    }
                }
            }
        }
        static void Save()
        {
            CreateSaveFile();
            ShowSave();
            Console.WriteLine("*Выберете номер сохранения*");
            string numSave = Console.ReadLine();

            SaveProcess(numSave);
        }
        static void LoadSave(string numSave)
        {
            // Загрузка сохранения.
            string pathSave = @$"C:\Users\{Environment.UserName}\Documents\My Games\NewGame\save{numSave}.save";

            Console.WriteLine("*Вы уверены?*" +
                "\nНе сохраненные данные будут утерены.");
            string route = Console.ReadLine();
            if (route == "да" || route == "Да" || route == "1" || route == "y")
            {
                using (FileStream file = new FileStream(pathSave, FileMode.Open))
                using (StreamReader readerSave = new StreamReader(file))
                {
                    file.Seek(0, 0);
                    string nameSave = readerSave.ReadLine();
                    nameCharactr = readerSave.ReadLine();
                    hp = double.Parse(readerSave.ReadLine());
                    atk = double.Parse(readerSave.ReadLine());
                    mana = double.Parse(readerSave.ReadLine());
                    snake = double.Parse(readerSave.ReadLine());
                    live = int.Parse(readerSave.ReadLine());
                    secondLive = int.Parse(readerSave.ReadLine());
                    thirdLive = int.Parse(readerSave.ReadLine());
                    key = int.Parse(readerSave.ReadLine());

                    nameBoss = readerSave.ReadLine();
                    nameCastle = readerSave.ReadLine();
                }
            }
        }


        


        // Магия
        static int HaveSpell(int numSpell)
        {   
            int[] haveSpell = new int[15]
            {0, 0, 0, 0 , 0, 0, 0, 0 ,0, 0, 0, 0, 0, 0, 0};
            return haveSpell[numSpell];
        }            //   !!!


        static void Begin()
        {
            CreateSaveFile();
            ShowSave();

            Console.WriteLine("*Введите номер сохранения*");
            string numSave = Console.ReadLine();
            LoadSave(numSave);
            if (key == 0)
            {
                Console.WriteLine("*Вы просыпаетесь.*" +
                "\n\n*Непонимая, что происходит вы решаете осмотреться.*" +
                "\n*Вокруг вас одна тьма, подождав несколько секунд, вы привыкаете к окружающему освещению.*" +
                "\n*Вы находитесь в коридоре, впереди вас он расширяется, а позади он кажется бесконечно длинным*" +
                "\n\n*Вы осматриваете себя.*" +
                "\n*На вас ничего нет кроме рваной рубашки и штанов.*" +
                "\n-Даже носков нет..." +
                "\n..." +
                "\n-Холодно..." +
                "\n*Вы выдыхаете и видите пар.*" +
                "\n\n*Вы понимаете, что нужно что-то делать.*" +
                "\nПойти вперед слишком банально, возможно, там опасно. Я же даже не знаю где я." +
                "\nЕсли пойду назад, может, выйду к выходу." +
                "\n **Куда вы направитесь?**");
                Console.Write("\n*Веперд (1) или Назад (2)* ");

                string route = Console.ReadLine();

                switch (route)
                {
                    case "1": // Решений пойти вперед
                        {
                            Console.Clear();
                            Console.WriteLine($"*Вы направляетесь вперед.*" +
                                "\nКоридор Впереди вас действительно расширяется." +
                                "\nОгромный овальный зал. Вы находитесь на втором этаже, на болконе. Зал похож на театр." +
                                "\nВнизу, кажется, сидят люди, но приглядевшись вы перестаете понимать есть ли они на самом деле. Они похожи на теней." +
                                "\nПолупрозрачные, как призраки, как мрачные тени, застрявшие меж измерений." +
                                "\nВ конце зала есть огромная дверь. Вся она покрыта неизвестными символами." +
                                "\n\nСлева и справа от вас есть лестницы вниз." +
                                "\n **К какой вы пойдете?**");
                            Console.WriteLine("Нажмите любую клавишу для продолжения...");
                            Console.ReadLine();
                            Console.Clear();


                            Console.WriteLine("\nВы подходите к лестнице и ужасаетесь." +
                                "\n\nВид кажется вам настолько отвратительным, что вы блюете." +
                                "\nТрупы...Запах гнили...Кровь...Обрубки человеческих конечнойстей...Вся лестница пропитана кровью..." +
                                "\n\nВы падаете на спину и перебирая руками отползаете, упираясь в стену." +
                                "\n\n*Вы можете убежать обратно (1), рискнуть, поборов страх (2), и пойти по этой лестнице или пойти к другой (3).*" +
                                "\n\n **Что вы решили?**");
                            Console.WriteLine("Нажмите любую клавишу для продолжения...");
                            Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine("\n..." +
                                "\nВы не успели даже подумать о плане, как вас, что-то начинает тянуть обратно к лестнице." +
                                "\nКакой-то черный тумаг тянет вас. Вы пытаетесь сопративлятся, но у вас ничего не получается." +
                                "\nВы цепляетесь пальцами за все, что только возможно - не помогает." +
                                "\nЦепляетесь ногтями за ковер на полу - вы ломаете ноготь, но боли не чувствуете, вы слишком заняты другими проблемами, нежели поломка ногтя." +
                                "\n*Вы у лестницы*" +
                                "\nСо страхом, посмотрев туда снова, вы ничего не видете, кроме нормальной лестницы." +
                                "\nТуман исчезает. Вы свободны.");
                            Console.WriteLine("Нажмите любую клавишу для продолжения...");
                            Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine("\nВы слышите голос, но он кажется настолько далеким, что невозможно что-либо разобрать." +
                                "\n\nПодождав еще чуть-чуть и переведя дух, вы встаете на ноги." +
                                "\nТени, которые были внизу исчезли." +
                                "\n*Вы оказались внезу, не заметив, как сами же спустились.*" +
                                "\nПеред вами, как мираж, появляется из неоткуда человек в доспехах." +
                                "\nОн лежит, под ним появляется лужа крови. Приложив все силы он снимает шлем." +
                                "\nОн кашляет кровью и произносит: '%24:?%;??:(!)*?@#^#&^&(%.'" +
                                "\nТут он затихает. В его глазах стоят слезы, его зрачки перестают двигаться." +
                                "\n\tОн мертв.");
                            Console.WriteLine("Нажмите любую клавишу для продолжения...");
                            Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine("\n\nСзади вас раздается рычание. Испугавшись такой внезапности вы оборачиваетесь и падаете на пятую точку." +
                                "\nПеред вами какое-то антропоморфное существо, похожее на смесь человека и волка." +
                                "\nВ его руке огромный мечь." +
                                "\nВы в порыве страха снова отползаете назад и натыкаетесь на труп рыцаря." +
                                "\nВолк замахивается над вами мечем и..." +
                                "\n...");
                            Console.WriteLine("Нажмите любую клавишу для продолжения...");
                            Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine("\n\nЕго грудь пронзил черный туман в форме руки, который некогда тащил вас к лестнице." +
                                "\nСердце волка оказалось было вырвоно." +
                                "\nОно все еще билось, находясь во власти этого тумана." +
                                "\nВолк стоял и недвигался." +
                                "\nЕго рука, держащая мечь, выронила его и он, чуть не отрубив вам ногу, приземлился рядом с вами и вонзается в пол." +
                                "\nТуман исчез и труп волка упал на вас.");
                            Console.WriteLine("Нажмите любую клавишу для продолжения...");
                            Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine("\n\nЗа ним было что-то непонятное, сгусток чего-то: то ли света, то ли тьмы, вы не могли понять." +
                                "\nОн заговорил: 'erwsrkgn4fdlk38bg92s92y56144fgbcssflj6ngfknxm,er57taxl.ah'" +
                                "\nУ него нет лица, но вы каким-то образом понимате, что оно улыбается." +
                                "\n - %№:Г*:№;(*?%(ЛП:*%(_(*%*;!Ь5::^%&#*&(" +
                                "\n - Хай живе Україна." +
                                "\nОно стало улыбаться еще сильнее." +
                                "\n - Nfr nj ns vtyz gjybvftim&" +
                                "\n - [f[f[f[[f[f Dblbvj ytn/" +
                                "\n - А если так?" +
                                "\nУлыбка стала еще шире." +
                                "\nОн явно понимал, что происходит.");
                            Console.WriteLine("Нажмите любую клавишу для продолжения...");
                            Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine("\n - Отлично... Чтож, как тебе представление? Как тебе мой театр?" +
                                "\nВы не можете ничего ответить, вы находитесь в шоковом состоянии." +
                                "\n - Ничего не скажешь? Я точно знаю, что ты меня понимаешь. Кстати, как тебе подушка из трупа, ты ее так сжал.." +
                                "\nВы оглядываетесь и понимаете, что все это время сидели, оеперевшись на труп рыцаря, и схватились за его руку." +
                                "\nВы отползаете. [Сгусток] перемещается и обретает человекоподобную форму. Трансформация выглядит очень просто, но как это произошло вы не понимаете." +
                                "\n\n - Ты знаешь кто он? Нет? Естественно, нет. (Маленький смешок) Он продвинулся довольно далеко и собрал 6 ключей." +
                                "\n Не так часто подобное встречается. Он мне нравился... Но он умер из-за какой-то собаки... " +
                                "\n Значит он все же был слабоком." +
                                "\n Видимо, его продвежение было всего лишь удачей. Забавно. (уголки его губ приподнялись)");
                            Console.WriteLine("Нажмите любую клавишу для продолжения...");
                            Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine("\n - А знаешь ли ты, что ты делаешь тут? хахах, конечно, нет. Ты ничего не знаешь, даже своего имени. Ой..." +
                                "\n А ты этого и не заметил. Как мило (Он мило улыбнулся)" +
                                "\nОн еще сильнее улыбнулся." +
                                "\nКогда вы задумались об этом, то поняли, что и правда даже имени своего не знаете." +
                                "\n*Кто вы?*" +
                                "\n - Ответ прост! Ты теперь моя пешка. Моя игрушка... Нет, банально. Ну и ладно, просто пешка." +
                                "\n Ой, как я забыл о манерах, я же не представился." +
                                $"\n Я [{nameBoss}], по крайней мере так мое имя звучит на твоем языке.");

                            Console.WriteLine("Нажмите любую клавишу для продолжения...");
                            Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine("\n Ты еще и слова не сказал... Может впомнишь свое имя? Ах, нет, не сможешь (на его лице поддельное разочерование)" +
                                "\n Что мы имеем в итоге... У тебя нет имени, тебя чуть не убил [Волкодав]... Люблю такие забавы." +
                                "\n Ты можешь придумать себе имя. Или я его тебе дам. Все просто. Хоть что-то скажешь.");
                            int nameMiss = 0;
                            do
                            {
                                Console.WriteLine("\n **Придумайте имя или [Виодмун Тлейфей] придумает его сам**");
                                nameCharactr = Console.ReadLine();
                                if (nameCharactr.Length <= 1)
                                {
                                    Console.WriteLine(" Это явно не имя. Хахаха");
                                    Console.WriteLine("Ждем....");
                                    for (int i = 0; i < 10; i++)
                                    {
                                        Thread.Sleep(750);
                                        Console.WriteLine((i + 1) + "...");
                                    }
                                    Thread.Sleep(1500);
                                    Console.Clear();
                                }
                                nameMiss++;
                                if (nameMiss == 3)
                                {
                                    Console.WriteLine(" Времени у меня бесконечное количество, даже представить себе не можешь, а вот стоять и смотерть на твои потуги..." +
                                        "\n Надоело.. Скучно. Поэтому я дам тебе имя сам. Теперь ты [Ивен]. Хорошее имя мне нравится");
                                    nameCharactr = "Ивен";
                                }
                            } while (nameCharactr.Length <= 1);

                            Console.WriteLine($"Хах, и это твое имя... {nameCharactr}" +
                                $"\nНу ладно. Все лучше чем твое предидущее.");
                            Console.WriteLine("Нажмите любую клавишу для продолжения...");
                            Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine($" Итак. {nameCharactr}, говорить тебе о себе нечего. Так что тут буду говорить снова Я." +
                                $"\n Я отвечу на основные вопросы, может, поотвечаю на твои, если таковые будут." +
                                $"\n Во-первых, ты оказался здесь по двум простым причинма: " +
                                $"\n 1.Твоя прошлая жизнь была окончена." +
                                $"\n 2.Я прибрал твою душу к рукам, дабы повеселится." +
                                $"\n\n Во-вторых, Зачем мне это все, да за тем, что мне ооооооочень скучно." +
                                $"\n Видишь ли, для вас я являюсь чем-то вроде [Бога]. И моя жизнь такова, что я просто живу и содержу этот мир." +
                                $"\n Мир полный скуки, по крайней мере, для меня." +
                                $"\n Мир, принадлежащий мне. Этот театр как раз частичка этого мира." +
                                $"\n\n В-третьих, после моего монолога ты покинешь [Театр Жизни] и попадешь в подземелье." +
                                $"\n Как раз из него вышел этот рыцарь. Как ты уже мог услышать он собрал 6 ключей." +
                                $"\n Задача проста, я бы даже назвал это Целью... Ну да неважно." +
                                $"\n Твоя единственная цель - выжить." +
                                $"\n Все невероятно просто: Ты убиваешь - выживаешь, Ты не убиваешь - умираешь. (Он ехидно улыбнулся)" +
                                $"\n Естественно за выживание есть приз. И, ?&()@*%, насколько же он прекрасен." +
                                $"\n\n Суть приза такова: " +
                                $"\n Если ты пройдешь мое подземелье, ты можешь пожелать чего хочешь..." +
                                $"\n Хоть  вечную жизнь, хоть целый мир во владение, хоть становление [Богом], хоть аниму дэвочку (выбор педиков).");

                            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                            Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine($" Понимаешь, {nameCharactr}? Выживание это все, что тебя должно волновать." +
                                $"\n Но не думай, что сможешь отсидется и просто переждать. Это не займет день, не два, не месяц." +
                                $"\n Время зависит только от тебя. То есть, конкретизирую твою задачу, впереди - [Подземелье]." +
                                $"\n Там у тебя будет цель выжит, но для ее исполнения необходимо выполнить парочку простых задач." +
                                $"\n Например: найти еду, Самое логичное; собрать 10 [Ключей]." +
                                $"\n [Ключи] - неотъемлемая часть подземелья, с их помощью ты разблокируешь последубщие этапы." +
                                $"\n То есть задача собрать ключи. Тебе понятно?");
                            Console.Write(" - ");
                            route = Console.ReadLine();
                            if (route == "да" || route == "Да" || route == "1" || route == "y")
                            {
                                Console.WriteLine(" - Прекрасно! Что ж... Время подходит к концу. Не волнуйся, если чего-то не понял или не запомнил." +
                                    "\n В [Подземелье] есть все описанное выше, даже в более подробной форме, лишь бы ты читать умел." +
                                    "\n Надеюсь, ты сможешь меня повеселить и пройдешь дальше, чем этот [Ивен]. (Он снова улыбается)." +
                                    "\n Ну-с, если вопросов нет, то тебе туда. (Он указывает на большую дверь напротив)" +
                                    "\n\n - У мен...." +
                                    "\n - Прости, но меня это не интересует. Прощай. ХахахахаХАХАХАХАХАХХхХХАХАХхаххахаха");
                            }
                            else
                            {
                                Console.WriteLine(" - Я не собираюсь еще раз, что-то объяснять. Это был риторический вопрос. (он страшно улыбнулся)" +
                                    "\n Видишь ли, я не твой союзник, и это не Чистилище, и не Ад. Просто так получилось, что ты теперь в моих руках." +
                                    "\n Выбора у тебя нет. Но если у тебя есть вопросы, то не беспокойся. В [Подземелье] все подробно расписано." +
                                    "\n Главное читать уметь.");
                            }

                            Console.WriteLine("\n\n*Двери открываются и появляется зелено-голубой портал.*" +
                                "\n*Вас затягивает в него.*" +
                                "\n*Вы не можете и дернуться, чтобы хоть что-нибудь сделать.*" +
                                "\n - Ах да, твоя прошлая жизнь была забавной, */-+*^$#73. Удачи. Шутка... Хахахахаха (Его лицо омрачилось огромной улыбкой)");

                            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                            Console.ReadLine();
                            Console.Clear();

                            // Переход  в Глав.Зал
                            Console.WriteLine($"Вы просыпаетесь в центре {nameCastle}." +
                                $"\n*Вы осматриваетесь*" +
                                $"\nВокруг вас богато украшеные стены. Везде величественные цвета и узоры." +
                                $"\nЗал представляет собой круглое, высокое и широкое помещение." +
                                $"\nВ стенах через равные интервалы по кругу расколожены двери." +
                                $"\nВсего их 13." +
                                $"\nУ каждой двери своя табличка.");
                            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                            Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine("Первая дверь: [(&*^#@%&)(&#)]." +
                                "\n*Вы ничего не понимаете.*" +
                                "\n*Вы подходите к следующей двери*" +
                                "\nНадпись: [?*932№;5!%]." +
                                "\nБыстро осмотрев таблички, вы понимаете, что ничего не понимаете." +
                                "\n\n*Голос в голове:*" +
                                "\n\t - Забавно, так ты читать не умеешь... Так и быть дам рекомендацию. [Первая] и [Тринадцатая] двери.");
                            break;
                        }




                    case "2": // Решение пойти назад
                        {
                            Console.WriteLine($"Вы решаете найти выход и идете в бесконечно-длинный коридор." +
                                $"\nСтены вокруг вас, будто бы сужаются. Однако ничего не меняется." +
                                $"\nВы идете довольно медленно, потому что у вас нет обуви, а пол каменный и в часто встречается какой-то мусор.");
                            for (int i = 7; i < 20; i++)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine($"Вы идете {i} минут..." +
                                    $"\nНичего не происходит." +
                                    $"\nТуннель кажется все бесконечнее и бесконечнее.");
                            }
                            for (int i = 0; i < 10; i++)
                            {
                                Thread.Sleep(750);
                                Console.Write(" . ");
                            }
                            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                            Console.ReadLine();
                            Console.Clear();

                            Console.WriteLine($"Вы идете больше поучаса, но ничего не находите." +
                                $"\nТуннель как был бесконечным, мрачным и холодным, таким и остался." +
                                $"\n*Вы замерзаете.*" +
                                $"\n\t**Пойти назад?**");
                            route = Console.ReadLine();
                            if (route == "да" || route == "Да" || route == "1" || route == "y")
                            {
                                Console.WriteLine("*Вы разворачиваетесь и идете обратно.*");
                                for (int i = 0; i < 10; i++)
                                {
                                    Thread.Sleep(750);
                                    Console.Write(" . ");
                                }
                                Console.WriteLine("В конечном итоге вы оказались в начальной точке." +
                                    "\n*Вам очень холодно.*" +
                                    "\n*Вы кое-как передвигаете ногами*" +
                                    "\nНо вам приходится идти дальше.");
                                goto case "1";
                            }
                            else
                            {
                                Console.WriteLine("*Вы решаете пойти дальше.*" +
                                    "\nВозможно, впереди есть выход и вы совсем чуть чуть не дошли." +
                                    "\nПоэтому вы шевелите ослабшими ногами.");
                                for (int i = 0; i < 10; i++)
                                {
                                    Thread.Sleep(750);
                                    Console.Write(" . ");
                                }
                                Console.WriteLine("\n*Вы шли еще около 15 минут.*" +
                                    "\n*Вы весь дрожжите.*" +
                                    "\n*Вы очень голодны.*" +
                                    "\n*Вы кое как передвегаете ногами.*" +
                                    "\n\t **Пойти назад?**");
                                route = Console.ReadLine();

                                if (route == "да" || route == "Да" || route == "1" || route == "y")
                                {
                                    Console.WriteLine("*Вы разворачиваетесь и идете обратно.*");
                                    for (int i = 0; i < 10; i++)
                                    {
                                        Thread.Sleep(750);
                                        Console.Write(" . ");
                                    }
                                    Console.WriteLine("В конечном итоге вы оказались в начальной точке." +
                                        "\n*Вам очень холодно.*" +
                                        "\n*Вы кое-как передвигаете ногами*" +
                                        "\nНо вам приходится идти дальше.");
                                    goto case "1";
                                }
                                else
                                {
                                    Console.WriteLine("ВЫ очень упорны и направляетесь дальше.");
                                    for (int i = 0; i < 7; i++)
                                    {
                                        Thread.Sleep(1250);
                                        Console.WriteLine($"Вы идете {i} минут...");
                                        Console.WriteLine("\t.");
                                    }
                                    Console.WriteLine("Время будто замирает.");
                                    for (int i = 0; i < 6; i++)
                                    {
                                        Thread.Sleep(1500);
                                        for (int j = 0; j < i; j++)
                                        {
                                            Console.Write("\t");
                                        }
                                        Console.WriteLine(".");
                                    }

                                    Console.WriteLine("Вы идете. Вам кажется, что впереди выход..." +
                                        "\nНо это всего лишь голюценации.");

                                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                                    Console.ReadLine();
                                    Console.Clear();

                                    Console.WriteLine("\n\n\n\t\t\t!*ВЫ УМЕРЛИ*!");
                                    Console.ReadLine();
                                    return;
                                }
                            }

                            break;
                        }
                    default:
                        Console.WriteLine("Другого выбора, кроме как Впред и Назад нет.");
                        break;
                };
            }
            if (1 > 0)                          //!!!!
            {
                Console.WriteLine("Выберете сохранение:");

                Console.WriteLine($"*Добро пожаловать обратно, {nameCharactr}*");

            }
        }   //  !!!    



        // Библиотека - 1
        static void Libriary()
        {
            Console.WriteLine($"");
        }

        static void RoomEnter()
        {
            Console.WriteLine();
        }  //   !!
        static void RoomExit()
        {
            Console.WriteLine("*Вы победили и входите в дверь в конце кордора.*" +
                $"Пройдя через портал вы оказываететсь в [{nameCastle}]." +
                "Огромные двери позади вас закрываются и будто бы становятся самой стеной.");
            if (key < 7 && mana > 1000) //!!
            {
                Console.WriteLine("В который раз вы переживавете [Перемещение], но никак не можете привыкнуть.");
            }
            else
            {
                Console.WriteLine("Вы уже привыкли к [Перемещению] и чувствуете потоки [Магических Цепей]." +
                    "\nВам нестрашна такая вибрация ваших [Магичсеких Цепей].");
            }
        }


        // Перерождение
        static void ReLife(int numDie)
        {
            // Если смертей одна.
            if (numDie == 1)
            {
                live++;
                secondLive--;
            }
            // Использование Амулета.
            if (numDie == 2)
            {
                live++;
                thirdLive--;
            }
            
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine(" - Хорошо я дам тебе еще один шанс." +
                $"\n Прими же благославление от {nameBoss}!" +
                $"\n Жизнь и смерть подвластны мне." +
                $"\n{nameBoss} превращается в существо, в виде которого предстало перед вами впервые." +
                $"\nВас окутывает тепло и яркий свет, который как вода струится завивается вокруг вас." +
                $"\nНо идилия прерывается резким появлением [Меча]." +
                $"\nЕго лезвие как стекло, такое же прозрачное." +
                $"\nСмотря на него, вы чувствуете его остроту." +
                $"\nЛишь подума об этом, [Мечь] вонзается в вас." +
                $"\n - Сейчас лезвие этого меча наполнится твоей кровью. (вы чувствуете улыбку на лице {nameBoss})" +
                $"\nЛезвие [Меча] начинает краснеть, будто в нем находится вода и ваша кровь медленно растворяется в ней.");
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("\t");
                }
                Thread.Sleep(1000);
                Console.WriteLine((i + 1) + "...");
            }
            Console.WriteLine("Каждая секунда для вас длится как целая вечность." +
                "\n[Меч] полностью окрасился в темно бордоый цвет, цвет вашей драгоценной крови." +
                "\n - Приготовься увидеть чудо за гранью твоего понимания, человечишка." +
                "\n ^*%HGDOH(*^&UED6u5%$e^RE96*^%*yjdl767*/-68595" +
                "\nВы ничего не поняли." +
                "\nВы чувствуете адскую боль. Настолько сильную, что хочется самому вырвать свое сердце!" +
                "\nНо вы не можете и пальцем шевельнуть.");
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Вы видете как вифрь [Света] так же становится темнее и преобритает кроваво-красный цвет." +
                "\nУже не свет, а темно-красный туман, проникает в каждую пору вашего тела, в каждое его отверстие." +
                "\nВы перестаете ощущать что-либо." +
                "\nВы забываете, кто вы, что вы здесь делаете и что вообще происходит." +
                "\n - Хах! Думал все так просто. Я даю тебе [Жизнь], а не забираю ее. Так что возвращаяся." +
                "\nВы мгновенно приходите в чувство." +
                "\n - Боль.." +
                "\n -АААААААААААААААААааааааааааааайАЙАААААААААААААААААА!!!" +
                "\nБоль по силе еще больше, чем была до этого, пронзила все тело.");
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("\t");
                }
                Thread.Sleep(350);
                Console.WriteLine((i + 1) + "...");
            }
            Console.WriteLine(" - Я же сказал. (Он, явно, довольно улыбается)" +
                "\nВдруг боль резко првращается.");
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Вы видете неописуемое существо." +
                "\nОно вынимает из вас [Меч]." +
                "\nКроваво-красный туман мгновенно рассеивается, будто бы его и нет было." +
                "\nВы падаете на спину, по вашим предположениям, с двух метров." +
                "\nСущество, которое было только что уже нет." +
                "\n[Меч] будто вновь растворяет в себе что-то, но в этот раз, он светлеет и становится таким каким был изнчально.");
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("*Вы осматриваете себя.*" +
                "\nРана от [Меча] заживает на глазах. Других ран, полученных во время боя, на вас буд-то и не было." +
                "\nОдежда так же восстановлена." +
                "\n - Я дал тебе второй шанс, так что не опозорься снова." +
                "\n Еще раза от меня не жди." +
                "\nВы встаете на ноги и происходит [Перемещение.]");
            
        }
        


        // Main
        static void Main(string[] args)
        {
            Begin();

            while(live > 0)
            {
                // Коридоры
                Console.Write("В какйю дверь пойти.");
                string door = Console.ReadLine();


                switch (door)
                {
                    case "1": // Первая дверь - Библиотека.
                        {
                            Libriary();
                            if (live > 0)
                                RoomExit();
                            break;
                        };
                    case "13": // Тринадцатая дверь - Оружейная.
                        {
                            if (live > 0)
                                RoomExit();
                            break;
                        }

                    case "2":
                        {
                            break;
                        }



                    case "help":
                        {
                            break;
                        }
                    case "save":
                        {
                            Save();
                            break;
                        }
                    case "Load":
                        {
                            CreateSaveFile();
                            ShowSave();

                            Console.WriteLine("*Введите номер сохранения*");
                            string numSave = Console.ReadLine();
                            LoadSave(numSave);
                            break;
                        }
                    case "exit":
                        return;

                    default:
                        {
                            Console.WriteLine("*Вы пытаетесь сделать что-то невозможное*" +
                                "\nЗайдите в [Библиотеку] или [Личную комнату], чтобы узнать свои возможности." +
                                "\nhelp поможет сориентироваться среди всех этих комнат.");
                            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }

                }
                // Дарование второго шанса.
                if (live == 0 && secondLive == 1 && thirdLive == 0)
                {
                    Console.WriteLine("*Вы умираете.*" +
                            "\nВсе монстры почему-то мгновенно взрываются, развбрызгивая свою кровь и раскидывая свои ошметки во все стороны." +
                            $"\n\nПоявляется {nameBoss}.");
                    if (key < 4)
                    {
                        Console.WriteLine(" - ХаххахахахаахаХАХАХА" +
                            "\n Как же ты смешон! Даже половины не прошел!" +
                            "\n Ты точно человек? Потому что мне кажется, что ты всего лищь обезьяна, которая палкой машет!" +
                            "\n Как же ты меня удивил! Все таки такое убогое имя в прошлой жизни ты заслуживал!" +
                            "\n Идиот! Придурок! И СЛАБАК! Это все, что можно о тебе сказать!" +
                            "\n..." +
                            "\n - Но так и быть, я пришел не просто так..." +
                            "\n Очень хочется оставить тебя тут помирать, но у меня есть принципы...");
                    }
                    if (key >= 4 && key < 7)
                    {
                        Console.WriteLine(" - Хах. Часто такое происходит, что пешки умирают на пол пути." +
                            "\n Но это все же заслуживает уважения." +
                            "\n Так что так и быть...");
                    }
                    if (key >= 7 && key <= 10)
                    {
                        Console.WriteLine($" - Очень неплохо. {nameCharactr}, совсем неплохо. Пройти почти до конца." +
                            $"В таком случае я буду пожалуй даже рад дать тебе еще одну жизнь.");
                    }
                    Console.WriteLine("\n Ты умрешь, если тебе не помочь." +
                        "\n Я могу это сделать. Дать второй шанс. Но второго такого подарка не будет." +
                        "\n Ты можешь и отказаться, решай." +
                        "\n\n\t**Принять второй шанс или умереть окончательно?**");
                    string route = Console.ReadLine();
                    if (route == "да" || route == "Да" || route == "1" || route == "y")
                    {
                        ReLife(1);
                    }
                    else
                    {
                        Console.WriteLine("**Вы уверены?**" +
                            "Это будет окончательная смерть." +
                            "!Это сохранение будет удалено!" +
                            "\n\n\t**Принять второй шанс или умереть окончательно?**");
                        route = Console.ReadLine();
                        if (route == "да" || route == "Да" || route == "1" || route == "y")
                        {
                            ReLife(1);
                        }
                        else
                        {
                            Console.WriteLine("**!Принято решение умереть!**" +
                                "\n - Хаха... Удивлен. Мало кто отказывается умереть, когда есть шанс продолжить." +
                                "\n Но ладно, это твой выбор." +
                                $"\n Прощай, {nameCharactr}." +
                                $"\n Ты был лишь моей очередной пешкой для развлечения самого себя.");

                            Console.WriteLine("\nНажмите любую клавишу для закончить свою жизнь.");
                            Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("!**Вы умерли**!");
                            Console.ReadLine();
                            return;
                        }
                    }
                }
                // Амулет.
                if (live == 0 && secondLive == 0 && thirdLive == 1)
                {
                    Console.WriteLine(" - Хахахахаха. Поздравляю. Ты где-то смог раздобыть [Амулет Жизни]." +
                        "\n Неплохо. " +
                        "\n Еще раз поздравляю." +
                        "\n Я тебя воскрешу. Раз уж таковы правила [Подземелья]." +
                        "\n И с [Амулетом] выбора у тебя умереть или воскреснвть нет.");
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadLine();
                    Console.Clear();
                    ReLife(2);
                }
                // Смерть.
                if (live == 0 && secondLive == 0 && thirdLive == 0)
                {
                    Console.WriteLine(" - У тебя больше нет шансов на [Воскрешение]." +
                        "\n Хах, вот и все!");
                    if (key < 4)
                    {
                        Console.WriteLine(" Ты полный придурок, раз умер так просто и быстро даже со вторым шансем!" +
                            "\n Прощай. Ты скучная пешка.");
                    }
                    if (key >= 4 && key < 7)
                    {
                        Console.WriteLine(" - Что ж опять. Жаль. Ну да и ладно. Мне на вас все равно." +
                            "\n Прощай.");
                    }
                    if (key >= 7 && key < 10)
                    {
                        Console.WriteLine(" - Очень неплохо!" +
                            "\n Ты далеко забрался, жаль что неповезло." +
                            "\n Но такова [Жизнь]." +
                            "\n Ты не справился с задачами в итоге умираешь. Все закономерно." +
                            "\n Прощай.");
                    }
                    if (key == 10)               // !!      Смерть с 10 ключами.
                    {
                        Console.WriteLine("");
                    }
                }


                if (key == 10)       // !!      Переход на последний уровень.
                {
                    break;
                }

            }
            Console.ReadKey();
        }
    }
}
