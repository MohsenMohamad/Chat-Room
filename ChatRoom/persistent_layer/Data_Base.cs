using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using persistent_layer.Data_type;
using Communication_Layer;
using Communication_Layer.CommunicationLayer;

namespace persistent_layer
{
    public class Data_Base
    {
        public static void saveuserdata(List<User> userlist)
        {
            Stream myFileStream = File.Create("userdata.dat");
            BinaryFormatter serializes = new BinaryFormatter();
            serializes.Serialize(myFileStream, userlist);
            myFileStream.Close();
        }
        public static List<User> LoaduserData()
        {
            if (File.Exists("userdata.dat"))
            {
                Stream myOtherFileStream = File.OpenRead("userdata.dat");
                BinaryFormatter deserializer = new BinaryFormatter();
                List<User> a = (List<User>)deserializer.Deserialize(myOtherFileStream);
                myOtherFileStream.Close();
                return a;
            }
            else
            {
                List<User> tmp = new List<User>();
                return tmp;
            }
        }
        public static void savemessagedata(List<Message> messagelist)
        {
           /* Stream myFileStream = File.Create("messagedata.dat");
            List<Message> a = returnmessages(10);
            foreach (Message x in messagelist) {
                if (!(a.Contains(x))){

                    BinaryFormatter serializes = new BinaryFormatter();
                    serializes.Serialize(myFileStream, a);
                    myFileStream.Close();
                   }
                }
            }*/
            Stream myFileStream = File.Create("messagedata.dat");
            BinaryFormatter serializes = new BinaryFormatter();
            serializes.Serialize(myFileStream, messagelist);
            myFileStream.Close();
        }
        
        public static List<Message> loadmessageData()
        {
            if (File.Exists("messagedata.dat"))
            {
                Stream myOtherFileStream = File.OpenRead("messagedata.dat");
                BinaryFormatter deserializer = new BinaryFormatter();
                List<Message> a = (List<Message>)deserializer.Deserialize(myOtherFileStream);
                myOtherFileStream.Close();
                return a;
            }
            else
            {
                List<Message> tmp = new List<Message>();
                return tmp;
            }
        }

        public static List<Message> returnmessages(int x)
        {
            List<Message> messagesb = loadmessageData();
            List<Message> messagesa = new List<Message>();
            for (int i = messagesb.Count-x ; i < messagesb.Count; i++)
            {
                messagesa.Add(messagesb[i]);
            }
            return messagesa;
        }
        public static void deleteusers()
        {
            File.Delete("userdata.dat");
        }
        public static void deletemessages()
        {
            File.Delete("messagedata.dat");
        }
    }
}
