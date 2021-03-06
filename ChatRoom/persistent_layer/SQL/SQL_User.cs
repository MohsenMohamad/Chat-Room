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
        public String Exists(String userName, String userPassword, String GroupID)
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
                return ("-2");
            }

        }
        public int LoginUser(String userName, String userPassword, String groupID) {

            int id = Convert.ToInt32(Exists(userName, userPassword, groupID));
            return id;

        }
        public Boolean RegisterUser(String userName, String userPassword, String GroupID) {

            String checkId = Exists(userName, userPassword, GroupID);
            if (checkId.Equals("-2")) {
                return false;
            }
            if (checkId.Equals("-1"))
            {
                try
                {
                    connection.Open();
                    command = new SqlCommand(null, connection);
                    command.CommandText =
                        " insert into Users (Group_Id,Nickname,Password) " + // Fill code here. SQL query for inserting values into customer table *******************************************************
                        "VALUES (@Group_Id,@Nickname,@Password)";
                    SqlParameter Group_Id_param = new SqlParameter(@"Group_Id", SqlDbType.Int, 20);
                    SqlParameter Nickname_param = new SqlParameter(@"Nickname", SqlDbType.Text, 10);
                    SqlParameter Password_param = new SqlParameter(@"Password", SqlDbType.Text, 64);

                    Group_Id_param.Value = Convert.ToInt32(GroupID);
                    Nickname_param.Value = userName;
                    Password_param.Value = userPassword;

                    command.Parameters.Add(Group_Id_param);
                    command.Parameters.Add(Nickname_param);
                    command.Parameters.Add(Password_param);


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
            else
            {
                return false;
            }
        }
        public User returnuser(int userid){
            try
            {
                connection.Open();
                sql_query = "select * from [dbo].[Users];";
                command = new SqlCommand(sql_query, connection);
                data_reader = command.ExecuteReader();
                while (data_reader.Read())
                {
                    if (userid==((int)data_reader.GetValue(0)))
                    {
                        User user = new User((data_reader.GetValue(2) + "").Trim(),(data_reader.GetValue(3) + "").Trim(),((int)data_reader.GetValue(1)),userid);
                        data_reader.Close();
                        command.Dispose();
                        connection.Close();
                        return user;
                    }
                }
                data_reader.Close();
                command.Dispose();
                connection.Close();
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<User> returnalluser(string filtergroubid)
        {
            List<User> usergroupid = new List<User>();
            try
            {
                connection.Open();
                sql_query = "select * from [dbo].[Users];";
                command = new SqlCommand(sql_query, connection);
                data_reader = command.ExecuteReader();
                while (data_reader.Read())
                {
                    if (Convert.ToInt32(filtergroubid) == ((int)data_reader.GetValue(1)))
                    {
                        User user = new User((data_reader.GetValue(2) + "").Trim(), (data_reader.GetValue(3) + "").Trim(), Convert.ToInt32(filtergroubid), ((int)data_reader.GetValue(0)));
               
                        usergroupid.Add(user);
                    }
                }
                data_reader.Close();
                command.Dispose();
                connection.Close();
                return usergroupid;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<User> returnalluser(string userid ,string username)
        {
            List<User> usergroupid = new List<User>();
            try
            {
                connection.Open();
                sql_query = "select * from [dbo].[Users];";
                command = new SqlCommand(sql_query, connection);
                data_reader = command.ExecuteReader();
                while (data_reader.Read())
                {
                    if (Convert.ToInt32(userid) == ((int)data_reader.GetValue(1))&&(username.Equals((data_reader.GetValue(2) + "").Trim())))
                    {
                        User user = new User((data_reader.GetValue(2) + "").Trim(), (data_reader.GetValue(3) + "").Trim(), Convert.ToInt32(userid), ((int)data_reader.GetValue(0)));

                        usergroupid.Add(user);
                    }
                }
                data_reader.Close();
                command.Dispose();
                connection.Close();
                return usergroupid;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
