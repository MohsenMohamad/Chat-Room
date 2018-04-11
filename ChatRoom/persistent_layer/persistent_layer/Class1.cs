using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;
namespace persistent_layer
{
    public class Class1
    {
        public static void saveuserdata(List<User> userlist) {
            File.WriteAllText("userdata.dat", new JavaScriptSerializer().Serialize(userlist));
        }
        public static List<Users> LoaduserData()
        {
            if (File.Exists("userdata.dat"))
            {
                return new JavaScriptSerializer().Deserialize<List<Users>>(File.ReadAllText("userdata.dat"));
            }
            else return new List<Users>();
        }
        public static void savemessagedata(List<Messages> messagelist) {
            File.WriteAllText("messagedata.dat", new JavaScriptSerializer().Serialize(messagelist));
        }
        public static List<Messages> loadmessageData() {
            if (File.Exists("messagedata.dat"))
            {
                return new JavaScriptSerializer().Deserialize<List<Messages>>(File.ReadAllText("messagedata.dat"));
            }
            else return new List<Messages>();
        }

        public static List<Messages> returnmessages(int x) {
            List<Messages> messagesb = loadmessageData();
            List<Messages> messagesa = loadmessageData();
            for (int i = 0; i < messagesb.Count; i++)
            {
                messagesa.Add(messagesb[i]);
            }
            return messagesa;
        }
        public static void deleteusers() {
            File.Delete("userdata.dat");
        }
        public static void deletemessages()
        {
            File.Delete("messagedata.dat");
        }

    }
}
