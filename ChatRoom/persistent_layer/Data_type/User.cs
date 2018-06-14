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
        private string Name;
        private string Password;
        private int GroupID;
        private int ID;
        public User(String name, String password , int groupID , int id)
        {
            Name = name;
            Password = password;
            GroupID = groupID;
            ID = id;

        }
        public string getNickName()
        {
            return Name;
        }
        public int getGroupID()
        {
            return GroupID;
        }

        public int getID()
        {
            return ID;
        }
        public bool PassWordCheck(string check)
        {
            if (check.Equals(Password))
            {
                return true;
            }
            else
                return false;
        }

        public String getPassword()
        {
            return Password;
        }
        public bool sameuser(User user)
        {
            if (user.getNickName().Equals(this.Name)&(PassWordCheck(user.getPassword())))
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
