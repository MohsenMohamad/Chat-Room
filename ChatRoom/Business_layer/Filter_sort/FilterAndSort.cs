using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using persistent_layer.Data_type;
using Business_layer;

namespace Business_layer.Filter_sort
{
    public class FilterAndSort
    {
        
        
        public List<Message> Filterandsort(List<Message> msg,string sort, Boolean asc) {
            
            //loging activety 
            logging_activety.logging_msg("sorting the Message List");

            if (sort.Equals("timestamp")) {
                if (asc == true)
                {
                    msg = msg.OrderBy(x => x.getTime()).ToList();
                }
                if (asc == false) {
                    msg = msg.OrderByDescending(x => x.getTime()).ToList();
                }
            }
            if (sort.Equals("Nickname"))
            {
                if (asc == true)
                {
                    msg = msg.OrderBy(x => x.getSender()).ToList();
                }
                if (asc == false)
                {
                    msg = msg.OrderByDescending(x => x.getSender()).ToList();
                }
            }
            if (sort.Equals("g_id, nickname, and timestamp")) {
                if (asc == true)
                {
                    msg = msg.OrderBy(x => x.getGroupID()).ThenBy(x => x.getSender()).ThenBy(x => x.getTime()).ToList();
                }
                if (asc == false)
                {
                    msg = msg.OrderByDescending(x => x.getGroupID()).ThenByDescending(x => x.getSender()).ThenByDescending(x => x.getTime()).ToList();
                }
            }
            return msg;
        }
    }
}
