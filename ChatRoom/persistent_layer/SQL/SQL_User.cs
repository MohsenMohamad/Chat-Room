using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace persistent_layer.SQL
{
    public class SQL_User
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
        public SQL_User()
        {


            connetion_string = $"Data Source={server_address};Initial Catalog={database_name };User ID={user_name};Password={password}";
            connection = new SqlConnection(connetion_string);
        }
        public String Exists(String userName, String userPassword , String GroupID)
        {
            try
            {
                connection.Open();
                sql_query = "select * from [dbo].[Users];";
                command = new SqlCommand(sql_query, connection);
                data_reader = command.ExecuteReader();
                while (data_reader.Read())
                {
                    if (GroupID.Equals((data_reader.GetValue(1) + "").Trim()) && userName.Equals((data_reader.GetValue(2) + "").Trim()) && userPassword.Equals((data_reader.GetValue(3) + "").Trim()))
                        return ((data_reader.GetValue(0) + "").Trim());
                        
                    
                }
                data_reader.Close();
                command.Dispose();
                connection.Close();
                return "-1";
            }
            catch (Exception ex)
            {
                return ("Cant connect to database");
            }
            
        }
        public int LoginUser(String userName, String userPassword, String groupID) {

            int id = Convert.ToInt32(Exists(userName, userPassword, groupID));
            return id;
            
        }
        public Boolean RegisterUser(String name, String password, String groupID) {
            return true;
        }
    }
}
