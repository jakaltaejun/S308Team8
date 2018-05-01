using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace S308FinalProjectGroup8
{
    public class Member
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public double Weight { get; set; }

        public string FitnessGoal { get; set; }

        //Individual 1 Month: $9.99
        //Individual 12 Month: $100.00
        //Two Person 1 Month: $14.99
        //Two Person 12 Month: $150.00
        //Family 1 Month: $19.99
        //Family 12 Month: $200.00
        public string MembershipType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double MembershipCostPerMonth { get; set; }

        public string strMembershipCostPerMonth { get; set; }

        public double Subtotal { get; set; }

        public string strSubtotal { get; set; }

        public bool PersonalTrainingPlan { get; set; }

        public bool LockerRental { get; set; }

        public double Total { get; set; }

        public string strTotal { get; set; }

        public Member()
        {

        }

        public Member(string _MembershipType, DateTime _StartDate, bool _PersonalTrainingPlan, bool _LockerRental)
        {
            //Initialize
            PersonalTrainingPlan = _PersonalTrainingPlan;
            LockerRental = _LockerRental;
            StartDate = _StartDate;
            MembershipType = _MembershipType;

            //Calculate end date
            if ("Individual 1 Month" == MembershipType || "Two Person 1 Month" == MembershipType || "Family 1 Month" == MembershipType)
            {
                EndDate = StartDate.AddMonths(1);
            }
            else if ("Individual 12 Month" == MembershipType || "Two Person 12 Month" == MembershipType || "Family 12 Month" == MembershipType)
            {
                EndDate = StartDate.AddYears(1);
            }

            //Read price and set subtotal
            var lines = File.ReadAllLines(@"..\..\Data\price.csv");
            foreach (var line in lines)
            {
                var elements = line.Split(',');
                if (MembershipType == elements[0])
                {
                    Subtotal = Convert.ToDouble(elements[1]);
                    strSubtotal = Subtotal.ToString("C2");
                    break;
                }
            }

            Total = Subtotal;
            strTotal = Total.ToString("C2");

            ////Calculate cost per month
            if (MembershipType.IndexOf(" 1 ") >= 0)
            {
                MembershipCostPerMonth = Subtotal;

                strMembershipCostPerMonth = MembershipCostPerMonth.ToString("C2");
            }
            else
            {
                MembershipCostPerMonth = Math.Round(Subtotal / 12,2);
                strMembershipCostPerMonth = MembershipCostPerMonth.ToString("C2");
            }

            //If personal training plan selected, charge 5/mon
            if (PersonalTrainingPlan)
            {
                double PersonalTrainingPlan = Convert.ToDouble(File.ReadAllText(@"..\..\Data\PersonalTrainingPlan.txt"));
                MembershipCostPerMonth += 5;
                strMembershipCostPerMonth = MembershipCostPerMonth.ToString("C2");
                if (MembershipType.IndexOf(" 1 ") >= 0)
                {
                    Total += PersonalTrainingPlan;
                    strTotal = Total.ToString("C2");
                }
                else
                {
                    Total += PersonalTrainingPlan * 12;
                    strTotal = Total.ToString("C2");
                }
            }

            //If locker rental selected, charge 1/mon
            if (LockerRental)
            {
                double LockerRental = Convert.ToDouble(File.ReadAllText(@"..\..\Data\LockerRental.txt"));
                MembershipCostPerMonth += 1;
                strMembershipCostPerMonth = MembershipCostPerMonth.ToString("C2");
                if (MembershipType.IndexOf(" 1 ") >= 0)
                {
                    Total += LockerRental;
                    strTotal = Total.ToString("C2");
                }
                else
                {
                    Total += LockerRental * 12;
                    strTotal = Total.ToString("C2");
                }
            }
        }

        public string GetPricePreview()
        {
            return "Membership Type: " + MembershipType + "\nStart Date: " + StartDate + "\nEnd Date: " + EndDate + "\nMembership Cost per Month: " + strMembershipCostPerMonth  + "\nSubtotal: " + strSubtotal  + "\nPersonal Training Plan: " + PersonalTrainingPlan + "\nLocker Rental: " + LockerRental + "\nTotal(no tax included): " + strTotal;
        }

        public string GetMembershipSummary()
        {
            return "First Name: " + FirstName + "\nLast Name: " + LastName + "\nAge: " + Age + "\nPhone: " + Phone + "\nEmail: " + Email + "\nGender: " + Gender + "\nWeight: " + Weight + "\nFitness Goal: " + FitnessGoal;
        }
    }
}
