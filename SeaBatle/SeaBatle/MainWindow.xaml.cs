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
            
            TextBox1.Text = map.DrawToStr();
            


        }

        private void onClickDebugSetShips(object sender, RoutedEventArgs e)
        {
            Map map = new Map();
            ShipList list = new ShipList();

            IUser iBot = new BotUser();
            User bot = new User(iBot);
            Unit unit = new Unit(map,new Map(), bot, list);
            
            unit.fillList();
            bot.SetShips(map, list);
            
            TextBox1.Text = map.DrawToStr();
        }
    }
}
