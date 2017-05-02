// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : PDUBEY
// Created          : 11-09-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 12-13-2015
// ***********************************************************************
// <copyright file="UserProfileManager.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Class UserProfileManager.
    /// </summary>
    public class UserProfileManager
    {
        /// <summary>
        /// Gets the user profile list.
        /// </summary>
        /// <returns>List&lt;UserProfile&gt;.</returns>
        /// <exception cref="System.ApplicationException">There were no records found.</exception>
        public List<UserProfile> GetUserProfileList()
        {
            try
            {
                var userProfileList = UserProfileAccessor.FetchUserProfileList();

                if (userProfileList.Count > 0)
                {
                    return userProfileList;
                }
                else
                {
                    throw new ApplicationException("There were no records found.");
                }
            }
            catch (Exception)
            {
                // *** we should sort the possible exceptions and return friendly messages for each
                throw;
            }
        }

        /// <summary>
        /// Gets the user role profile by user name and password.
        /// </summary>
        /// <param name="UserName">Name of the user.</param>
        /// <param name="Password">The password.</param>
        /// <returns>UserProfile.</returns>
        public UserProfile GetUserRoleProfileByUserNameAndPassword(string UserName, string Password)
        {
            // create a list to hold the returned data
            var userProfileDetail = new UserProfile();

            userProfileDetail = UserProfileAccessor.FetchUserProfileDetail(UserName, Password);


            return userProfileDetail;

        }

        /// <summary>
        /// Determines whether [is valid user] [the specified user name].
        /// </summary>
        /// <param name="UserName">Name of the user.</param>
        /// <param name="Password">The password.</param>
        /// <returns><c>true</c> if [is valid user] [the specified user name]; otherwise, <c>false</c>.</returns>
        public static bool IsValidUser(string UserName, string Password)
        {
            var userProfileDetail = new UserProfile();

            userProfileDetail = UserProfileAccessor.FetchUserProfileDetail(UserName, Password);

            if (userProfileDetail != null)
                return true;
            else
                return false;

        }

        /// <summary>
        /// Gets the role list.
        /// </summary>
        /// <returns>List;Roles;.</returns>
        /// <exception cref="System.ApplicationException">There were no records found.</exception>
        public List<Roles> GetRoleList()
        {
            var userRoleList = RoleAccessor.GetRolesList();

            if (userRoleList.Count > 0)
            {
                return userRoleList;
            }
            else
            {
                throw new ApplicationException("There were no records found.");
            }
        }


        public bool DeleteUser(int userID)
        {
            return (UserProfileAccessor.DeleteUser(userID) > 0);
        }


        public bool InsertNewUser(string firstName, string lastName, string middleName, string userName, string emailID, string phone, string address, string postalcode, string city,
            string state, string roleName, bool isActive, string password)
        {
            try
            {
                try
                {
                    var userProfile = new UserProfile()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        MiddleName = middleName,
                        UserName = userName,
                        EmailAddress = emailID,
                        Phone = phone,
                        IsActive = isActive,
                        Address = address,
                        Zip = postalcode,
                        City = city,
                        State = state,
                        RoleName = roleName,
                        Password = password
                    };
                    if (UserProfileAccessor.InsertUpdateUser(userProfile, true) >= 1)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    throw;
                }

                return false;
            }
            catch (Exception)
            {

                throw new ApplicationException("No Records were inserted");
            }
        }


        public bool UpdateUser(UserProfile profile)
        {
            try
            {

                if (UserProfileAccessor.InsertUpdateUser(profile, false) >= 1)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserProfile GetUserRoleProfileByUserID(int userId)
        {
            // create a list to hold the returned data
            var userProfileDetail = new UserProfile();

            userProfileDetail = UserProfileAccessor.FindUserByUserID(userId);


            return userProfileDetail;

        }

        public UserProfile GetUserProfileByUserID(int userId)
        {
            // create a list to hold the returned data
            var userProfileDetail = new UserProfile();

            userProfileDetail = UserProfileAccessor.GetUserProfileByUserID(userId);


            return userProfileDetail;

        }

    }
}
