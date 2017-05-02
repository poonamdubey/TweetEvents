// ***********************************************************************
// Assembly         : BusinessObject
// Author           : PDUBEY
// Created          : 11-14-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-14-2015
// ***********************************************************************
// <copyright file="Payment.cs" company="">
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
    /// Class Payment.
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Gets or sets the payment identifier.
        /// </summary>
        /// <value>The payment identifier.</value>
        public int PaymentID { get; set; }

        /// <summary>
        /// Gets or sets the event status identifier.
        /// </summary>
        /// <value>The event status identifier.</value>
        public int EventStatusID { get; set; }

        /// <summary>
        /// Gets or sets the booking identifier.
        /// </summary>
        /// <value>The booking identifier.</value>
        public int BookingID { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the total amount.
        /// </summary>
        /// <value>The total amount.</value>
        public double TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the paid amount.
        /// </summary>
        /// <value>The paid amount.</value>
        public double PaidAmount { get; set; }

        /// <summary>
        /// Gets or sets the due amount.
        /// </summary>
        /// <value>The due amount.</value>
        public double DueAmount { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Payment"/> class.
        /// </summary>
        public Payment() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Payment"/> class.
        /// </summary>
        /// <param name="paymentID">The payment identifier.</param>
        /// <param name="eventStatusID">The event status identifier.</param>
        /// <param name="bookingID">The booking identifier.</param>
        /// <param name="userID">The user identifier.</param>
        /// <param name="totalAmount">The total amount.</param>
        /// <param name="paidAmount">The paid amount.</param>
        /// <param name="dueAmount">The due amount.</param>
        public Payment(

            int paymentID,
            int eventStatusID,
            int bookingID,
            int userID,
            double totalAmount,
            double paidAmount,
            double dueAmount
            )
        {
            PaymentID       = paymentID;
            EventStatusID   = eventStatusID;
            BookingID       = bookingID;
            UserID          = userID;
            TotalAmount     = totalAmount;
            PaidAmount      = paidAmount;
            DueAmount       = dueAmount;


        }

    }
}
