using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using persistent_layer.logfile;

namespace Business_layer
{
    public class logging_activety
    {
        public static void logging_msg(string log_msg)
        {
            LOG.LogFile(log_msg);
        }
    }
}
