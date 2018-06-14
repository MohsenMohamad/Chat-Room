using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using persistent_layer.Data_type;
using persistent_layer.SQL;


namespace Business_layer.communication
{
    public class Retrieve
    {
        private SQL_Messages temp = new SQL_Messages();
        public List<Message> pullLastMassages()
        {
            logging_activety.logging_msg("recall the last 200 messages form the data base");

            List<Message> msgList = temp.pullLastMassages();
            return msgList;
        }
        public List<Message> pullNewMassages(DateTime time)
        {
            logging_activety.logging_msg("recall all messages form the data base");

            SQL_Messages temp = new SQL_Messages();
            List<Message> msgList = temp.pullNewMassages(time.ToUniversalTime());

            return msgList;
        }
        public List<Message> Filterid(string filtergroubid) {
            SQL_Messages temp = new SQL_Messages();
            List<Message> msgList = temp.aaa(filtergroubid);
            return msgList;
        }

    }
}
