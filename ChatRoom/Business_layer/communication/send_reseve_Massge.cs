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
        public void Send(string userName,int gID)
        {
            //loging the activety of the project 


            //----------------------------------------------------------------------------
            bool m=false;
            string mes;
            do
            {
                Console.WriteLine("Enter your message with Limet of 150 charctar");
                mes = Console.ReadLine();
                if (mes.Length > 150)
                {
                    Console.WriteLine("the message you Enterd is to long pleas try again");
                    m = true;
                }
                else
                {
                    m = false;
                }
            } while (m);
            string url = "http://ise172.ise.bgu.ac.il";
            MileStoneClient.CommunicationLayer.Communication a = new MileStoneClient.CommunicationLayer.Communication();
            IMessage newmsg=a.Send(url, Convert.ToString(gID),userName, mes);
            //save to the data base which is not ready -_-

            //-----------------------------------------------------------------------
            Console.WriteLine("message is sent..");
        }
        public static List<IMessage> recallMessage()
        {
            //----------------------------------------------------------------------------------------here
            string url = "http://ise172.ise.bgu.ac.il";
            List<IMessage> msgList = MileStoneClient.CommunicationLayer.Communication.GetTenMessages(url);
            List<IMessage> msgList2 = new List<IMessage>();
            foreach(IMessage x in msgList)
            {
                Console.WriteLine(x);
                //msgList2.Add((Message)x);
            }
            //save the list in the 
            Console.ReadLine();
            persistent_layer.Data_Base.savemessagedata(msgList);
            
            return msgList;
        }
    }
}
