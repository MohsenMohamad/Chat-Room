using System;
using System.Collections.Generic;
using System.Text;
using Communication_Layer.CommunicationLayer;

namespace persistent_layer.Data_type
{
    [Serializable]
    public class Message : IMessage
    {
       public Guid ID;
       public string UserName;
       public DateTime Data;
        public string MessageContent;
       

        public Message(Guid Id, string UserName, DateTime Data, string MessageContent) {
            this.ID = Id;
            this.UserName = UserName;
            this.Data = Data;
            this.MessageContent = MessageContent;
        }
        public Guid Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        string IMessage.UserName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        DateTime IMessage.Date
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        string IMessage.MessageContent
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        string IMessage.GroupID
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
