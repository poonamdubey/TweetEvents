// ***********************************************************************
// Assembly         : DataAccess
// Author           : PDUBEY
// Created          : 11-09-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 12-13-2015
// ***********************************************************************
// <copyright file="UserProfileAccessor.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace DataAccess
{
    /// <summary>
    /// Class UserProfileAccessor.
    /// </summary>
    public class UserProfileAccessor
    {
        /// <summary>
        /// Fetches the user profile list.
        /// </summary>
        /// <returns>List of UserProfile;.</returns>
        public static List<UserProfile> FetchUserProfileList()
        {
            // create a list to hold the returned data
            var userProfileList = new List<UserProfile>();

            // get a connection to the database
            var conn = DBConnection.GetDBConnection();

            // create a query to send through the connection
            //string query = @"SELECT UserID, UserName, Password, FirstName, LastName,  " +
            //                @"EmailAddress, IsActive " +
            //               @"FROM UserProfile ";


            string query = @"SELECT UP.UserID,UP.UserName,UP.FirstName,UP.LastName, " +
                            @"UP.MiddleName,UP.EmailAddress,R.RoleName,UP.Phone,UP.Address,UP.City,UP.State,UP.Zip,UP.IsActive,R.RoleId " +
                            @"From UserProfile as UP " +
                            @"Inner Join UserRole UR on UP.UserID = UR.UserId " +
                            @"Inner Join Roles R On UR.RoleId = R.RoleID " +
                            @"Where ISNULL(UP.IsDeleted,0) = 0";


            // + @"ORDER BY lastName ";
            query += @"ORDER BY UP.UserID ";

            // create a command object
            var cmd = new SqlCommand(query, conn);

            // be safe, not sorry! use a try-catch
            try
            {
                // open connection
                conn.Open();
                // execute the command and return a data reader
                SqlDataReader reader = cmd.ExecuteReader();

                // before trying to read the reader, be sure it has data
                if (reader.HasRows)
                {
                    // now we just need a loop to process the reader
                    while (reader.Read())
                    {
                        UserProfile user = new UserProfile()
                        {
                            UserID = reader.GetInt32(0),
                            UserName = reader.GetString(1),
                            FirstName = SafeGetString(reader, 2),
                            LastName = SafeGetString(reader, 3),
                            MiddleName = SafeGetString(reader, 4),
                            EmailAddress = SafeGetString(reader, 5),
                            RoleName = reader.GetString(6),
                            Phone = SafeGetString(reader, 7),
                            Address = SafeGetString(reader, 8),
                            City = SafeGetString(reader, 9),
                            State = SafeGetString(reader, 10),
                            Zip = SafeGetString(reader, 11),
                            IsActive = reader.GetBoolean(12),
                        };


                        userProfileList.Add(user);
                    }
                }

            }
            catch (Exception)
            {
                // rethrow all Exceptions, let the logic layer sort them out
                throw;
            }
            finally
            {
                conn.Close();
            }
            // this list may be empty, if so, the logic layer will need to deal with it
            return userProfileList;

        }

        /// <summary>
        /// Fetches the user profile detail.
        /// </summary>
        /// <param name="UserName">Name of the user.</param>
        /// <param name="Password">The password.</param>
        /// <returns>UserProfile.</returns>
        public static UserProfile FetchUserProfileDetail(string UserName, string Password)
        {
            // create a list to hold the returned data
            var userProfileDetail = new UserProfile();
            userProfileDetail = null;

            //connection
            var conn = DBConnection.GetDBConnection();

            //commandText
            string cmdText = "sp_GetUserRoleDetailByUserId";

            //command object
            var cmd = new SqlCommand(cmdText, conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            //First Parameter

            var uname = new SqlParameter("UserName", SqlDbType.VarChar, 100);
            uname.Value = UserName;
            cmd.Parameters.Add(uname);

            //Second Parameter
            var pass = new SqlParameter("Password", SqlDbType.VarChar, 100);
            pass.Value = Password;
            cmd.Parameters.Add(pass);

            try
            {
                // open connection
                conn.Open();

                //execute the command and return a data reader
                SqlDataReader reader = cmd.ExecuteReader();

                //has data
                if (reader.HasRows)
                {
                    //now we just need a loop to process the reader
                    while (reader.Read())
                    {
                        userProfileDetail = new UserProfile()
                        {


                            UserName = reader.GetString(0),
                            //Password = reader.GetString(2),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),

                            MiddleName = SafeGetString(reader, 3),



                            EmailAddress = reader.GetString(4),
                            IsActive = reader.GetBoolean(5),
                            RoleName = reader.GetString(6)


                            //UserName	FirstName	LastName	MiddleName	EmailAddress	IsActive	RoleName

                        };



                    }
                }

            }
            catch (Exception)
            {
                // rethrow all Exceptions
                throw;
            }
            finally
            {
                conn.Close();
            }




            return userProfileDetail;

        }

        /// <summary>
        /// Safes the get string.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="colIndex">Index of the col.</param>
        /// <returns>System.String.</returns>
        public static string SafeGetString(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            else
                return string.Empty;
        }

        /// <summary>
        /// Find active user by Username and password
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>System.Int32.</returns>
        public static int FindUserByUsernameAndPassword(string username, string password)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();

            var query = @"sp_GetUserRoleDetailByUserId";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            try
            {
                conn.Open();
                count = (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return count;
        }



        /// <summary>
        /// Sets the password for username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>System.Int32.</returns>
        public static int SetPasswordForUsername(string username, string oldPassword, string newPassword)
        {
            int count = 0;
            var conn = DBConnection.GetDBConnection();
            var query = @"sp_update_password_for_username";
            var cmd = new SqlCommand(query, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@oldPassword", oldPassword);
            cmd.Parameters.AddWithValue("@newPassword", newPassword);

            try
            {
                conn.Open();
                count = (int)cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return count;
        }


        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <returns>System.Int32.</returns>
        public static int DeleteUser(int userID)
        {
            int rowCount = 0;

            // begin with a connection
            var conn = DBConnection.GetDBConnection();

            // get some commandText
            string cmdText = "sp_DeleteUser";

            // create a command object
            var cmd = new SqlCommand(cmdText, conn);

            // here is where things change a bit
            // first, we need to set the command type
            cmd.CommandType = CommandType.StoredProcedure;


            // we need to construct and add the parameters

            cmd.Parameters.Add(new SqlParameter("UserID", SqlDbType.Int)).Value = userID;

            // output parameter
            var o = new SqlParameter("Rowcount", SqlDbType.Int);
            o.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(o);

            try
            {
                // open the connection
                conn.Open();

                // execute  the command
                rowCount = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rowCount;
        }


        public static int InsertUpdateUser(UserProfile userObj, bool IsInsert)
        {
            try
            {
                int rowCount = 0;

                // begin with a connection
                var conn = DBConnection.GetDBConnection();

                // get some commandText
                string cmdText = "sp_InsertUpdateUser";

                // create a command object
                var cmd = new SqlCommand(cmdText, conn);

                // here is where things change a bit
                // first, we need to set the command type
                cmd.CommandType = CommandType.StoredProcedure;


                // we need to construct and add the parameters
                cmd.Parameters.Add(new SqlParameter("IsInsert", SqlDbType.Bit)).Value = IsInsert;

                cmd.Parameters.Add(new SqlParameter("UserId", SqlDbType.Int)).Value = userObj.UserID;

                cmd.Parameters.Add(new SqlParameter("FirstName", SqlDbType.VarChar, 200)).Value = userObj.FirstName;

                cmd.Parameters.Add(new SqlParameter("LastName", SqlDbType.VarChar, 200)).Value = userObj.LastName;

                cmd.Parameters.Add(new SqlParameter("MiddleName", SqlDbType.VarChar, 50)).Value = string.IsNullOrEmpty(userObj.MiddleName)? string.Empty:userObj.MiddleName;

                cmd.Parameters.Add(new SqlParameter("EmailAddress", SqlDbType.VarChar, 200)).Value = userObj.EmailAddress;

                cmd.Parameters.Add(new SqlParameter("Phone", SqlDbType.Char, 50)).Value = string.IsNullOrEmpty(userObj.Phone) ? string.Empty : userObj.Phone;

                cmd.Parameters.Add(new SqlParameter("UserName", SqlDbType.Char, 100)).Value = userObj.UserName;

                cmd.Parameters.Add(new SqlParameter("IsActive", SqlDbType.Bit)).Value = userObj.IsActive;

                cmd.Parameters.Add(new SqlParameter("Address", SqlDbType.NVarChar, 100)).Value = string.IsNullOrEmpty(userObj.Address) ? string.Empty : userObj.Address;

                cmd.Parameters.Add(new SqlParameter("Zip", SqlDbType.NVarChar, 10)).Value = string.IsNullOrEmpty(userObj.Zip) ? string.Empty : userObj.Zip; 

                cmd.Parameters.Add(new SqlParameter("City", SqlDbType.NVarChar, 20)).Value = string.IsNullOrEmpty(userObj.City) ? string.Empty : userObj.City;

                cmd.Parameters.Add(new SqlParameter("State", SqlDbType.NVarChar, 50)).Value = string.IsNullOrEmpty(userObj.State) ? string.Empty : userObj.State;

                cmd.Parameters.Add(new SqlParameter("RoleName", SqlDbType.VarChar, 50)).Value = string.IsNullOrEmpty(userObj.RoleName) ? string.Empty : userObj.RoleName;

                cmd.Parameters.Add(new SqlParameter("Password", SqlDbType.NVarChar, 50)).Value = userObj.Password == null ? string.Empty : userObj.Password;


                // output parameter
                var o = new SqlParameter("Rowcount", SqlDbType.Int);
                o.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(o);

                try
                {
                    // open the connection
                    conn.Open();

                    // execute  the command
                    rowCount = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
                return rowCount;
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        public static UserProfile FindUserByUserID(int userId)
        {
            // create a list to hold the returned data
            var userProfile = new UserProfile();
            userProfile = null;

            //connection
            var conn = DBConnection.GetDBConnection();

            //commandText
            string cmdText = "sp_GetUserRoleByUserId";

            //command object
            var cmd = new SqlCommand(cmdText, conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            var uId = new SqlParameter("UserID", SqlDbType.Int);
            uId.Value = userId;
            cmd.Parameters.Add(uId);



            try
            {
                // open connection
                conn.Open();

                //execute the command and return a data reader
                SqlDataReader reader = cmd.ExecuteReader();

                //has data
                if (reader.HasRows)
                {
                    //now we just need a loop to process the reader
                    while (reader.Read())
                    {
                        userProfile = new UserProfile()
                        {

                            UserID = reader.GetInt32(0),
                            UserName = reader.GetString(1),
                            //Password = reader.GetString(2),
                            FirstName = reader.GetString(2),
                            LastName = reader.GetString(3),

                            MiddleName = SafeGetString(reader, 4),



                            EmailAddress = reader.GetString(5),
                            IsActive = reader.GetBoolean(6),
                            RoleName = reader.GetString(7)


                            //UserName	FirstName	LastName	MiddleName	EmailAddress	IsActive	RoleName

                        };



                    }
                }

            }
            catch (Exception)
            {
                // rethrow all Exceptions
                throw;
            }
            finally
            {
                conn.Close();
            }




            return userProfile;


        }


        public static UserProfile GetUserProfileByUserID(int userId)
        {
            // create a list to hold the returned data
            var userProfile = new UserProfile();
            userProfile = null;

            //connection
            var conn = DBConnection.GetDBConnection();

            //commandText
            string cmdText = "sp_GetUserProfileDetailsByUserId";

            //command object
            var cmd = new SqlCommand(cmdText, conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            var uId = new SqlParameter("UserID", SqlDbType.Int);
            uId.Value = userId;
            cmd.Parameters.Add(uId);



            try
            {
                // open connection
                conn.Open();

                //execute the command and return a data reader
                SqlDataReader reader = cmd.ExecuteReader();

                //has data
                if (reader.HasRows)
                {
                    //now we just need a loop to process the reader
                    while (reader.Read())
                    {
                        userProfile = new UserProfile()
                        {

                            UserID = reader.GetInt32(0),
                            UserName = reader.GetString(1),
                            //Password = reader.GetString(2),
                            FirstName = reader.GetString(2),
                            LastName = reader.GetString(3),

                            MiddleName = SafeGetString(reader, 4),



                            EmailAddress = reader.GetString(5),
                            IsActive = reader.GetBoolean(6),
                            RoleName = reader.GetString(7),
                            Phone = reader.GetString(8),
                            Address = reader.GetString(9),
                            City = reader.GetString(10),
                            Zip = reader.GetString(11),
                            State = reader.GetString(12)

                            //UserName	FirstName	LastName	MiddleName	EmailAddress	IsActive	RoleName

                        };



                    }
                }

            }
            catch (Exception)
            {
                // rethrow all Exceptions
                throw;
            }
            finally
            {
                conn.Close();
            }




            return userProfile;


        }
    }
}
