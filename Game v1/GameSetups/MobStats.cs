﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSetups
{
    public class MobStats
    {
        public static string NameMobs(int mob, int nameOrPlace)    // Названия и местообитание Мобов.
        {
            string[,] name = new string[12, 2];

            // Name
            name[0, 0] = "[Гоблины]";
            name[1, 0] = "[Морозные элементали]";
            name[2, 0] = "[Остроклык]";
            name[3, 0] = "[Призраки]";
            name[4, 0] = "[Скилеты]";
            name[5, 0] = "[Орки]";
            name[6, 0] = "[Огненныйе элементали]";
            name[7, 0] = "[Гигант пустошь]";
            name[8, 0] = "[Альдеринская армия]";
            name[9, 0] = "[Виверны]";
            name[10, 0] = "[Дракон Эн'Ферциан]";
            name[11, 0] = "[******]";

            // Place
            name[0, 1] = "на [Поляну]";
            name[1, 1] = "[]";
            name[2, 1] = "[]";
            name[3, 1] = "[]";
            name[4, 1] = "[]";
            name[5, 1] = "[]";
            name[6, 1] = "[]";
            name[7, 1] = "[]";
            name[8, 1] = "[]";
            name[9, 1] = "[]";
            name[10, 1] = "[]";
            name[11, 1] = "[]";

            return name[mob, nameOrPlace];
        }



        public static string Stat(int door, int stat)
        {
            var rnd = new Random();

            var mobStat = new string[20, 8];

            /*
             * 0 - Название
             * 1 - Место (Например: [Деревня])
             * 2 - Здоровье
             * 3 - Атака
             * 4 - Мана
             * 5 - Баф Атрибут
             * 6 - Дебаф Атрибут
             * 7 - Описание
             */
            mobStat[0, 0] = "[Гоблины]";
            mobStat[0, 1] = "[Маленькая Деревня Гоблинов]";
            mobStat[0, 2] = Convert.ToString(rnd.Next(40, 110));
            mobStat[0, 3] = Convert.ToString(rnd.Next(3, 12));
            mobStat[0, 4] = Convert.ToString(rnd.Next(0));
            mobStat[0, 5] = "";
            mobStat[0, 6] = "Огонь, Холод, Тьма";
            mobStat[0, 7] = "\n\tГоблины - маленькие зеленоватые существа, похожие на людей. По одиночке они не опасны, но когда их много - они берут числом." +
                "\n\tЭти существа обитают в своих маленьких деревнях, где ведут жизнь, похожую на жизнь деревенских людей: охотятся, занимаются собирательством," +
                "\n\tрыболовством, порой можно встретить Гоблинов с прирученными собаками." +
                "\n\tКрайне агрессивны, по отношению к людям, всячески стараются защитить свои территории." +
                "\n\tЧасто нападают на поселения Людей, чтобы получить ресурсы или увеличить свои территории." +
                "\n\tНекоторые кто их видел подмечают, что им нравится издеваться над людьми, они часто сохраняют женщин," +
                "\n\tчтобы насиловать их и развлекаться. Иногда может родится ребенок от Человека и Гоблина." +
                "\n\tОбычно их убивают, но если все таки им удается прижится в поселении, то они довольно сильно могут повлиять на развитие Деревни," +
                "\n\tтак как их сила в разы больше чем у обычных Гоблинов, но все еще ниже чем у Человека." +
                "\n\tОднако если группа Людей встречает такого, они могут попасть в ловушку или засаду, что двольно часто делают Гоблины." +
                "\n\tПусть они и выглядят маленькими и тупыми, но они двольно хитры и сообразительны, что касается ловушек и выслеживания.";
            
            
            if (stat == 10)
                return Convert.ToString(mobStat.GetLength(0));
            else
                return mobStat[door, stat];
        }
    }
}