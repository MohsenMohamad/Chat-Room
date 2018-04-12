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
        public static void savemessagedata(List<IMessage> messagelist)
        {
            Stream myFileStream = File.Create("messagedata.dat");
            BinaryFormatter serializes = new BinaryFormatter();
            serializes.Serialize(myFileStream, messagelist);
            myFileStream.Close();
        }
        public static List<IMessage> loadmessageData()
        {
            if (File.Exists("messagedata.dat"))
            {
                Stream myOtherFileStream = File.OpenRead("messagedata.dat");
                BinaryFormatter deserializer = new BinaryFormatter();
                List<IMessage> a = (List<IMessage>)deserializer.Deserialize(myOtherFileStream);
                myOtherFileStream.Close();
                return a;
            }
            else
            {
                List<IMessage> tmp = new List<IMessage>();
                return tmp;
            }
        }

        public static List<IMessage> returnmessages(int x)
        {
            List<IMessage> messagesb = loadmessageData();
            List<IMessage> messagesa = loadmessageData();
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
