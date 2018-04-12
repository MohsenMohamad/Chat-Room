using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;
using persistent_layer.Data_type;

namespace persistent_layer
{
    public class Data_Base
    {
        public static void saveuserdata(List<User> userlist)
        {
           // File.Create("userdata.dat");
            File.AppendAllText("userdata.dat", new JavaScriptSerializer().Serialize(userlist));
            //File.WriteAllText("userdata.dat", new JavaScriptSerializer().Serialize(userlist));
        }
        public static List<User> LoaduserData()
        {
            // File.Create("userdata.dat");
            if (File.Exists("userdata.dat"))
            {
                return new JavaScriptSerializer().Deserialize<List<User>>(File.ReadAllText("userdata.dat"));
            }
            else
            {
                List<User> tmp= new List<User>();
                return tmp;
            }
        }
        public static void savemessagedata(List<Message> messagelist)
        {
            File.WriteAllText("messagedata.dat", new JavaScriptSerializer().Serialize(messagelist));
        }
        public static List<Message> loadmessageData()
        {
            if (File.Exists("messagedata.dat"))
            {
                return new JavaScriptSerializer().Deserialize<List<Message>>(File.ReadAllText("messagedata.dat"));
            }
            else return new List<Message>();
        }

        public static List<Message> returnmessages(int x)
        {
            List<Message> messagesb = loadmessageData();
            List<Message> messagesa = loadmessageData();
            for (int i = 0; i < messagesb.Count; i++)
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
