using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSetups
{
    public class Stats
    {
        public static string Door(int door, int stats) // Прибавки различных комнат.
        {
            /* 
             * Прибавки к статам. 
             * 0 - HP.
             * 1 - Atk.
             * 2 - Mana.
             * 3 - Скрытность.
             */

            string[,] doorOutput = new string[12, 4];

            doorOutput[0, 0] = "0,7";


            doorOutput[0, 1] = "0,75";

            doorOutput[0, 2] = "0";

            doorOutput[0, 3] = "0,21";

            return doorOutput[door, stats];
        }

        





        public static string MagicCast(int numSpell, int stats)
        {
             /*
             * 0 - Номер.
             * 1 - Название.
             * 2 - Атака.
             * 3 - Мана.
             * 4 - Дамаг или Восстановление.
             * 5 - Описание действия заклинания.
             * 6 - Атрибут
             */
            string[,] spell = new string[15, 7];

            // Файербол
            spell[0, 0] = "1";
            spell[0, 1] = "[Файербол]";
            spell[0, 2] = "15";
            spell[0, 3] = "10";
            spell[0, 4] = "";
            spell[0, 5] = "*Вы используете [Файербол]*" +
                "\nПоявляется небольшой магический круг ярко-ораньжевого цвета" +
                "\nОгненный шар окутывает устремляется в сторону противника." +
                "\nПламя взрывается и окутывает собой противника." +
                "\nОднако быстро развеивается и магический круг так же рассеивается.";
            spell[0, 6] = "Пламя";



            return spell[numSpell, stats];
        }
    }
}
