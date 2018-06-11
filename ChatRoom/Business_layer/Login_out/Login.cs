using System;
using System.Collections.Generic;
using System.Text;
using persistent_layer.Data_type;
using persistent_layer;
using persistent_layer.logfile;
using persistent_layer.SQL;


namespace Business_layer.Login_out
{
    public class login
    {
        
        private hashing toHash= new hashing();

        public User Login(String name , String password , String groupID)
        {

            logging_activety.logging_msg("login attempt"); // Log
            SQL_User temp = new SQL_User();
            //    String hashed_Password = hashing.GetHashString(password);
            String hashed_Password = password;
            int id = temp.LoginUser(name, password , groupID);

            if (id == -1)
            {
                logging_activety.logging_msg("User is not in the data base"); // Log
                return null;
            }
            else
            {
                logging_activety.logging_msg("user found | enter to login window"); // Log
                User user = new User(name, password, Convert.ToInt32(groupID) , id );

                return user;

            }
            
        }
    }
}
