// ***********************************************************************
// Assembly         : BusinessObject
// Author           : PDUBEY
// Created          : 11-14-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-18-2015
// ***********************************************************************
// <copyright file="EventBookings.cs" company="">
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
    /// Class EventBookings.
    /// </summary>
    public class EventBookings
    {
        /// <summary>
        /// Gets or sets the booking identifier.
        /// </summary>
        /// <value>The booking identifier.</value>
        public int BookingID { get; set; }

        /// <summary>
        /// Gets or sets the type of the event.
        /// </summary>
        /// <value>The type of the event.</value>
        public EventType EventType { get; set; }

        /// <summary>
        /// Gets or sets the venue.
        /// </summary>
        /// <value>The venue.</value>
        public Venue Venue { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>The customer.</value>
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the caterer.
        /// </summary>
        /// <value>The caterer.</value>
        public Caterers Caterer { get; set; }

        /// <summary>
        /// Gets or sets the user profile.
        /// </summary>
        /// <value>The user profile.</value>
        public UserProfile UserProfile { get; set; }

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
        /// Initializes a new instance of the <see cref="EventBookings"/> class.
        /// </summary>
        public EventBookings() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventBookings"/> class.
        /// </summary>
        /// <param name="bookingID">The booking identifier.</param>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="venue">The venue.</param>
        /// <param name="customer">The customer.</param>
        /// <param name="caterer">The caterer.</param>
        /// <param name="user">The user.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <param name="eventDate">The event date.</param>
        public EventBookings(
            int bookingID,
            EventType eventType,
            Venue venue,
            Customer customer,
            Caterers caterer,
            UserProfile user,
            TimeSpan startTime,
            TimeSpan endTime,
            DateTime eventDate )

        {   

            BookingID   = bookingID;
            EventType   = eventType;
            Venue       = venue;
            Customer    = customer;
            Caterer     = caterer;
            UserProfile = user;
            StartTime   = startTime;
            EndTime     = endTime;
            EventDate   = eventDate;

            

        }

    }
}
