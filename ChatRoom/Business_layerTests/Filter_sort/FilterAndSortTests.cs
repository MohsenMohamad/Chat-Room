using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business_layer.Filter_sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using persistent_layer.Data_type;

namespace Business_layer.Filter_sort.Tests
{
    [TestClass()]
    public class FilterAndSortTests
    {

        [TestMethod()]
        public void sortTest()
        {
            //loging activety 
            logging_activety.logging_msg("TEST FOR SORT FUNCTION===========================================test start==");

            List<Message> msgList = new List<Message>();
            Message m1 = new Message( Guid.Empty , "adam", DateTime.Now, "hi","1");
            Message m2 = new Message(Guid.Empty, "roy", DateTime.Now, "roy", "20");
            Message m3 = new Message(Guid.Empty, "sam", DateTime.Now, "what", "10");
            msgList.Add(m1);
            msgList.Add(m2);
            msgList.Add(m3);
            FilterAndSort tmp = new FilterAndSort();
            msgList = tmp.Filterandsort(msgList, "None", "", "", "g_id, nickname, and timestamp", false);
            Assert.AreEqual(msgList.First().grupid,"20");

            //loging activety 
            logging_activety.logging_msg("END OF THE SORT FUNCTION TEST===================================test end==");
        }
        [TestMethod()]
        public void filtersort1Test()
        {
            //loging activety 
            logging_activety.logging_msg("TEST FOR FILTERSORT FUNCTION====================================test start==");

            List<Message> msgList = new List<Message>();
            Message m1 = new Message(Guid.Empty, "adam", DateTime.Now, "hi", "1");
            Message m2 = new Message(Guid.Empty, "roy", DateTime.Now, "roy", "1");
            Message m3 = new Message(Guid.Empty, "sam", DateTime.Now, "what", "10");
            msgList.Add(m1);
            msgList.Add(m2);
            msgList.Add(m3);
            FilterAndSort tmp = new FilterAndSort();
            msgList = tmp.Filterandsort(msgList, "group", "1", "", "Nickname", true);
            Assert.AreEqual(msgList.First().UserName, "adam");

            //loging activety 
            logging_activety.logging_msg("END OF THE FILTERSORT FUNCTION TEST=============================test end==");

        }
        [TestMethod()]
        public void filtersort2Test()
        {
            //loging activety 
            logging_activety.logging_msg("TEST #2 FOR FILTERSORT  FUNCTION================================test start==");

            List<Message> msgList = new List<Message>();
            Message m1 = new Message(Guid.Empty, "adam", DateTime.Now, "hi", "1");
            Message m2 = new Message(Guid.Empty, "roy", DateTime.Now, "roy", "1");
            Message m3 = new Message(Guid.Empty, "sam", DateTime.Now, "what", "10");
            msgList.Add(m1);
            msgList.Add(m2);
            msgList.Add(m3);
            FilterAndSort tmp = new FilterAndSort();
            msgList = tmp.Filterandsort(msgList, "group", "1", "", "Nickname", false);
            Assert.AreEqual(msgList.First().UserName, "roy");

            //loging activety 
            logging_activety.logging_msg("END OF THE FILTERSORT FUNCTION TEST #2==========================test end==");
        }
    }
}