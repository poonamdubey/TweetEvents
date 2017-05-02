// ***********************************************************************
// Assembly         : BusinessObject
// Author           : PDUBEY
// Created          : 11-06-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 12-12-2015
// ***********************************************************************
// <copyright file="UserProfile.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    /// <summary>
    /// Class UserProfile.
    /// </summary>
    public class UserProfile
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        [Key]
        public int UserID { get; set; }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        [DisplayName("Username")]
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>The name of the middle.</value>
        public string MiddleName { get; set; }
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>The email address.</value>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value><c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        /// <value>The name of the role.</value>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public string State { get; set; }
        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        /// <value>The zip.</value>
        public string Zip { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfile"/> class.
        /// </summary>
        public UserProfile() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProfile"/> class.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="middleName">Name of the middle.</param>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="isActive">if set to <c>true</c> [is active].</param>
        /// <param name="roleName">Name of the role.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="address">The address.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zip">The zip.</param>
        public UserProfile(int userID,
                           string userName,
                           string password,
                           string firstName,
                           string lastName,
                           string middleName,
                           string emailAddress,
                           bool isActive,
                           string roleName,
                           string phone,
                           string address,
                           string city,
                           string state,
                           string zip)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            EmailAddress = emailAddress;
            IsActive = isActive;
            RoleName = roleName;
            Phone = phone;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
        }
    }

}
