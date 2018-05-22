using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using persistent_layer.Data_type;
using Communication_Layer.CommunicationLayer;

namespace Business_layer.communication
{
    public class send_reseve_Massge
    {
        public string url = "http://ise172.ise.bgu.ac.il";
       

        public void Send(string userName,int gID,string usermsg)
        {
            
            //loging the activety of the project 
            logging_activety.logging_msg("send message by the User:" + userName + " G_ID:" + gID);

            MileStoneClient.CommunicationLayer.Communication a = new MileStoneClient.CommunicationLayer.Communication();
            
            //log activerty
            logging_activety.logging_msg("reseve IMessage from server");

            IMessage newmsg=a.Send(url, Convert.ToString(gID),userName, usermsg);
            Message saveMsg =new Message(newmsg.Id, newmsg.UserName, newmsg.Date.AddHours(3), newmsg.MessageContent,newmsg.GroupID);
            List<Message> msgList = new List<Message>();

            //log activety
            logging_activety.logging_msg("add the new message to the data base");

            msgList.Add(saveMsg);
            persistent_layer.Data_Base.savemessagedata(msgList);
            
        }
        public static List<Message> recallMessage()
        {
            string url = "http://ise172.ise.bgu.ac.il";
            
           
            //loging the activety of the project 
            logging_activety.logging_msg("recall the last 10 messages form the server");

            List<IMessage> msgList = MileStoneClient.CommunicationLayer.Communication.GetTenMessages(url);
            List<Message> msgList2 = new List<Message>();
            Guid tmp = new Guid();

            //loging activety 
            logging_activety.logging_msg("recall the latest GUID from the data base");

            if (persistent_layer.Data_Base.returnmessages(1).Count() > 0)
            {
                tmp = persistent_layer.Data_Base.returnmessages(1)[0].ID;
            }
            else
            {
                //loging activety 
                logging_activety.logging_msg("message data base is empty");
            }

            //loging activety 
            logging_activety.logging_msg("convert from IMesssage to Message");

            foreach (IMessage x in msgList)
            {
                if (tmp == x.Id)
                {
                    msgList2.Clear();
                }
                else
                msgList2.Add(new Message(x.Id, x.UserName, x.Date.AddHours(3), x.MessageContent,x.GroupID));
            }

            //loging activety 
            logging_activety.logging_msg("save the Messages to the data base");

            persistent_layer.Data_Base.savemessagedata(msgList2);

            //loging activety 
            logging_activety.logging_msg("recall the latest 10 Messages from data base");

            return persistent_layer.Data_Base.returnmessages(10);
            //return msgList2;
        }
    }
}
