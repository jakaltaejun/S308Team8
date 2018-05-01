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

      
        //Check if the user's input match the correct ID and password. If so, open the main menu.
        private void btxLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUserID.Text == "FitnessManager" && pwdPassword.Password == "password")
            {
                Window1 MainMenu = new Window1();
                MainMenu.Show();
                MessageBox.Show("Welcome, you have been granted access");
                this.Close();
            }
            else
            {
                MessageBox.Show("You are not allowed to access");
            }

        }
    }
}
