using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using persistent_layer.Data_type;
using persistent_layer.SQL;

namespace Business_layer.communication
{
    public class Sending
    {
        public bool SendMessage(User user, String content , DateTime time)
        {
            SQL_Messages send = new SQL_Messages();
            // do not forget to add logging!!!!!!!!!!!!

            // send "message" to the Persistent_Layer

            bool success = send.Send(user,content,time.ToUniversalTime());
            //  returns a value which decides if the message was sent successfuly or there is an error
            // with database connection
            return success;
        }

        public bool EditMessage(Message oldMessage , String newContent , DateTime time)
        {
            SQL_Messages send = new SQL_Messages();

            bool success = send.Edit(oldMessage, newContent, time.ToUniversalTime());

            //  returns a value which decides if the message was edited successfuly or there is an error
            // with database connection

            return success;
        }
    }
}
