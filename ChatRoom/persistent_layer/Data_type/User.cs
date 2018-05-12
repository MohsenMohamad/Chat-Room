using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistent_layer.Data_type
{
    [Serializable]
    public class User
    {
        public string Name;//{ get; set; }
        public string PassWord;//{ get; set; }
        public int GroupID;// { get; set; }
        public User(string name, int id, string password)
        {
            Name = name;
            GroupID = id;
            PassWord = password;

        }
        public string Get_Nick_Name()
        {
            return Name;
        }
        public int Get_ID()
        {
            return GroupID;
        }
        public bool PassWordCheck(string check)
        {
            if (check.Equals(PassWord))
            {
                return true;
            }
            else
                return false;
        }
        public bool sameuser(User user)
        {
            if (user.Get_Nick_Name().Equals(this.Get_Nick_Name()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
