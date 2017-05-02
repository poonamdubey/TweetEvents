// ***********************************************************************
// Assembly         : DataAccess
// Author           : PDUBEY
// Created          : 11-26-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-26-2015
// ***********************************************************************
// <copyright file="VenueAccessor.cs" company="">
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
    /// Class VenueAccessor.
    /// </summary>
    public class VenueAccessor
    {
        /// <summary>
        /// Fetches the venue list.
        /// </summary>
        /// <returns>List of Venue;.</returns>
        public static List<Venue> FetchVenueList()
        {
            // create a list to hold the returned data
            var VenueList = new List<Venue>();

            // get a connection to the database
            var conn = DBConnection.GetDBConnection();

            //query to select
            string query = @"SELECT VenueID, BuildingName  " +
                           @"FROM Venue ";


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
                        Venue venue = new Venue()
                        {

                            VenueID         = reader.GetInt32(0),
                            BuildingName    = reader.GetString(1),
                            
     
                        };


                        VenueList.Add(venue);
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
            return VenueList;

        }

        /// <summary>
        /// Fetches the venue by identifier.
        /// </summary>
        /// <param name="VenueID">The venue identifier.</param>
        /// <returns>Venue.</returns>
        public static Venue FetchVenueByID(int VenueID)
        {
            Venue venue = new Venue();

            // get a connection to the database
            var conn = DBConnection.GetDBConnection();

            //query to select
            string query = @"SELECT VenueID, BuildingName  " +
                           @"FROM Venue Where VenueID = @VenueID";


            //ommand object
            var cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add(new SqlParameter("VenueID", SqlDbType.Int)).Value = VenueID;

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
                        venue = new Venue()
                        {

                            VenueID = VenueID,
                            BuildingName = reader.GetString(0),
                            

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
            return venue;

        }


    }
}
