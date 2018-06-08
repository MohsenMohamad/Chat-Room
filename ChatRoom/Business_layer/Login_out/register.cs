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
            
            
            logging_activety.logging_msg("Registration attempt"); // Log


            //checks if the user already exists in the data base
            logging_activety.logging_msg("Registration Failed : User already exists"); // Log





            // Asks the Data Access Layer to add the user to the database 
            logging_activety.logging_msg("Registering was done successfuly"); // Log
            
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
