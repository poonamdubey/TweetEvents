using BusinessObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagementWebApp.Models
{
    public class EventBookingViewModel
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// </summary>
        /// <value>The type of the event.</value>
        public List<EventType> EventType { get; set; }

        public int BookingID { get; set; }

        public int EventID { get; set; }

        /// <summary>
        /// Gets or sets the venue.
        /// </summary>
        /// <value>The venue.</value>
        public List<Venue> Venue { get; set; }

        /// <summary>
        /// Gets or sets VenueID
        /// </summary>
        public int VenueID { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>The customer.</value>
        public List<Customer> Customer { get; set; }

        /// <summary>
        /// Gets or sets Customer ID
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// Gets or sets the caterer.
        /// </summary>
        /// <value>The caterer.</value>
        public List<Caterers> Caterer { get; set; }

        /// <summary>
        /// Gets or sets Caterer's ID
        /// </summary>
        public int CatererID { get; set; }

        /// <summary>
        /// Gets or sets the user profile.
        /// </summary>
        /// <value>The user profile.</value>
        public List<UserProfile> UserProfile { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>The start time.</value>
        [Required]
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>The end time.</value>
        [Required]
        public TimeSpan EndTime { get; set; }

        /// <summary>
        /// Gets or sets the event date.
        /// </summary>
        /// <value>The event date.</value>
        [Required]
        public DateTime EventDate { get; set; }
    }
}