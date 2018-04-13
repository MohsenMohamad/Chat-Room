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
            List<Message> msgList=null; 
            return msgList;
        }
        public static List<Message> pullLastMassages()
        {
            logging_activety.logging_msg("trying to recall the last 20 messages form the data base");
            List<Message> msgList = null;
            return msgList;
        }

    }
}
