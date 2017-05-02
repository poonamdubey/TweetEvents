// ***********************************************************************
// Assembly         : BusinessObject
// Author           : PDUBEY
// Created          : 11-14-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-18-2015
// ***********************************************************************
// <copyright file="EventBookingsO.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    /// <summary>
    /// Class EventBookingsO.
    /// </summary>
    public class EventBookingsO
    {
        /// <summary>
        /// Gets or sets the booking identifier.
        /// </summary>
        /// <value>The booking identifier.</value>
        public int BookingID { get; set; }

        /// <summary>
        /// Gets or sets the event type identifier.
        /// </summary>
        /// <value>The event type identifier.</value>
        public int EventTypeID { get; set; }

        /// <summary>
        /// Gets or sets the venue identifier.
        /// </summary>
        /// <value>The venue identifier.</value>
        public int VenueID { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        public int CustomerID { get; set; }

        /// <summary>
        /// Gets or sets the caterers identifier.
        /// </summary>
        /// <value>The caterers identifier.</value>
        public int CaterersID { get; set; }

        /// <summary>
        /// Gets or sets the user profile identifier.
        /// </summary>
        /// <value>The user profile identifier.</value>
        public int UserProfileID { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>The start time.</value>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>The end time.</value>
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// Gets or sets the event date.
        /// </summary>
        /// <value>The event date.</value>
        public DateTime EventDate { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="EventBookingsO"/> class.
        /// </summary>
        public EventBookingsO() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventBookingsO"/> class.
        /// </summary>
        /// <param name="bookingID">The booking identifier.</param>
        /// <param name="eventTypeID">The event type identifier.</param>
        /// <param name="venueID">The venue identifier.</param>
        /// <param name="customerID">The customer identifier.</param>
        /// <param name="catererID">The caterer identifier.</param>
        /// <param name="userID">The user identifier.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <param name="eventDate">The event date.</param>
        public EventBookingsO(
            int bookingID,
            int eventTypeID,
            int venueID,
            int customerID,
            int catererID,
            int userID,
            TimeSpan startTime,
            TimeSpan endTime,
            DateTime eventDate )

        {   

            BookingID       = bookingID;
            EventTypeID     = eventTypeID;
            VenueID         = venueID;
            CustomerID      = customerID;
            CaterersID       = catererID;
            UserProfileID   = userID;
            StartTime       = startTime;
            EndTime         = endTime;
            EventDate       = eventDate;

            

        }

    }
}
