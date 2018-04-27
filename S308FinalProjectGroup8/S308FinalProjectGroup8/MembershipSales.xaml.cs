//Background picture from: https://www.white-ibiza.com/winter/wellness/cotton-fitness-club
//
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
    /// MembershipSales.xaml 的交互逻辑
    /// </summary>
    public partial class MembershipSales : Window
    {
        public MembershipSales()
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

        private void btnQuote_Click(object sender, RoutedEventArgs e)
        {
            //Validate that a member type is selected
            if(comMembershipType_Sales.SelectedIndex ==-1)
            {
                MessageBox.Show("Please select a membership type.");
                return;
            }

            //Validate that the membership start date is not in the past
            if(dateMembershipStartDate_Sales .SelectedDate <DateTime .Now )
            {
                MessageBox.Show("The membership start date shouldn't be in the past.");
                return;
            }

        }
    }
}
