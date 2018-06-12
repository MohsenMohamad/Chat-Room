using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using persistent_layer.Data_type;

namespace Business_layer.communication
{
    public class Sending
    {
       
        public void SendMessage(User user, String content , DateTime time)
        {

            // do not forget to add logging!!!!!!!!!!!1


            Message message = new Message(user,content,time.ToUniversalTime());
            // send "message" to the Persistent_Layer


            //  returns a value which decides if the message was sent successfuly or there is an error
            // with database connection
            
        }

        public void EditMessage(User user , Message oldMessage , String newContent , DateTime time)
        {
            
            //  returns a value which decides if the message was edited successfuly or there is an error
            // with database connection
        }
    }
}
