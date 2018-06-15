using System;
using System.Collections.Generic;
using System.Text;
using persistent_layer.Data_type;
using persistent_layer;
using persistent_layer.logfile;
using System.Linq;
using persistent_layer.SQL;

namespace Business_layer.Login_out
{
    public class register
    {

        private hashing toHash = new hashing();
        public bool newRegister(String name , String password , String groupID)
        {

            //checks if the user already exists in the data base

            String hashed_Password = hashing.GetHashString(password+ "1337");

            SQL_User temp = new SQL_User();
            bool added = temp.RegisterUser(name, hashed_Password, groupID);
            if (added)
            {
                logging_activety.logging_msg("Registering was done successfuly"); // Log
                return true;
            }
            else
            {
                logging_activety.logging_msg("Registration Failed : User already exists"); // Log
                return false;
            }
            
            // Asks the Data Access Layer to add the user to the database 
            
        }
        
        public static int Logout()
        {
            //request to logout from the server
            return 0;
        }
    }
}
