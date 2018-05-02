using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace S308FinalProjectGroup8
{
    public class Price
    {
        //Properties
        public string MembershipType { get; set; }
        public double UnitPrice { get; set; }
        public bool Available { get; set; }
    }
    public class PriceInfo
    {
         
        public Price[] PriceSet = new Price[6];

        public PriceInfo()
        {
            //Convert PriceSet to Double and read all price.csv file
            var lines = File.ReadAllLines(@"..\..\Data\price.csv");
            int i = 0;
            foreach (var line in lines)
            {
                var elements = line.Split(',');
                PriceSet[i] = new Price();
                PriceSet[i].MembershipType = elements[0];
                PriceSet[i].UnitPrice = Convert.ToDouble(elements[1]);
                PriceSet[i].Available = Convert.ToBoolean(elements[2]);
                ++i;
            }
        }

        public void Store()
        {
            //Price will be calculated based on stored Price.csv the file
            string strOut = string.Empty;
            for (int i = 0; i < 6; ++i)
            {
                strOut += PriceSet[i].MembershipType + "," + PriceSet[i].UnitPrice + "," + PriceSet[i].Available + "\n";
            }
            File.WriteAllText(@"..\..\Data\price.csv", strOut);
        }
        //Serach Membership Information with for loop function
        public int SearchForMembershipType(string type)
        {
            for (int i = 0; i < 6; ++i)
            {
                if (PriceSet[i].MembershipType == type)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
