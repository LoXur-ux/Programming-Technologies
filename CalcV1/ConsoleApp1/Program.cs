using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Random rnd = new Random();
                int resultInMyLife = rnd.Next(0, 2);
                if (resultInMyLife == 0) Console.WriteLine("\t\t\tЕХУУУ! Factorio don't waits!");
                if (resultInMyLife == 1) Console.WriteLine("\t\t\t!!!ИДИ ПРОГАЙ ПРИДУРОК!!!");
                if (resultInMyLife == 2) Console.WriteLine("\t\t\t!!!ИДИ РАБОТАЙ!!!");

                Console.ReadKey();
            }
            
        }
    }
}
