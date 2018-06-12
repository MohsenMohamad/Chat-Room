using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using persistent_layer.Data_type;

namespace persistent_layer.SQL
{
    public class SQL_Messages
    {
        string connetion_string = null;
        string sql_query = null;
        string server_address = "ise172.ise.bgu.ac.il,1433\\DB_LAB";
        string database_name = "MS3";
        string user_name = "publicUser";
        string password = "isANerd";
        private SqlDataReader data_reader;
        SqlConnection connection;
        SqlCommand command;
        public SQL_Messages()
        {
            connetion_string = $"Data Source={server_address};Initial Catalog={database_name };User ID={user_name};Password={password}";
            connection = new SqlConnection(connetion_string);
        }
        public List<Message> pullLastMassages()
        {
            SQL_User temp = new SQL_User();
            List<Message> lastMessages= new List<Message>();
            try
            {
                connection.Open();
                sql_query = "select * from [dbo].[Messages];";
                command = new SqlCommand(sql_query, connection);
                data_reader = command.ExecuteReader();
                while (data_reader.Read())
                {
                    User user = temp.returnuser((int)data_reader.GetValue(1));
                    DateTime time = (DateTime)data_reader.GetValue(2);
                    String messageContent = ((String)data_reader.GetValue(3)).Trim();
                    time = time.ToLocalTime();
                    lastMessages.Add(new Message(user, messageContent, time));
                }
                data_reader.Close();
                command.Dispose();
                connection.Close();
                return lastMessages;
            }
            catch (Exception ex)
            {
                return lastMessages;
            }
        }
        public void aa(Message newmassage) {

        }

    }
}
