//Imgaes for Background2: http://www.qygjxz.com/workout-wallpaper.html
//Images for Name: https://www.iconfinder.com/icons/1483138/female_name_plate_user_woman_icon
//Images for Email: https://pixabay.com/en/email-icon-web-internet-symbol-309491/
//Images for Phone: https://icons8.com/icon/533/phone
//Images for Search: https://icons8.com/icon/1888/google-web-search


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
    /// Interaction logic for MemberInformation.xaml
    /// </summary>
    public partial class MemberInformation : Window
    {
        MemberDatabase db = new MemberDatabase();
        public MemberInformation()
        {
            InitializeComponent();
        }

        private void imgSearch_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (txtName.Text == "" && txtEmail.Text == "" && txtPhone.Text == "")
            {
                MessageBox.Show("At least one search field should be filled");
                return;
            }

            var rets = db.Search(txtName.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim());

            if (rets.Count <= 0)
            {
                MessageBox.Show("No records were found");
                return;
            }

            foreach (var ret in rets)
            {
                txtReport.Text += ret.GetMembershipSummary() + "\n" + ret.GetPricePreview();
            }
        }

        private void imgReset_MouseUp(object sender, MouseButtonEventArgs e)
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }

        private void imgClose_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void imgHome_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window1 Home = new Window1();
            Home.Show();
            this.Close();
        }
    }
}
