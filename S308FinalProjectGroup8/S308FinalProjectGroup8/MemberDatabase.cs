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
        public List<Member> MemberGroup;

        public MemberDatabase()
        {
            string jsonData = File.ReadAllText(@"..\..\Data\Members.json");
            MemberGroup = JsonConvert.DeserializeObject<List<Member>>(jsonData);
        }

        public void Store()
        {
            string strJson = JsonConvert.SerializeObject(this.MemberGroup);
            File.WriteAllText(@"..\..\Data\Members.json", strJson);
        }

        public List<Member> Search(string name, string email, string phone)
        {
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
