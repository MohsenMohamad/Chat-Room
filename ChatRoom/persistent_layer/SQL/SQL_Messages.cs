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
                    Guid guid = Guid.Parse(data_reader.GetValue(0)+"");
                    time = time.ToLocalTime();
                    lastMessages.Add(new Message(guid,user, messageContent, time));
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
        public bool Send(User user, String content, DateTime time)
        {
                try
                {
                    connection.Open();
                    command = new SqlCommand(null, connection);
                    command.CommandText =
                        " insert into Messages (Guid,User_Id,SendTime,Body) " + // Fill code here. SQL query for inserting values into customer table *******************************************************
                        "VALUES (@Guid,@User_Id,@SendTime,@Body)";
                    SqlParameter Guid_param = new SqlParameter(@"Guid", SqlDbType.Text, 68);
                    SqlParameter User_Id_param = new SqlParameter(@"User_Id", SqlDbType.Int, 20);
                    SqlParameter SendTime_param = new SqlParameter(@"SendTime", SqlDbType.DateTime, 20);
                    SqlParameter Body_param = new SqlParameter(@"Body", SqlDbType.Text, 100);
                    Guid msgGuid = Guid.NewGuid();

                    Guid_param.Value = msgGuid.ToString();
                    User_Id_param.Value = user.getID();
                    SendTime_param.Value = time;
                    Body_param.Value = content;

                    command.Parameters.Add(Guid_param);
                    command.Parameters.Add(User_Id_param);
                    command.Parameters.Add(SendTime_param);
                    command.Parameters.Add(Body_param);


                    // Call Prepare after setting the Commandtext and Parameters.
                    command.Prepare();

                    int num_rows_changed = command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        public bool Edit(Message oldMessage, String newContent, DateTime editTime)
        {
            try
            {
                connection.Open();
                command = new SqlCommand(null, connection);
                command.CommandText =
                    " UPDATE Messages SET Body=@Body,SendTime=@SendTime  Where Guid=@Guid";
                SqlParameter Guid_param = new SqlParameter(@"Guid", SqlDbType.Char, 68);
                SqlParameter SendTime_param = new SqlParameter(@"SendTime", SqlDbType.DateTime, 20);
                SqlParameter Body_param = new SqlParameter(@"Body", SqlDbType.Text, 100);
                Guid msgGuid = Guid.NewGuid();

                Guid_param.Value = oldMessage.getGuid() + "";
                SendTime_param.Value = editTime;
                Body_param.Value = newContent;

                command.Parameters.Add(Guid_param);
                command.Parameters.Add(SendTime_param);
                command.Parameters.Add(Body_param);


                // Call Prepare after setting the Commandtext and Parameters.
                command.Prepare();

                command.Dispose();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
