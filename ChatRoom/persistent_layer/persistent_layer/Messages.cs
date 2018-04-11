using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistent_layer
{
    [Serializable]
   public class Messages
    {
        public String Msg;

        public Messages() { } //empty constructor is required for serialization


        public Messages(string msg) {
            Msg = msg;
        }
    }
}
