using System;
using System.Collections.Generic;
using System.Text;


namespace persistent_layer.Data_type
{
    [Serializable]
    public class Message
    {
       private Guid id;
       private User sender;
       private DateTime time;
       private String content;
       

        public Message(User sender, String messageBody , DateTime sendingTime) {

            this.sender = sender;
            time = sendingTime;
            content = messageBody;
        }
        public Guid getGuid()
        {
            return id;
        }

        public String getSender()
        {
            return sender.getNickName();
        }
        public DateTime getTime()
        {
            return time;
        }

        public int getGroupID()
        {
            return sender.getGroupID();
        }
        
        public int getID()
        {
            return sender.getID();
        }

        public String getContent()
        {
            return content;
        }
    }
}
