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
    /// MembershipSales_signup.xaml 
    /// </summary>
    public partial class MembershipSales_signup : Window
    {
        public Member newMember;
        MemberDatabase db = new MemberDatabase();

        public MembershipSales_signup(Member _newMember)
        {
            InitializeComponent();
            newMember = _newMember;
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
            if (txtFirstName.Text == "" || txtLastName.Text == "" || comCreditCardType.SelectedIndex == -1 || txtCreditCardNumber.Text == "" ||
                txtPhone.Text == "" || txtEmail.Text == "" || comGender.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill out all the required items.");
                return;
            }

            //Validate that the phone number is entered in an acceptable format
            double phone = 0;
            if (txtPhone.Text.Length != 10)
            {
                MessageBox.Show("Please enter a 10-digit phone number.");
                return;
            }
            else if (!double.TryParse(txtPhone.Text, out phone))
            {
                MessageBox.Show("Please enter number in the item Phone");
                return;
            }

            //Set Info
            newMember.FirstName = txtFirstName.Text;
            newMember.LastName = txtLastName.Text;
            newMember.Phone = txtPhone.Text;
            newMember.Email = txtEmail.Text;
            newMember.Gender = comGender.SelectionBoxItem.ToString();
            if (!string.IsNullOrEmpty(txtAge.Text))
            {
                newMember.Age = Convert.ToInt32(txtAge.Text);
            }
            if (!string.IsNullOrEmpty(txtWeight.Text))
            {
                newMember.Weight = Convert.ToDouble(txtWeight.Text);
            }
            if (comPersonalFitnessGoal.SelectedIndex != -1)
            {
                newMember.FitnessGoal = comPersonalFitnessGoal.SelectionBoxItem.ToString();
            }

            db.MemberGroup.Add(newMember);
            db.Store();
            MessageBox.Show("Success");
            MessageBox.Show(newMember.GetMembershipSummary());

            //Back to home
            Window1 Home = new Window1();
            Home.Show();
            this.Close();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            MembershipSales Sales = new MembershipSales();
            Sales.Show();
            this.Close();
        }

        //If we entered Last Name, Email, and phone number of an existing customer, then click search. We'll get all other information prefilled
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtLastName.Text != "" && txtPhone.Text != "" && txtEmail.Text != "")
            {
                var ret = db.Search(txtLastName.Text, txtEmail.Text, txtPhone.Text);
                if (ret.Count <= 0)
                {
                    MessageBox.Show("Not found");
                }
                else
                {
                    txtAge.Text = ret[0].Age.ToString();
                    txtFirstName.Text = ret[0].FirstName;
                    txtWeight.Text = ret[0].Weight.ToString();
                    for (int i = 0; i < comGender.Items.Count; ++i)
                    {
                        if (comGender.Items[i].ToString() == "System.Windows.Controls.ComboBoxItem: " + ret[0].Gender)
                        {
                            comGender.SelectedIndex = i;
                            break;
                        }
                    }

                    if (newMember.EndDate < ret[0].EndDate)
                    {
                        MessageBox.Show("You are purchasing a membership that overlaps the timeframe of a previously purchased membership.");
                    }

                    db.MemberGroup.Remove(ret[0]);
                }
            }
        }
    }
}