namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DataAccessLayer.DataClasses;

    ///<summary>
    /// Author Scott Karney
    /// Company: Onshore Outsourcing
    /// Description: 
    /// </summary>

    public class DataAccess
    {
        public static string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        //private static string conn = @"Data Source=DESKTOP-H52G7QL\SQLEXPRESS;Initial Catalog =Cardfight Vanguard; Integrated Security = True";
        //SP_Get_Users_All
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<UserDO> getUserall(int UserID)
        {
            List<UserDO> _listofUsers = new List<UserDO>();
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {

                    using (SqlCommand command = new SqlCommand("SP_GET_User", connection))
                    {

                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@parmUserID", UserID);
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                UserDO user = new UserDO();
                                user.UserID = (int)reader["UserID"];
                                user.FirstName = (string)reader["First Name"];
                                user.LastName = (string)reader["Last Name"];
                                user.Username = (string)reader["Username"];
                                user.Password = (string)reader["Password"];
                                






                                _listofUsers.Add(user);
                            }
                        }
                    }

                }
            }
            catch (Exception error)
            {

                throw error;
            }


            return _listofUsers;

        }

        public void LogError(Exception error)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        public void DeleteUser(int UserID)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {

                    using (SqlCommand command = new SqlCommand("SP_Delete_FROM_User", connection))
                    {


                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@parmUserID", UserID);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception error)
            {

                throw error;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool InsertUser(UserDO user)
        {
            bool _IsSucceeded = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {

                    using (SqlCommand command = new SqlCommand("SP_Insert_User", connection))
                    {


                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@parmUserID", user.UserID);
                        command.Parameters.AddWithValue("@parmFirstName", user.FirstName);
                        command.Parameters.AddWithValue("@parmLastName", user.LastName);
                        command.Parameters.AddWithValue("@parmUsername", user.Username);
                        command.Parameters.AddWithValue("@parmPassword", user.Password);
                        
                        connection.Open();
                        command.ExecuteNonQuery();
                        _IsSucceeded = true;

                    }
                }
            }
            catch (Exception error)
            {
                _IsSucceeded = false;
                throw error;
            }
            return _IsSucceeded;
         }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UpdateUser(UserDO user)
        {
            bool _IsSucceeded = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {

                    using (SqlCommand command = new SqlCommand("SP_Update_User", connection))
                    {


                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("parmUserID", user.UserID);
                        command.Parameters.AddWithValue("parmFirstName", user.FirstName);
                        command.Parameters.AddWithValue("parmLastName", user.LastName);
                        command.Parameters.AddWithValue("parmUsername", user.Username);
                        command.Parameters.AddWithValue("parmPassword", user.Password);
                       
                        connection.Open();
                        command.ExecuteNonQuery();
                        _IsSucceeded = true;

                    }
                }
            }
            catch (Exception error)
            {
                _IsSucceeded = false;
                throw error;
            }
            return _IsSucceeded;
        }
        public UserDO GetUserByUsername(string Username)
        {
            var user = new UserDO();
            
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cardfight Vanguard"].ConnectionString))
                {
                    using (SqlCommand viewComm = new SqlCommand("SP_GET_User", conn))
                    {
                        viewComm.CommandType = System.Data.CommandType.StoredProcedure;
                        viewComm.CommandTimeout = 15;

                        viewComm.Parameters.AddWithValue("Username", Username);

                        conn.Open();

                        using (SqlDataReader reader = viewComm.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                user.UserID = reader.GetInt32(reader.GetOrdinal("UserID"));
                                user.Username = (string)reader["Username"];
                                user.Password = (string)reader["Password"];
                                user.RoleID = (int)reader["RoleID"];
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                
            }
            return user;
        }
        
        
    }
}