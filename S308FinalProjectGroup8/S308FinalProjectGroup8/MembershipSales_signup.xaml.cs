//Background image from: https://magazine.nasm.org/american-fitness-magazine/issues/american-fitness-magazine-spring-2016/i-want-to-teach-group-fitness!
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

namespace S308FinalProjectGroup8
{
    /// <summary>
    /// MembershipSales_signup.xaml 的交互逻辑
    /// </summary>
    public partial class MembershipSales_signup : Window
    {
        public MembershipSales_signup()
        {
            InitializeComponent();
        }

        private void imgHome_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window1 Home = new Window1();
            Home.Show();
            this.Close();
        }

        private void imgExit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Validate that all of the required fields are provided.
            if(txtFirstName.Text =="" ||txtLastName .Text ==""||comCreditCardType .SelectedIndex ==-1||txtCreditCardNumber .Text ==""||
                txtPhone .Text ==""||txtEmail .Text ==""||comGender .SelectedIndex ==-1)
            {
                MessageBox.Show("Please fill out all the required items.");
                return;
            }

            //Validate that the phone number is entered in an acceptable format
            double phone = 0;
            if (txtPhone .Text .Length !=10)
            {
                MessageBox.Show("Please enter a 10-digit phone number.");
                return;
            }
            else if(!double.TryParse (txtPhone.Text,out phone ))
            {
                MessageBox.Show("Please enter number in the item Phone");
                return;
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            MembershipSales Sales = new MembershipSales();
            Sales.Show();
            this.Close();
        }
    }
}
