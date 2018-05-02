//Images for Background https://www.videoblocks.com/video/winter-night-sky-christmas-snowfall---loopable-background-kdbl7qy
//Images for Calculate: http://www.softicons.com/toolbar-icons/flatastic-icons-part-1-by-custom-icon-design/calculator-icon
//Images for Clear: https://www.iconfinder.com/icons/1575062/reset_icon
//Images for home: https://www.iconfinder.com/icons/126572/home_house_icon
//Images for close: https://www.iconfinder.com/icons/114937/button_close_icon

//Write new data that user entered to the database.

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
using System.IO;

namespace S308FinalProjectGroup8
{
    /// <summary>
    /// Interaction logic for Pricing_Management.xaml
    /// </summary>
    public partial class Pricing_Management : Window
    {
        //Assign a list of price information
        PriceInfo price = new PriceInfo();
        int indexInPrice;
        public Pricing_Management()
        {
            //read all text about locker rental and personal traninig plan from the text file
            InitializeComponent();
            txtLockerRental.Text = File.ReadAllText(@"..\..\Data\LockerRental.txt");
            txtPersonalTrainingPlan.Text = File.ReadAllText(@"..\..\Data\PersonalTrainingPlan.txt");
        }

      

       
        //The user can go back to Main Menu
        private void imgReturn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window1 Home = new Window1();
            Home.Show();
            this.Close();
        }
        //The user can close the interface
        private void imgClose_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        //not be used 
        private void comAvailable_DropDownClosed(object sender, EventArgs e)
        {

        }
        //Calculated the price based on membership type
        private void comMembershipType_DropDownClosed(object sender, EventArgs e)
        {
            indexInPrice = price.SearchForMembershipType(comMembershipType.SelectionBoxItem.ToString());
            if (indexInPrice != -1)
            {
                txtPrice.Text = price.PriceSet[indexInPrice].UnitPrice.ToString();
                if (price.PriceSet[indexInPrice].Available)
                {
                    comAvailable.SelectedIndex = 0;
                }
                else
                {
                    comAvailable.SelectedIndex = 1;
                }
            }
        }
        //change price with if statement function
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            var ret = MessageBox.Show("Are you sure to change price?", "Confirm", MessageBoxButton.YesNo);
            if (ret == MessageBoxResult.Yes)
            {
                if (txtPrice.Text != "" && comAvailable.SelectedIndex != -1)
                {
                    price.PriceSet[indexInPrice].UnitPrice = Convert.ToDouble(txtPrice.Text);
                    if (comAvailable.SelectionBoxItem.ToString() == "unavailable")
                    {
                        price.PriceSet[indexInPrice].Available = false;
                    }
                    else
                    {
                        price.PriceSet[indexInPrice].Available = true;
                    }
                }
                //Price data will be stored in the text file
                price.Store();
                File.WriteAllText(@"..\..\Data\LockerRental.txt", txtLockerRental.Text);
                File.WriteAllText(@"..\..\Data\PersonalTrainingPlan.txt", txtPersonalTrainingPlan.Text);
                MessageBox.Show("Success");

                Window1 Home = new Window1();
                Home.Show();
                this.Close();
            }
        }
    }
}
