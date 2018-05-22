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
        
        
        public List<Message> Filterandsort(List<Message> msg, string filter,string fid,string fname,string sort, Boolean asc) {
            
            //loging activety 
            logging_activety.logging_msg("sorting the Message List");

            if (!(filter.Equals("None"))){
                if (filter.Equals("group"))
                {
                    msg = msg.Where(x => x.grupid==fid).ToList();
                }
                if (filter.Equals("user")) {
                    msg = msg.Where(x => x.grupid == fid & x.UserName == fname).ToList();
                }
            }
            if (sort.Equals("timestamp")) {
                if (asc == true)
                {
                    msg = msg.OrderBy(x => x.Data).ToList();
                }
                if (asc == false) {
                    msg = msg.OrderByDescending(x => x.Data).ToList();
                }
            }
            if (sort.Equals("Nickname"))
            {
                if (asc == true)
                {
                    msg = msg.OrderBy(x => x.UserName).ToList();
                }
                if (asc == false)
                {
                    msg = msg.OrderByDescending(x => x.UserName).ToList();
                }
            }
            if (sort.Equals("g_id, nickname, and timestamp")) {
                if (asc == true)
                {
                    msg = msg.OrderBy(x => x.grupid).ThenBy(x => x.UserName).ThenBy(x => x.Data).ToList();
                }
                if (asc == false)
                {
                    msg = msg.OrderByDescending(x => x.grupid).ThenByDescending(x => x.UserName).ThenByDescending(x => x.Data).ToList();
                }
            }
            return msg;
        }
    }
}
