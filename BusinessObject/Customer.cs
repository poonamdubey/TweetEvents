// ***********************************************************************
// Assembly         : BusinessObject
// Author           : PDUBEY
// Created          : 11-05-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-26-2015
// ***********************************************************************
// <copyright file="Customer.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    /// <summary>
    /// Class Customer.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        public int CustomerID { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is Required.")]
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is Required.")]
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the email identifier.
        /// </summary>
        /// <value>The email identifier.</value>
        [DisplayName("Email Address")]
        [Required(ErrorMessage = "Email Address is Required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailID { get; set; }
        /// <summary>
        /// Gets or sets the phone no1.
        /// </summary>
        /// <value>The phone no1.</value>
        [DisplayName("Phone Number 1")]
        [Required(ErrorMessage = "Phone Number is Required.")]
        public string PhoneNo1 { get; set; }
        /// <summary>
        /// Gets or sets the phone no2.
        /// </summary>
        /// <value>The phone no2.</value>
        [DisplayName("Phone Number 2")]
        public string PhoneNo2 { get; set; }
        /// <summary>
        /// Gets or sets the address1.
        /// </summary>
        /// <value>The address1.</value>
        [DisplayName("Address 1")]
        [Required(ErrorMessage = "Address is Required.")]
        public string Address1 { get; set; }
        /// <summary>
        /// Gets or sets the address2.
        /// </summary>
        /// <value>The address2.</value>
        [DisplayName("Address 2")]
        public string Address2 { get; set; }
        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>The postal code.</value>
        [DisplayName("Postal Code")]
        [Required(ErrorMessage = "Postal Code is Required.")]
        public string PostalCode { get; set; }
        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        [Required(ErrorMessage = "City is Required.")]
        public string City { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [Required(ErrorMessage = "State is Required.")]
        public string State { get; set; }



        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="emailID">The email identifier.</param>
        /// <param name="phoneNo1">The phone no1.</param>
        /// <param name="phoneNo2">The phone no2.</param>
        /// <param name="address1">The address1.</param>
        /// <param name="address2">The address2.</param>
        /// <param name="postalCode">The postal code.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        public Customer(int customerId,
                        string firstName,
                        string lastName,
                        string emailID,
                        string phoneNo1,
                        string phoneNo2,
                        string address1,
                        string address2,
                        string postalCode,
                        string city,
                        string state)
        {   
            CustomerID = customerId;
            FirstName = firstName;
            LastName = lastName;
            EmailID = emailID;
            PhoneNo1 = phoneNo1;
            PhoneNo2 = phoneNo2;
            Address1 = address1;
            Address2 = address2;
            PostalCode = postalCode;
            City = city;
            State = state;
            

        }

    }
}
