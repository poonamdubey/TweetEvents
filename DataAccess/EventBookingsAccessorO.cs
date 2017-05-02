// ***********************************************************************
// Assembly         : DataAccess
// Author           : PDUBEY
// Created          : 11-14-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 12-10-2015
// ***********************************************************************
// <copyright file="EventBookingsAccessorO.cs" company="">
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
    /// Class EventBookingsAccessorO.
    /// </summary>
    public class EventBookingsAccessorO
    {
        /// <summary>
        /// Fetches the event bookings o list.
        /// </summary>
        /// <returns>List of EventBookingsO;.</returns>
        public static List<EventBookingsO> FetchEventBookingsOList()
        {
            // create a list to hold the returned data
            var eventBookingsOList = new List<EventBookingsO>();

            // get a connection to the database
            var conn = DBConnection.GetDBConnection();

            // create a query to send through the connection
            string query = "sp_EventBookingsGetAll";

            // create a command object - SP
            var cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;

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
                        

                        EventBookingsO eventBookingO = new EventBookingsO()
                        {
                            BookingID       = reader.GetInt32(0),
                            EventTypeID     = reader.GetInt32(1),
                            
                            StartTime = (TimeSpan)reader["StartTime"],    //reader.GetTimeSpan(2)
                            EndTime = (TimeSpan)reader["EndTime"],  //reader.GetTimeSpan(3),

                            EventDate       = reader.GetDateTime(4),
                            VenueID         = reader.GetInt32(5),
                            CustomerID      = reader.GetInt32(6),
                            CaterersID      = reader.GetInt32(7),
                            UserProfileID   = reader.GetInt32(8),
                            

                            //BookingID, EventTypeID, StartTime, EndTime, EventDate, VenueID, CustomerID, CatererID, UserID
                        };

                        eventBookingsOList.Add(eventBookingO);

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
            return eventBookingsOList;
        
        }


        /// <summary>
        /// Inserts the event bookings.
        /// </summary>
        /// <param name="eventBooking">The event booking.</param>
        /// <returns>System.Int32.</returns>
        public static int InsertEventBookings(EventBookingsO eventBooking)
        {
            int rowCount = 0;

            // begin with a connection
            var conn = DBConnection.GetDBConnection();

            // get some commandText
            string cmdText = "sp_EventBookingsInsert";

            // create a command object
            var cmd = new SqlCommand(cmdText, conn);

            // here is where things change a bit
            // first, we need to set the command type
            cmd.CommandType = CommandType.StoredProcedure;


            // we need to construct and add the parameters

            cmd.Parameters.Add(new SqlParameter("EventTypeID", SqlDbType.Int)).Value = eventBooking.EventTypeID;

            cmd.Parameters.Add(new SqlParameter("StartTime", SqlDbType.Time, 7)).Value = eventBooking.StartTime;

            cmd.Parameters.Add(new SqlParameter("EndTime", SqlDbType.Time, 7)).Value = eventBooking.EndTime;

            cmd.Parameters.Add(new SqlParameter("EventDate", SqlDbType.Date)).Value = eventBooking.EventDate;

            cmd.Parameters.Add(new SqlParameter("VenueID", SqlDbType.Int)).Value = eventBooking.VenueID;

            cmd.Parameters.Add(new SqlParameter("CustomerID", SqlDbType.Int)).Value = eventBooking.CustomerID;

            cmd.Parameters.Add(new SqlParameter("CatererID", SqlDbType.Int)).Value = eventBooking.CaterersID;

            cmd.Parameters.Add(new SqlParameter("UserID", SqlDbType.Int)).Value = eventBooking.UserProfileID;



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


        /// <summary>
        /// Updates the event bookings.
        /// </summary>
        /// <param name="eventBooking">The event booking.</param>
        /// <returns>System.Int32.</returns>
        public static int UpdateEventBookings(EventBookingsO eventBooking)
        {
            int rowCount = 0;

            // begin with a connection
            var conn = DBConnection.GetDBConnection();

            // get some commandText
            string cmdText = "sp_EventBookingsUpdate";

            // create a command object
            var cmd = new SqlCommand(cmdText, conn);

            // here is where things change a bit
            // first, we need to set the command type
            cmd.CommandType = CommandType.StoredProcedure;


            // we need to construct and add the parameters
            cmd.Parameters.Add(new SqlParameter("BookingID", SqlDbType.Int)).Value = eventBooking.BookingID;

            cmd.Parameters.Add(new SqlParameter("EventTypeID", SqlDbType.Int)).Value = eventBooking.EventTypeID;

            cmd.Parameters.Add(new SqlParameter("StartTime", SqlDbType.Time, 7)).Value = eventBooking.StartTime;

            cmd.Parameters.Add(new SqlParameter("EndTime", SqlDbType.Time, 7)).Value = eventBooking.EndTime;

            cmd.Parameters.Add(new SqlParameter("EventDate", SqlDbType.Date)).Value = eventBooking.EventDate;

            cmd.Parameters.Add(new SqlParameter("VenueID", SqlDbType.Int)).Value = eventBooking.VenueID;

            cmd.Parameters.Add(new SqlParameter("CustomerID", SqlDbType.Int)).Value = eventBooking.CustomerID;

            cmd.Parameters.Add(new SqlParameter("CatererID", SqlDbType.Int)).Value = eventBooking.CaterersID;

            cmd.Parameters.Add(new SqlParameter("UserID", SqlDbType.Int)).Value = eventBooking.UserProfileID;



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


        /// <summary>
        /// Fetch the event bookings.
        /// </summary>
        /// <param name="eventBooking">The event booking.</param>
        /// <returns>System.Int32.</returns>
        public static EventBookingsO FetchEventBookings(int bookingId)
        {
            EventBookingsO eventBookO = new EventBookingsO();
         

            // begin with a connection
            var conn = DBConnection.GetDBConnection();

            // get some commandText
            string cmdText = "sp_GetBookingDetails";

            // create a command object
            var cmd = new SqlCommand(cmdText, conn);

            // here is where things change a bit
            // first, we need to set the command type
            cmd.CommandType = CommandType.StoredProcedure;


            // we need to construct and add the parameters
            cmd.Parameters.Add(new SqlParameter("BookingID", SqlDbType.Int)).Value = bookingId;


            
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
                       
                            eventBookO.BookingID       = reader.GetInt32(0);
                            eventBookO.EventTypeID     = reader.GetInt32(1);
                            
                            eventBookO.StartTime = (TimeSpan)reader["StartTime"];   //reader.GetTimeSpan(2)
                            eventBookO.EndTime = (TimeSpan)reader["EndTime"];  //reader.GetTimeSpan(3),

                            eventBookO.EventDate = reader.GetDateTime(4);
                            eventBookO.VenueID         = reader.GetInt32(5);
                            eventBookO.CustomerID      = reader.GetInt32(6);
                            eventBookO.CaterersID      = reader.GetInt32(7);
                            
                           
                        

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
            return eventBookO;
        }




    }
}
