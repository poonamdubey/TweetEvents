// ***********************************************************************
// Assembly         : DataAccess
// Author           : PDUBEY
// Created          : 11-26-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-26-2015
// ***********************************************************************
// <copyright file="CaterersAccessor.cs" company="">
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
    /// Class CaterersAccessor.
    /// </summary>
    public class CaterersAccessor
    {
        /// <summary>
        /// Fetches the caterers list.
        /// </summary>
        /// <returns>List;Caterers;.</returns>
        public static List<Caterers> FetchCaterersList()
        {
            // create a list to hold the returned data
            var caterersList = new List<Caterers>();

            // get a connection to the database
            var conn = DBConnection.GetDBConnection();

            //query to select
            string query = @"SELECT CatererID, CatererName  " +
                           @"FROM Caterers ";


            //ommand object
            var cmd = new SqlCommand(query, conn);

            // try-catch
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
                        Caterers caterers = new Caterers()
                        {

                            CatererID = reader.GetInt32(0),
                            CatererName = reader.GetString(1)
                           
     
                        };


                        caterersList.Add(caterers);
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
            return caterersList;

        }

        /// <summary>
        /// Fetches the caterers by identifier.
        /// </summary>
        /// <param name="caterersID">The caterers identifier.</param>
        /// <returns>Caterers.</returns>
        public static Caterers FetchCaterersByID(int caterersID)
        {
            Caterers caterers = new Caterers();

            // get a connection to the database
            var conn = DBConnection.GetDBConnection();

            //query to select
            string query = @"SELECT CatererID, CatererName  " +
                           @"FROM Caterers Where CatererID = @CatererID";


            //ommand object
            var cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add(new SqlParameter("CatererID", SqlDbType.Int)).Value = caterersID;

            // try-catch
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
                        caterers = new Caterers()
                        {

                            CatererID = caterersID,
                            CatererName = reader.GetString(0)


                        };

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
            return caterers;

        }


    }
}
