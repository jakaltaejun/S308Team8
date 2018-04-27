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
    /// MembershipSales_preview.xaml 的交互逻辑
    /// </summary>
    public partial class MembershipSales_preview : Window
    {
        public MembershipSales_preview()
        {
            InitializeComponent();
        }

        private void imgHome_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window1 Home = new Window1();
            Home.Show();
            this.Close();
        }

        private void imgClose_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MembershipSales Sales = new MembershipSales();
            Sales.Show();
            this.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
