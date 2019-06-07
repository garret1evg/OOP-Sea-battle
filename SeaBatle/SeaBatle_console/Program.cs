using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatle
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Unit bot1 = new Unit(new Map(), new Map(), new User(new BotUser()), new ShipList());
            Unit bot2 = new Unit(new Map(), new Map(), new User(new BotUser()), new ShipList());
            bot1.fillList();
            bot1.SetShips();
            bot2.fillList();
            bot2.SetShips();
            Console.Write( bot1.myMap.DrawToStr() + "\n\n\n" + bot2.myMap.DrawToStr());
            Console.ReadKey();*/
            Menu menu = new Menu();
            menu.Build();
            menu.Open();
        }
    }
}
