using System;
using System.Collections.Generic;
using System.Text;
using persistent_layer.Data_type;
using persistent_layer;
using persistent_layer.logfile;
using System.Linq;

namespace Business_layer.Login_out
{
    public class register
    {
        
        public User newRegister(User user)
        {
            List<User> userList = new List<User>();
           
            //Console.WriteLine(userList.Count());
           // Console.ReadLine();
            //LOG 
            LOG.LogFile( "registration action with new user " + user.Get_Nick_Name() + " and a ID Group " + user.Get_ID());
            //Data_Base.LoaduserData();
            userList = Data_Base.LoaduserData();
            //check if the user allready exest in the data base
            if (userList != null)
            {
                foreach (User x in userList)
                {
                    if (x.sameuser(user))
                    {
                        return null;
                    }
                    if (x.Get_ID() == user.Get_ID())
                    {
                        return x;
                    }

                }
            }

            // add to the user file 
            //userList.Insert(0, user);
            userList.Add(user);
            Data_Base.saveuserdata(userList);
            //return repeseting number as a replay
            return user;
        }
        
        public static int Logout()
        {
            //request to logout from the server
            return 0;
        }
    }
}
