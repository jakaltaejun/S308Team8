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
    /// MembershipSales.xaml 
    /// </summary>
    public partial class MembershipSales : Window
    {
        PriceInfo price = new PriceInfo();
        public MembershipSales()
        {
            InitializeComponent();
            for (int i = 0; i < 6; ++i)
            {
                if (price.PriceSet[i].Available)
                {
                    comMembershipType_Sales.Items.Add(price.PriceSet[i].MembershipType);
                }
            }
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
            if (comMembershipType_Sales.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a membership type.");
                return;
            }

            //Validate that the membership start date is not in the past
            if (dateMembershipStartDate_Sales .SelectedDate < DateTime.Now)
            {
                MessageBox.Show("The membership start date shouldn't be in the past.");
                return;
            }

            Member newMember = new Member(comMembershipType_Sales.SelectionBoxItem.ToString(), dateMembershipStartDate_Sales.SelectedDate.Value, chkPersonalTrainingPlan.IsChecked.Value, chkLockerRental.IsChecked.Value);

            MembershipSales_preview next = new MembershipSales_preview(newMember);
            next.Show();
            this.Close();
        }

    }
    }

