// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : PDUBEY
// Created          : 11-15-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 12-10-2015
// ***********************************************************************
// <copyright file="EventBookingManager.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Class EventBookingManager.
    /// </summary>
    public class EventBookingManager
    {


        /// <summary>
        /// Gets the event booking list.
        /// </summary>
        /// <returns>List;EventBookings;.</returns>
        /// <exception cref="System.ApplicationException">There were no event bookings found.</exception>
        public List<EventBookings> GetEventBookingList()
        {
            try
            {


                var eventBookingList = EventBookingsAccessor.FetchEventBookingsList();

                if (eventBookingList.Count > 0)
                {
                    return eventBookingList;
                }
                else
                {
                    throw new ApplicationException("There were no event bookings found.");
                }
            }
            catch (Exception)
            {
                // *** we should sort the possible exceptions and return friendly messages for each
                throw;
            }
        }


        /// <summary>
        /// Gets the event type list.
        /// </summary>
        /// <returns>List;EventType;.</returns>
        /// <exception cref="System.ApplicationException">There were no event type found.</exception>
        public List<EventType> GetEventTypeList()
        {
            try
            {


                var eventTypeList = EventTypeAccessor.FetchEventTypeList();

                if (eventTypeList.Count > 0)
                {
                    return eventTypeList;
                }
                else
                {
                    throw new ApplicationException("There were no event type found.");
                }
            }
            catch (Exception)
            {
                // *** we should sort the possible exceptions and return friendly messages for each
                throw;
            }
        }


        /// <summary>
        /// Gets the venue list.
        /// </summary>
        /// <returns>List;Venue;.</returns>
        /// <exception cref="System.ApplicationException">There were no venue found.</exception>
        public List<Venue> GetVenueList()
        {
            try
            {

                var venueList = VenueAccessor.FetchVenueList();

                if (venueList.Count > 0)
                {
                    return venueList;
                }
                else
                {
                    throw new ApplicationException("There were no venue found.");
                }
            }
            catch (Exception)
            {
                // *** we should sort the possible exceptions and return friendly messages for each
                throw;
            }
        }


        /// <summary>
        /// Gets the caterers list.
        /// </summary>
        /// <returns>List;Caterers;.</returns>
        /// <exception cref="System.ApplicationException">There were no caterers found.</exception>
        public List<Caterers> GetCaterersList()
        {
            try
            {

                var caterersList = CaterersAccessor.FetchCaterersList();

                if (caterersList.Count > 0)
                {
                    return caterersList;
                }
                else
                {
                    throw new ApplicationException("There were no caterers found.");
                }
            }
            catch (Exception)
            {
                // *** we should sort the possible exceptions and return friendly messages for each
                throw;
            }
        }

        /// <summary>
        /// Inserts the new event booking.
        /// </summary>
        /// <param name="eventTypeID">The event type identifier.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <param name="eventDate">The event date.</param>
        /// <param name="venueID">The venue identifier.</param>
        /// <param name="customerID">The customer identifier.</param>
        /// <param name="catererID">The caterer identifier.</param>
        /// <param name="userID">The user identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool InsertNewEventBooking(int eventTypeID,
                                            TimeSpan startTime,
                                            TimeSpan endTime,
                                            DateTime eventDate,
                                            int venueID,
                                            int customerID,
                                            int catererID,
                                            int userID)

            
            

        {
            try
            {
               
                var eventBookingsO = new EventBookingsO()
                {
                    BookingID       = 0,
                    EventTypeID     = eventTypeID,
                    VenueID         = venueID,
                    CustomerID      = customerID,
                    CaterersID       = catererID,
                    UserProfileID   = userID,
                    StartTime       = startTime,
                    EndTime         = endTime,
                    EventDate       = eventDate
                };
                if (EventBookingsAccessorO.InsertEventBookings(eventBookingsO) != 0)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return false;
        }

        /// <summary>
        /// Updates the event booking.
        /// </summary>
        /// <param name="eventBooking">The event booking.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool UpdateEventBooking(EventBookingsO eventBooking)
        {
            try
            {
                //CustomerAccessor.UpdateCustomer(customer) >= 1)
                if (EventBookingsAccessorO.UpdateEventBookings(eventBooking) >= 1)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }


        }

        public EventBookingsO GetEventBookingOnBookingId(int id)
        {
            try
            {

                return EventBookingsAccessorO.FetchEventBookings(id);
               
            }
            catch (Exception)
            {
                // *** we should sort the possible exceptions and return friendly messages for each
                throw;
            }
        }


    }
}
