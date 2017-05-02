// ***********************************************************************
// Assembly         : BusinessObject
// Author           : PDUBEY
// Created          : 11-14-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-15-2015
// ***********************************************************************
// <copyright file="EventType.cs" company="">
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
    /// Class EventType.
    /// </summary>
    public class EventType
    {
        /// <summary>
        /// Gets or sets the event type identifier.
        /// </summary>
        /// <value>The event type identifier.</value>
        public int EventTypeID { get; set; }

        /// <summary>
        /// Gets or sets the name of the event type.
        /// </summary>
        /// <value>The name of the event type.</value>
        public string EventTypeName { get; set; }

        /// <summary>
        /// Gets or sets the event type description.
        /// </summary>
        /// <value>The event type description.</value>
        public string EventTypeDescription { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventType"/> class.
        /// </summary>
        public EventType() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventType"/> class.
        /// </summary>
        /// <param name="eventTypeID">The event type identifier.</param>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="eventTypeDescription">The event type description.</param>
        public EventType(int eventTypeID,
                        string eventType,
                        string eventTypeDescription)

        {
            EventTypeID             = eventTypeID;
            EventTypeName           = eventType;
            EventTypeDescription    = eventTypeDescription;
            

        }

    }
}
