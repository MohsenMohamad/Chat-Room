using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using persistent_layer.Data_type;
using persistent_layer.logfile;
using Communication_Layer.CommunicationLayer;

namespace Business_layer.communication
{
    public class send_reseve_Massge
    {
        public string url = "http://ise172.ise.bgu.ac.il";
        public void Send(string userName,int gID,string usermsg)
        {
            //loging the activety of the project 
            LOG.LogFile("trying to send message by the User:"+userName+" G_ID:"+gID);
            logging_activety.logging_msg("trying to send message by the User:" + userName + " G_ID:" + gID);

            
            
            MileStoneClient.CommunicationLayer.Communication a = new MileStoneClient.CommunicationLayer.Communication();
            IMessage newmsg=a.Send(url, Convert.ToString(gID),userName, usermsg);
            Message saveMsg =new Message(newmsg.Id, newmsg.UserName, newmsg.Date, newmsg.MessageContent);
            List<Message> msgList = new List<Message>();
            msgList.Add(saveMsg);
            persistent_layer.Data_Base.savemessagedata(msgList);
            
        }
        public static List<Message> recallMessage()
        {
            string url = "http://ise172.ise.bgu.ac.il";
            //loging the activety of the project 
            logging_activety.logging_msg("trying to recall the last 10 messages form the server");
            List<IMessage> msgList = MileStoneClient.CommunicationLayer.Communication.GetTenMessages(url);
            List<Message> msgList2 = new List<Message>();
            foreach (IMessage x in msgList)
            {
                
                msgList2.Add(new Message(x.Id, x.UserName, x.Date, x.MessageContent));
            } 
            Console.ReadLine();
            persistent_layer.Data_Base.savemessagedata(msgList2);
            
            return msgList2;
        }
    }
}
