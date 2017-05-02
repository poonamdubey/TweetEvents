// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : PDUBEY
// Created          : 11-05-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-26-2015
// ***********************************************************************
// <copyright file="CustomerManager.cs" company="">
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
    /// Class CustomerManager.
    /// </summary>
    public class CustomerManager
    {
        /// <summary>
        /// Gets the customer list.
        /// </summary>
        /// <returns>List&lt;Customer&gt;.</returns>
        /// <exception cref="System.ApplicationException">There were no records found.</exception>
        public List<Customer> GetCustomerList()
        {
            try
            {
                var customerList = CustomerAccessor.FetchCustomerList();

                if (customerList.Count > 0)
                {
                    return customerList;
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
        /// Gets the customer by identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>Customer.</returns>
        public Customer GetCustomerById(int customerId)
        {
            return CustomerAccessor.FetchCustomerByID(customerId);
        }

        /// <summary>
        /// Inserts the new customer.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="emailID">The email identifier.</param>
        /// <param name="phoneNO1">The phone n o1.</param>
        /// <param name="phoneNO2">The phone n o2.</param>
        /// <param name="address1">The address1.</param>
        /// <param name="address2">The address2.</param>
        /// <param name="postalCode">The postal code.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool InsertNewCustomer(string firstName,
                                      string lastName,
                                      string emailID,
                                      string phoneNO1,
                                      string phoneNO2,
                                      string address1,
                                      string address2,
                                      string postalCode,
                                      string city,
                                      string state)
        {
            try
            {
                var cstmer = new Customer()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    EmailID = emailID,
                    PhoneNo1 = phoneNO1,
                    PhoneNo2 = phoneNO2,
                    Address1 = address1,
                    Address2 = address2,
                    PostalCode = postalCode,
                    City = city,
                    State = state
                };
                if (CustomerAccessor.InsertCustomer(cstmer) >= 1)
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


        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {

                if (CustomerAccessor.UpdateCustomer(customer) >= 1)
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


        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool DeleteCustomer(Customer customer)
        {
            int count = 0;
            
            count = CustomerAccessor.DeleteCustomer(customer.CustomerID);

            if (count >= 0)

                return true;
            else
                return false;

            
        }

    }
}
