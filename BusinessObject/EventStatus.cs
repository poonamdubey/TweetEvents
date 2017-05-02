// ***********************************************************************
// Assembly         : BusinessObject
// Author           : PDUBEY
// Created          : 11-14-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-15-2015
// ***********************************************************************
// <copyright file="EventStatus.cs" company="">
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
    /// Class EventStatus.
    /// </summary>
    public class EventStatus
    {
        /// <summary>
        /// Gets or sets the event status identifier.
        /// </summary>
        /// <value>The event status identifier.</value>
        public int EventStatusID { get; set; }

        /// <summary>
        /// Gets or sets the name of the event status.
        /// </summary>
        /// <value>The name of the event status.</value>
        public string EventStatusName { get; set; }

        /// <summary>
        /// Gets or sets the event status description.
        /// </summary>
        /// <value>The event status description.</value>
        public string EventStatusDescription { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventStatus"/> class.
        /// </summary>
        public EventStatus() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventStatus"/> class.
        /// </summary>
        /// <param name="eventStatusID">The event status identifier.</param>
        /// <param name="eventStatus">The event status.</param>
        /// <param name="eventStatusDescription">The event status description.</param>
        public EventStatus(int eventStatusID,
                        string eventStatus,
                        string eventStatusDescription)

        {
            EventStatusID             = eventStatusID;
            EventStatusName           = eventStatus;
            EventStatusDescription    = eventStatusDescription;
            

        }

    }
}
