using System;
using MileStoneClient.CommunicationLayer;

namespace Business_layer
{
    public class Message : IMessage 
    {
        private string UserName;
        private DateTime Date;
        private string MessageContent;
        private string GroupID;
        
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
        /*
        public void message(string userN, string gID, DateTime time, string theMessage)
        {
            if (userN == null || gID == null || theMessage == null || time == null)
                throw new NullReferenceException("invaled input to Message");
            UserName = userN;
            GroupID = gID;
            Date = time;
            MessageContent = theMessage;
        }

        public string ToString() => UserName + " : " + GroupID + " : " + Date + " : " + MessageContent;
        public string getUserName()
        {
            return UserName;
        }*/
        public string getContent()
        {
            return MessageContent;
        }
        /*
        public string getGroupID()
        {
            return GroupID;
        }
        public DateTime getTime()
        {
            return Date;
        }
        */
    }
}
