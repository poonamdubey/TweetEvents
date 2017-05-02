// ***********************************************************************
// Assembly         : BusinessObject
// Author           : PDUBEY
// Created          : 11-14-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-14-2015
// ***********************************************************************
// <copyright file="Caterers.cs" company="">
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
    /// Class Caterers.
    /// </summary>
    public class Caterers
    {
        /// <summary>
        /// Gets or sets the caterer identifier.
        /// </summary>
        /// <value>The caterer identifier.</value>
        public int CatererID { get; set; }
        /// <summary>
        /// Gets or sets the name of the caterer.
        /// </summary>
        /// <value>The name of the caterer.</value>
        public string CatererName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Caterers"/> class.
        /// </summary>
        public Caterers() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Caterers"/> class.
        /// </summary>
        /// <param name="catererID">The caterer identifier.</param>
        /// <param name="catererName">Name of the caterer.</param>
        public Caterers(int catererID,
                        string catererName
                        )
        {   
            CatererID = catererID;
            CatererName = catererName;
            

        }

    }
}
