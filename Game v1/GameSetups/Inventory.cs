using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSetups
{
    public class Inventory
    {
        /// <summary>
        /// Обращаться необходимо с вычетом единицы,
        /// так как для работы типов оружия и щитов необходим ноль, как ничего не экипированное.
        /// В противном случае для рук при нуле (ничем) будет экипирован предмет, чего нельзя допускать.
        /// </summary>
        public static string Weapon(int name, int statOrLenght10) // Оружее. 
            
        {
            string[,] weapon = new string[15, 6];

            /*
             * 0 - Название
             * 1 - Урон
             * 2 - Атрибут
             * 3 - Тип (Одноручное\Двуручное\тд)
             * 4 - Описание
             * 5 - Действие
             */
            weapon[0, 0] = "[Ржавый Кинжал]";
            weapon[0, 1] = "8";
            weapon[0, 2] = "";
            weapon[0, 3] = "Одноручное";
            weapon[0, 4] = "Какое-то крутое и пафосное описание" +
                "\n\tВ несколько строк" +
                "\n\tЕще" +
                "\n\tБольше" +
                "\n\tСтрок";
            weapon[0, 5] = "";

            weapon[1, 0] = "[]";
            weapon[1, 1] = "";
            weapon[1, 2] = "";
            weapon[1, 3] = "";
            weapon[1, 4] = "";
            weapon[1, 5] = "";

            if (statOrLenght10 == 10)
                return Convert.ToString(weapon.GetLength(0));
            else
                return weapon[name, statOrLenght10];
        }

        /// <summary>
        /// Обращаться необходимо с домножением на удиницу. Для того, что бы можно было определить, что экипировано: Оружее или Щит.
        /// </summary>
        public static string Shild(int name, int statOrLenght10) // Щиты 
        {
            string[,] shild = new string[15, 4];

            /*
             * 0 - Название 
             * 1 - Защита (В процентах от урона противника)
             * 2 - Атрибут защиты
             * 3 - Описание
             */
            shild[0, 0] = "[Доска с ручкой]";
            shild[0, 1] = "2";
            shild[0, 2] = "";
            shild[0, 3] = "Эпитчное название" +
                "\nДля " +
                "\nДоски с" +
                "\nРучкой" +
                "\n!!!!!!";

            if (statOrLenght10 == 10)
                return Convert.ToString(shild.GetLength(0));
            else
                return shild[name, statOrLenght10];
        }

        public static string Armor(int name, int statOrLenght10)
        {
            string[,] armor = new string[15, 6];

            /*
             * 0 - Название
             * 1 - Защита (В процентах от урона противника)
             * 2 - Шум (+- к скрытности)
             * 3 - Атрибут Защиты
             * 4 - Атрибут Дэбафа
             * 5 - Описание
             */
            armor[0, 0] = "[]";
            armor[0, 1] = "";
            armor[0, 2] = "";
            armor[0, 3] = "";
            armor[0, 4] = "";

            if (statOrLenght10 == 10)
                return Convert.ToString(armor.GetLength(0));
            else
                return armor[name, statOrLenght10];
        }

        public static string Potions(int name, int statOrLenght10)
        {
            string[,] potion = new string[15, 5];

            /*
             * 0 - Название
             * 1 - Здоровье
             * 2 - Мана
             * 3 - Атака (повышение или понижение в процентах)
             * 4 - Время действия (для повышения атаки)
             * 5 - Описание
             */
            potion[0, 0] = "[]";
            potion[0, 1] = "";
            potion[0, 2] = "";
            potion[0, 3] = "";
            potion[0, 4] = "";
            potion[0, 5] = "";

            if (statOrLenght10 == 10)
                return Convert.ToString(potion.GetLength(0));
            else
                return potion[name, statOrLenght10];
        }
    }
}
