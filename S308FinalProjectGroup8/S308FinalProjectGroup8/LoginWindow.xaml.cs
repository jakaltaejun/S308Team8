////Background picture from http://www.stagemilk.com/fitness-for-actors/
////User Image from https://qwilr.com/login/
////Face Image from http://domainsrus.ca/
/// Lock Image from https://cdn3.iconfinder.com/data/icons/black-easy/512/538522-lock_512x512.png
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

namespace S308FinalProjectGroup8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void imgUserFace_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void btxLogin_Click(object sender, RoutedEventArgs e)
        {
            Window1 MainMenu = new Window1();
            MainMenu.Show();
        }
    }
}
