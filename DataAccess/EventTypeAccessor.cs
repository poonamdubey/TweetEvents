// ***********************************************************************
// Assembly         : DataAccess
// Author           : PDUBEY
// Created          : 11-14-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-15-2015
// ***********************************************************************
// <copyright file="EventTypeAccessor.cs" company="">
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
    /// Class EventTypeAccessor.
    /// </summary>
    public class EventTypeAccessor
    {
        /// <summary>
        /// Fetches the event type list.
        /// </summary>
        /// <returns>List of EventType;.</returns>
        public static List<EventType> FetchEventTypeList()
        {
            // create a list to hold the returned data
            var eventTypeList = new List<EventType>();

            // get a connection to the database
            var conn = DBConnection.GetDBConnection();

            //query to select
            string query = @"SELECT EventTypeID, EventType, EventTypeDescription  " +
                           @"FROM EventType ";


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
                        EventType eventType = new EventType()
                        {

                            EventTypeID          = reader.GetInt32(0),
                            EventTypeName            = reader.GetString(1),
                            EventTypeDescription = reader.GetString(2),
     
                        };


                        eventTypeList.Add(eventType);
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
            return eventTypeList;

        }

        /// <summary>
        /// Fetches the event type identifier.
        /// </summary>
        /// <param name="eventTypeID">The event type identifier.</param>
        /// <returns>EventType.</returns>
        public static EventType FetchEventTypeID(int eventTypeID)
        {
            EventType eventType = new EventType();

            // get a connection to the database
            var conn = DBConnection.GetDBConnection();

            //query to select
            string query = @"SELECT EventType, EventTypeDescription  " +
                           @"FROM EventType Where EventTypeID = @EventTypeID";


            //ommand object
            var cmd = new SqlCommand(query, conn);

            cmd.Parameters.Add(new SqlParameter("EventTypeID", SqlDbType.Int)).Value = eventTypeID;

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
                        eventType = new EventType()
                        {

                            EventTypeID = eventTypeID,
                            EventTypeName = reader.GetString(0),
                            EventTypeDescription = reader.GetString(1)

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
            return eventType;

        }


    }
}
