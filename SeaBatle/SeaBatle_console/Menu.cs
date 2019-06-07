using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBatle
{
    //composite
    class Menu
    {
        
        Component mainPage = new Page(4);
        Component BattleStartPage = new PageStart();
        
        Component HelpPage = new InformationPage();
        Component AboutPage = new InformationPage();

        public void Build()
        {
            mainPage.SetText("WELCOME TO SEABATTLE!!!\n" +
            "0.Begin battle.\n" +
            "1.Help.\n" +
            "2.About.\n" +
            "q.Quit");
            mainPage.Add(BattleStartPage);
            BattleStartPage.SetText("CHOOSE DIFICULTY\n" +
                "0.Easy\n" +
                "1.Hard\n" +
                "q.Back");
            
            mainPage.Add(HelpPage);
            HelpPage.SetText("THIS IS HELP PAGE!\n\n" +
                "Press q to back");
            mainPage.Add(AboutPage);
            AboutPage.SetText("THIS IS ABOUT PAGE!\n\n" +
                "Press q to back");

        }
        public void Open()
        {
            mainPage.Action();
            
        }

    }

    abstract class Component
    {
        protected string text;

        public void SetText(string text)
        {
            this.text = text;
        }

        public virtual void Add(Component component) { }

        

        public virtual void Action()
        {
           
            Console.WriteLine(text);
            
        }
    }
    class Page : Component
    {
        private Component[] components;
        int size = 0;
        public Page(int size)
        {
            components = new Component[size];
        }
        

        public override void Add(Component component)
        {
            
            components[size]=component;
            size++;
        }

        

        public override void Action()
        {
            char c;
            do
            {
                Console.Clear();
                Console.WriteLine(text);
                switch (c = Console.ReadKey().KeyChar)
                {
                    case '0':
                        if (size > 0)
                            components[0].Action();
                        break;
                    case '1':
                        if (size > 1)
                            components[1].Action();
                        break;
                    case '2':
                        if (size > 2)
                            components[2].Action();
                        break;
                    default:
                        break;
                }
            } while (c != 'q');
        }
    }

    class InformationPage : Component
    {
        public override void Action()
        {
            char c;
            do
            {
                Console.Clear();
                Console.WriteLine(text);
                c = Console.ReadKey().KeyChar;
            } while (c!='q');
            
        }
    }
    class PageStart : Component
    {
        public override void Action()
        {
            char c;
            Random rand = new Random();
            do
            {
                Console.Clear();
                Console.WriteLine(text);

                Unit bot = null;
                
                switch (c = Console.ReadKey().KeyChar)
                {
                    case '0':
                        bot = new Unit(new Map(), new Map(), new User(new BotUserEasy(), rand), new ShipList());
                        break;
                    case '1':
                        bot = new Unit(new Map(), new Map(), new User(new BotUserHard(), rand), new ShipList());
                        break;
                    default:
                        
                        break;
                }
                if (bot!=null)
                {
                    Unit user = new Unit(new Map(), new Map(), new User(new ConsoleUser(), rand), new ShipList());

                    user.fillList();
                    user.SetShips();
                    bot.fillList();
                    bot.SetShips();
                    Console.Clear();
                    //Console.Write(user.myMap.DrawToStr() + "\n\n\n" + bot.myMap.DrawToStr());
                    Game game = new Game(user, bot);
                    game.Battle();
                }
                

            } while (c != 'q');

        }
    }

}
