using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business_layer.Login_out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using persistent_layer.Data_type;

namespace Business_layer.Login_out.Tests
{
    [TestClass()]
    public class loginTests
    {
        [TestMethod()]
        public void LoginpassTest()
        {
            //loging activety 
            logging_activety.logging_msg("TEST FOR LOGIN FUNCTION========================================test start==");

            login lin = new login();
            Assert.AreEqual(lin.Login("adnan", "adnan").Name, "adnan");//if the user can login return the user
            //loging activety 

            logging_activety.logging_msg("END OF THE LOGIN FUNCTION TEST==================================test end==");
        }
        [TestMethod()]
        public void LoginnotpassTest()
        {
            //loging activety 
            logging_activety.logging_msg("TEST #2 FOR LOGING  FUNCTION===================================test start==");

            login lin = new login();
            Assert.AreEqual(lin.Login("adam", "adam"),null);//if the user can't login return null

            //loging activety 
            logging_activety.logging_msg("END OF THE LOGING FUNCTION TEST #2==============================test end==");
        }

    }
}