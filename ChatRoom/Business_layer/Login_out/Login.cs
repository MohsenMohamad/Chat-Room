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
        
        private hashing toHash= new hashing();

        public User Login(string user, string password)
        {

            logging_activety.logging_msg("login attempt"); // Log
            String hashed_Password = hashing.GetHashString(password);

            //check if the user already exists in the database

            // if found return the user (with the normal password)
            logging_activety.logging_msg("user found | enter to login window"); // Log

            // if not found return null
            logging_activety.logging_msg("user is not in the data base"); // Log

            return null;
        }
    }
}
