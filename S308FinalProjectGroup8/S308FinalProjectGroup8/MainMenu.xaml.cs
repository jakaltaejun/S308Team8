////Name: Taejun Lee, Jaehyun Lim, Jiakuo Li
///Imgaes for dumbbell: https://www.iconfinder.com/icons/282211/dumbbell_exercise_fitness_gym_sport_sport_club_training_icon#size=128
///Images for background: https://www.mensfitness.com/training/workout-routines/best-workout-ever-according-science
///Images for sales: https://www.iconfinder.com/icons/755051/business_earning_income_increase_office_sales_icon
///Images for Pricing: https://www.iconfinder.com/icons/493446/business_offer_development_engineering_service_finance_industry_repair_pricing_support_icon
///Images for Membership: https://www.iconfinder.com/icons/586164/business_card_id_card_identity_card_membership_card_icon
///
//Set buttons to direct users to the corresponding windows
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        

        

        private void lblMembershipSales_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            MembershipSales Sales = new MembershipSales();
            Sales.Show();
            this.Close();
        }

        

        private void lblPricingManagement_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Pricing_Management PricingManagement = new Pricing_Management();
            PricingManagement.Show();
            this.Close();
            
        }

      
        private void lblMembershipInfo_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MemberInformation MembershipInfo = new MemberInformation();
            MembershipInfo.Show();
            this.Close();
        }

        

        private void lblExit_MouseUp(object sender, MouseButtonEventArgs e)
        {

            this.Close();
            }
        }
    }

