// ***********************************************************************
// Assembly         : BusinessObject
// Author           : PDUBEY
// Created          : 11-20-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-20-2015
// ***********************************************************************
// <copyright file="Roles.cs" company="">
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
    /// Class Roles.
    /// </summary>
    public class Roles
    {
        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>The role identifier.</value>
        public int RoleID { get; set; }
        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <value>The name of the role.</value>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the role description.
        /// </summary>
        /// <value>The role description.</value>
        public string RoleDescription{get; set;}

        /// <summary>
        /// Initializes a new instance of the <see cref="Roles"/> class.
        /// </summary>
        public Roles() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Roles"/> class.
        /// </summary>
        /// <param name="roleID">The role identifier.</param>
        /// <param name="roleName">Name of the role.</param>
        /// <param name="roleDescription">The role description.</param>
        public Roles(int roleID,
                     string roleName,
                    string roleDescription)
        {   
            RoleID = roleID;
            RoleName = roleName;
            RoleDescription = roleDescription;

        }
    }
}
