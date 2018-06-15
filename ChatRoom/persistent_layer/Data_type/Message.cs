using System;
using System.Collections.Generic;
using System.Text;


namespace persistent_layer.Data_type
{
    [Serializable]
    public class Message
    {
       private User sender;
       private DateTime time;
       private String content;
       private Guid guid;

        public Message(Guid messageGuid ,User sender, String messageBody , DateTime sendingTime) {

            this.sender = sender;
            time = sendingTime;
            content = messageBody;
            guid = messageGuid;
            
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

        public Guid getGuid()
        {
            return guid;
        }

        public User getUser()
        {
            return sender;
        }
    }
}
