// ***********************************************************************
// Assembly         : BusinessObject
// Author           : PDUBEY
// Created          : 11-20-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-20-2015
// ***********************************************************************
// <copyright file="AccessToken.cs" company="">
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
    /// Class AccessToken. This class cannot be inherited.
    /// </summary>
    public sealed class AccessToken : UserProfile
    {

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        public string Role { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessToken"/> class.
        /// </summary>
        public AccessToken() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AccessToken"/> class.
        /// </summary>
        /// <param name="up">Up.</param>
        /// <exception cref="System.ApplicationException">Invalid User</exception>
        public AccessToken(UserProfile up)
        {
            if (up == null || !up.IsActive)
            {
                throw new ApplicationException("Invalid User");
            }
            
            base.UserID = up.UserID;
            base.UserName = up.UserName;

            base.FirstName = up.FirstName;
            base.LastName = up.LastName;
            base.MiddleName = up.MiddleName;
            
            base.EmailAddress = up.EmailAddress;
            
            base.IsActive = up.IsActive;

            base.RoleName = up.RoleName;
            
            Role = up.RoleName;

        }

    }
}
