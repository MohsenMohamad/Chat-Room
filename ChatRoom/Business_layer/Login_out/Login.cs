using System;
using System.Collections.Generic;
using System.Text;
using persistent_layer.Data_type;
using persistent_layer;
using persistent_layer.logfile;


namespace Business_layer.Login_out
{
    public class login
    {
        private List<User> userList;
        public User Login(string user, string password)
        {
            //LOGGING
            logging_activety.logging_msg("login action with user name:" + user + " | Password: " + password);

            userList = Data_Base.LoaduserData();
            //check if the user allready exest in the data base
            foreach (User x in userList)
            {
                if (x.Get_Nick_Name().Equals(user)&x.PassWordCheck(password))
                {
                    return x;
                }
            }
            //return repeseting number as a replay

            //loging activety 
            logging_activety.logging_msg("user in not in the data base");

            return null;
        }
    }
}
