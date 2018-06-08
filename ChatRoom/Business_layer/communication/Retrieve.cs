using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using persistent_layer.Data_type;
using Communication_Layer.CommunicationLayer;


namespace Business_layer.communication
{
    public static class Retrieve
    {
        public static List<Message> pullMassages(User user)
        {
            logging_activety.logging_msg("trying to recall the messages sent by the user form the data base");
            //no data bass to retreve from.....
            List<Message> msgList = new List<Message>();
            List<Message> newmsg = new List<Message>();
            logging_activety.logging_msg("pull all messages from data base");
            msgList = persistent_layer.Data_Base.loadmessageData();
            foreach (Message x in msgList) {
                if (x.UserName == user.getNickName()) {
                    newmsg.Add(x);
                }
            }
                return newmsg;
        }
        public static List<Message> pullLastMassages()
        {
            logging_activety.logging_msg("recall the last 20 messages form the data base");

            List<Message> msgList = persistent_layer.Data_Base.returnmessages(20);
            return msgList;
        }
        public static List<Message> pullallMassages()
        {
            logging_activety.logging_msg("recall all messages form the data base");

            List<Message> msgList = persistent_layer.Data_Base.returnallmessages();
            return msgList;
        }

    }
}
