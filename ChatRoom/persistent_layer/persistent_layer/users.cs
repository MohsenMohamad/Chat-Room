using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistent_layer
{
    [Serializable]
    public class Users
    {
        public string Name;
        public string Id;



        public Users() { } //empty constructor is required for serialization

        public Users(string name, string id) {
            Name = name;
            Id = id;
        }
    }
}
