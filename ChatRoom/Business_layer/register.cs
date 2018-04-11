using System;
using System.Collections.Generic;
using System.Text;
using persistent_layer.logfile;
using persistent_layer;

namespace Business_layer
{
    public class register
    {
        private List<User> userList = new List<User>();
        public int newRegister(User user)
        {
            //LOG 
            LOG.LogFile( "registration action with new user " + user.Get_Nick_Name() + " and a ID Group " + user.Get_ID());
            //check if the user allready exest in the data base
            foreach (User x in userList)
            {
                if (x.sameUser(user))
                {
                    return -1;
                }
                if (x.Get_ID() == user.Get_ID())
                {
                    return -2;
                }
                
            }
            // add to the user file 

            //return repeseting number as a replay
            return 0;
        }
        public static int  Login(string user,string password)
        {
            //request to loging from the server
            return 0;
        }
        public static int Logout()
        {
            //request to logout from the server
            return 0;
        }
    }
}
