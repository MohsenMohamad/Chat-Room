using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using persistent_layer.Data_type;


namespace Business_layer.communication
{
    public static class Retrieve
    {
        
        public static List<Message> pullLastMassages(DateTime time)
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
