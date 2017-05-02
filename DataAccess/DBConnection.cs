// ***********************************************************************
// Assembly         : DataAccess
// Author           : PDUBEY
// Created          : 11-05-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-06-2015
// ***********************************************************************
// <copyright file="DBConnection.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Class DBConnection.
    /// </summary>
   internal class DBConnection  // this is the only place to get a sqlconnection
    {
        // here's the connection string most people would need at home
        // const string ConnectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=EventManagement_Final_Last;Integrated Security=True";
        /// <summary>
        /// The connection string
        /// </summary>
       const string ConnectionString = @"Data Source=localhost;Initial Catalog=EventManagementWebApp_Last;Integrated Security=True";

        /// <summary>
        /// Gets the database connection.
        /// </summary>
        /// <returns>SqlConnection.</returns>
        public static SqlConnection GetDBConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}

