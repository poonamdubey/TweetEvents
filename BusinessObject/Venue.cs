// ***********************************************************************
// Assembly         : BusinessObject
// Author           : PDUBEY
// Created          : 11-14-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-14-2015
// ***********************************************************************
// <copyright file="Venue.cs" company="">
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
    /// Class Venue.
    /// </summary>
    public class Venue
    {
        /// <summary>
        /// Gets or sets the venue identifier.
        /// </summary>
        /// <value>The venue identifier.</value>
        public int VenueID { get; set; }
        /// <summary>
        /// Gets or sets the name of the building.
        /// </summary>
        /// <value>The name of the building.</value>
        public string BuildingName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Venue"/> class.
        /// </summary>
        public Venue() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Venue"/> class.
        /// </summary>
        /// <param name="venueID">The venue identifier.</param>
        /// <param name="buildingName">Name of the building.</param>
        public Venue(

            int venueID,
            string buildingName
            )
        {
            VenueID = venueID;
            BuildingName = buildingName;

        }

    }
}
