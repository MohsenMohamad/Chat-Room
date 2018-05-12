using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace persistent_layer.logfile
{
    public class LOG
    {
        public static void LogFile(string msg)

        {
            StreamWriter log;

            if (!File.Exists("logfile.txt"))
            {
                log = new StreamWriter("logfile.txt");
            }
            else
            {
                log = File.AppendText("logfile.txt");
            }

            // Write to the file:

            log.WriteLine("Data Time:" + DateTime.Now);

            log.WriteLine("Action:" + msg);

            log.Close();
        }
    }
}
