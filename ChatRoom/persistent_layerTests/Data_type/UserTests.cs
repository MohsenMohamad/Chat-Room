using Microsoft.VisualStudio.TestTools.UnitTesting;
using persistent_layer.Data_type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persistent_layer.Data_type.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void sameuserTest()
        {
            User same = new User("ali", 55, "123");
            Assert.AreEqual(same.sameuser(new User("ali", 55, "123")),true);
        }
        [TestMethod()]
        public void notsameuserTest()
        {
            User same = new User("ali", 55, "123");
            Assert.AreEqual(same.sameuser(new User("ahmad", 55, "123")), false);
        }
    }
}