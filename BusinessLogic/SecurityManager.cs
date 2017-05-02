// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : PDUBEY
// Created          : 11-20-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-20-2015
// ***********************************************************************
// <copyright file="SecurityManager.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using BusinessObject;

namespace BusinessLogic
{
    /// <summary>
    /// Class SecurityManager.
    /// </summary>
    public class SecurityManager
    {
        /// <summary>
        /// The mi n_ username
        /// </summary>
        const int MIN_USERNAME = 5;
        /// <summary>
        /// The mi n_ password
        /// </summary>
        const int MIN_PASSWORD = 5;
        /// <summary>
        /// Validates the existing user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>AccessToken.</returns>
        /// <exception cref="System.ApplicationException">
        /// Invalid username or password.
        /// or
        /// Data not found.
        /// </exception>
        public static AccessToken ValidateExistingUser(string username, string password)
        {
            AccessToken accessToken;
            UserProfile userProfile;
            UserProfileManager userProfileManager = new UserProfileManager();

            if (username.Length < MIN_USERNAME || password.Length < MIN_PASSWORD)
            {
                throw new ApplicationException("Invalid username or password.");
            }

            try
            {

                if (UserProfileManager.IsValidUser(username, password))
                {
                    userProfile = userProfileManager.GetUserRoleProfileByUserNameAndPassword(username, password);

                    accessToken = new AccessToken(userProfile);
                }
                else
                {
                    throw new ApplicationException("Data not found.");
                }
            }
            catch
            {
                throw;
            }
            return accessToken;
        }

        /// <summary>
        /// Validates the new user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>AccessToken.</returns>
        /// <exception cref="System.ApplicationException">Data not found.</exception>
        public static AccessToken ValidateNewUser(string username, string newPassword)
        {
            // check for new user
            if (1 == UserProfileAccessor.FindUserByUsernameAndPassword(username, "NEWUSER"))
            {
                UserProfileAccessor.SetPasswordForUsername(username, "NEWUSER", newPassword.HashSha256());
            }
            else
            {
                throw new ApplicationException("Data not found.");
            }

            return ValidateExistingUser(username, newPassword);

        }


    }
}
