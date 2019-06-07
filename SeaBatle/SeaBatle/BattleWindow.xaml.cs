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
using System.Windows.Shapes;

namespace SeaBatle
{
    /// <summary>
    /// Логика взаимодействия для BattleWindow.xaml
    /// </summary>
    public partial class BattleWindow : Window
    {
        int sizeGrig;
        int sizeButton = 30;
        int distanseBetweenButtons = 35;
        public BattleWindow(int sizeGrig = 10)
        {
            InitializeComponent();
            this.sizeGrig = sizeGrig;
        }
        private void BattleLoad(object sender, RoutedEventArgs e)
        {
            
            //texbox1.Text = "aaaa";
            for(int x = 50; (x-50) < sizeGrig* distanseBetweenButtons; x+= distanseBetweenButtons)
            {
                for(int y = 50; (y-50) < sizeGrig * distanseBetweenButtons; y+= distanseBetweenButtons)
                {
                    Button button = new Button();
                    button.Height = sizeButton;
                    button.Width = sizeButton;
                    Thickness thi = new Thickness();
                    thi.Left = x;
                    thi.Top = y;
                    button.Margin =thi;
                    AddChild(button);

                    
                }
            }
            
        }
    }
}
