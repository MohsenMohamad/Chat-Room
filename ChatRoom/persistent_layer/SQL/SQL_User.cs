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
        private string connetion_string;
        private string sql_query;
        private string server_address;
        private string database_name;
        private string user_name;
        private string password;

        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader data_reader;
        public SQL_User()
        {
            string connetion_string = null;
            string sql_query = null;
            string server_address = "ise172.ise.bgu.ac.il,1433\\DB_LAB";
            string database_name = "MS3";
            string user_name = "publicUser";
            string password = "isANerd";

            SqlConnection connection;
            SqlCommand command;

            connetion_string = $"Data Source={server_address};Initial Catalog={database_name };User ID={user_name};Password={password}";
            connection = new SqlConnection(connetion_string);
        }
        public String Exists(String Group_Id, String Name, String Password)
        {
            try
            {
                connection.Open();
                sql_query = "select * from [dbo].[Users];";
                command = new SqlCommand(sql_query, connection);
                data_reader = command.ExecuteReader();
                while (data_reader.Read())
                {
                    if (Group_Id.Equals(data_reader.GetValue(1) + "") && Name.Equals((data_reader.GetValue(2) + "").Trim()) && password.Equals(data_reader.GetValue(3) + ""))
                    {
                        return ((data_reader.GetValue(0)+ "").Trim());
                    }
                }
                data_reader.Close();
                command.Dispose();
                connection.Close();
                return "-1";
            }
            catch (Exception ex)
            {
                return (ex.ToString());
            }
            
        }
        public int LoginUser(String Name, String Group_Id, String Password) {
            return (Convert.ToInt32((Exists(Group_Id, Name, Password))));
        }
        public Boolean RegisterUser(String name, String password, String groupID) {
            return true;
        }
    }
}
