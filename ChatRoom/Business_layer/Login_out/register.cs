using System;
using System.Collections.Generic;
using System.Text;
using persistent_layer.Data_type;
using persistent_layer;
using persistent_layer.logfile;

namespace Business_layer.Login_out
{
    public class register
    {
        private List<User> userList = new List<User>();
        private static int NewRegister(User user)
        {
            return newRegister(user);
        }
        private static int newRegister(User user)
        {

            //LOG 
            LOG.LogFile( "registration action with new user " + user.Get_Nick_Name() + " and a ID Group " + user.Get_ID());
            
            //check if the user allready exest in the data base
            foreach (User x in userList)
            {
                if (x.sameuser(user))
                {
                    return -1;
                }
                if (x.Get_ID() == user.Get_ID())
                {
                    return -2;
                }

            }
            userList = Data_Base.LoaduserData();
            // add to the user file 

            //return repeseting number as a replay
            return 0;
        }
        
        public static int Logout()
        {
            //request to logout from the server
            return 0;
        }
    }
}
