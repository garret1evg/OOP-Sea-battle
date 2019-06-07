using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;


namespace SeaBatle
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void onClickDebug(object sender, RoutedEventArgs e)
        {
            Map map = new Map();
            
            TextBox1.Text = map.DrawToStr()+"\n\n\n"+ map.DrawToStr();
            


        }

        private void onClickDebugSetShips(object sender, RoutedEventArgs e)
        {
            /*Map map = new Map();
            ShipList list = new ShipList();

            IUser iBot = new BotUser();
            User bot = new User(iBot);
            Unit unit = new Unit(map,new Map(), bot, list);
            
            unit.fillList();
            bot.SetShips(map, list);
            
            TextBox1.Text = map.DrawToStr();*/
            Unit bot1 = new Unit(new Map(), new Map(), new User(new BotUser()), new ShipList());
            Unit bot2 = new Unit(new Map(), new Map(), new User(new BotUser()), new ShipList());
            bot1.fillList();
            bot1.SetShips();
            bot2.fillList();
            bot2.SetShips();
            TextBox1.Text = bot1.myMap.DrawToStr()+"\n\n\n"+ bot2.myMap.DrawToStr();
            Game game = new Game(bot1, bot2,TextBox1);
            game.Battle();
            //Thread.Sleep(3000);
            //DrawInTextBox1(TextBox1,bot1.myMap.DrawToStr() + "\n\n\n" + bot2.myMap.DrawToStr()+"adfhbsdgtjhdryjfty\nsethsthj\nsethseth");
            
            
        }
        public void DrawInTextBox1(TextBox tr,String str)
        {
            tr.Text = str;
        }

        private void OnClickBattle(object sender, RoutedEventArgs e)
        {
            BattleWindow battleWin = new BattleWindow();
            battleWin.ShowDialog();
        }
    }
}
