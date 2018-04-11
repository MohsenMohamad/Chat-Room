using System;
using System.Collections.Generic;
using System.Text;

namespace Business_layer
{
    public class User
    {
        public string Name { get; set; }
        private string PassWord { get; set; }
        private int GroupID { get; set; }
        public User(string name, int id,string password)
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
        public bool sameUser(User user)
        {
            if (user.Get_Nick_Name().Equals(this.Name))
            {
                return true;
            }
            else
                return false;
        }

        //Other properties, methods, events...
    }
}
