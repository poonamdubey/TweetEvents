// ***********************************************************************
// Assembly         : DataAccess
// Author           : PDUBEY
// Created          : 11-14-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-18-2015
// ***********************************************************************
// <copyright file="EventBookingsAccessor.cs" company="">
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
    /// Class EventBookingsAccessor.
    /// </summary>
    public class EventBookingsAccessor
    {

        /// <summary>
        /// Fetches the event bookings list.
        /// </summary>
        /// <returns>List of EventBookings;.</returns>
        public static List<EventBookings> FetchEventBookingsList()
        {
            // create a list to hold the returned data
            var eventBookingsList = new List<EventBookings>();

            // get a connection to the database
            var conn = DBConnection.GetDBConnection();

            // create a query to send through the connection
            string query = "sp_EventBookingsGetAllDetails";

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
                        
                          EventType eventType = new EventType()
                          {
                             EventTypeID  = reader.GetInt32(4),
                             EventTypeName = reader.GetString(5),
                             EventTypeDescription = reader.GetString(6)
                          };
                        
                          Venue venue = new Venue()
                          {
                            VenueID = reader.GetInt32(7),
                            BuildingName = reader.GetString(8)
                          };

                          Customer customer = new Customer()
                          {
                              CustomerID = reader.GetInt32(9),
                              FirstName = reader.GetString(10),
                              LastName  = reader.GetString(11)
                          };

                          Caterers caterer = new Caterers()
                          {
                              CatererID = reader.GetInt32(12),
                              CatererName = reader.GetString(13)

                          };

                          UserProfile user = new UserProfile()
                          {
                              UserID = reader.GetInt32(14),
                              UserName = reader.GetString(15),

                          };

                        EventBookings eventBooking = new EventBookings()
                        {
                            BookingID   = (Int32)reader["BookingID"],      //reader.GetInt32(0),
                             StartTime  = (TimeSpan)reader["StartTime"],    //reader.GetTimeSpan(1)
                             EndTime    = (TimeSpan)reader["EndTime"],  //reader.GetTimeSpan(2),
                            EventDate   = (DateTime)reader["EventDate"],      //reader.GetDateTime(3),
                             
                             EventType  = eventType,
                             Venue      = venue,
                             Customer   = customer,
                             Caterer    = caterer,
                             UserProfile = user,
                             
                        };
        

                            //BookingID,StartTime,EndTime,EventDate,
                            //EventTypeID,EventType,EventTypeDescription,
                            //VenueID,BuildingName,
                            //CustomerID,FirstName,LastName,
                            //CatererID,CatererName,
                            //UserID,UserName
                        
                        eventBookingsList.Add(eventBooking);
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
            return eventBookingsList;
        
        }






    }
}
