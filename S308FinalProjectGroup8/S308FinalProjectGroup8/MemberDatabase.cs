using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace S308FinalProjectGroup8
{
    public class MemberDatabase
    {
        //instantiate a list to hold the Members
        public List<Member> MemberGroup;

        public MemberDatabase()
        {
            //use System.IO File to read the entire data file
            string jsonData = File.ReadAllText(@"..\..\Data\Members.json");
            //serialize the json data to a list of members
            MemberGroup = JsonConvert.DeserializeObject<List<Member>>(jsonData);
        }

        public void Store()
        {
            //serialize the new list of members to json format 
            string strJson = JsonConvert.SerializeObject(this.MemberGroup);
            File.WriteAllText(@"..\..\Data\Members.json", strJson);
        }

        public List<Member> Search(string name, string email, string phone)
        {
            //use foreach function 
            List<Member> ret = new List<Member>();
            foreach (Member tmp in MemberGroup)
            {
                if (name == "" || tmp.LastName == name)
                {
                    if (email == "" || tmp.Email == email)
                    {
                        if (phone == "" || tmp.Phone == phone)
                        {
                            ret.Add(tmp);
                        }
                    }
                }
            }

            return ret;
        }
    }
}
