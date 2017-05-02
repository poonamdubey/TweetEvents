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
    public class RoleAccessor
    {
        /// <summary>
        /// Gets the roles list.
        /// </summary>
        /// <returns>List of Roles;.</returns>
        public static List<Roles> GetRolesList()
        {
            var roleList = new List<Roles>();
            //connection
            var conn = DBConnection.GetDBConnection();

            //commandText
            string cmdText = "sp_GetRoles";

            //command object
            var cmd = new SqlCommand(cmdText, conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

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
                        Roles roleObj = new Roles()
                        {
                            RoleID = reader.GetInt32(0),
                            RoleName = SafeGetString(reader, 1),
                            RoleDescription = SafeGetString(reader, 2),
                        };

                        roleList.Add(roleObj);
                    }
                }
                return roleList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
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
    }
}
