// ***********************************************************************
// Assembly         : DataAccess
// Author           : PDUBEY
// Created          : 11-06-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-26-2015
// ***********************************************************************
// <copyright file="CustomerAccessor.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Class CustomerAccessor.
    /// </summary>
    public class CustomerAccessor
    {
        /// <summary>
        /// Fetches the customer list.
        /// </summary>
        /// <returns>List of Customer;.</returns>
        public static List<Customer> FetchCustomerList()
        {
            // create a list to hold the returned data
            var customerList = new List<Customer>();

            // get a connection to the database
            var conn = DBConnection.GetDBConnection();

            // create a query to send through the connection
            string query = "sp_CustomersGetAll";

            // create a command object - SP
            var cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // try-catch
            try
            {
                // open connection
                conn.Open();
                // execute the command and return a data reader
                SqlDataReader reader = cmd.ExecuteReader();

                // before trying to read the reader, be sure it has data
                if (reader.HasRows)
                {
                    // now we just need a loop to process the reader
                    while (reader.Read())
                    {
                        Customer customer = new Customer()
                        {
                            CustomerID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            EmailID = reader.GetString(3),
                            PhoneNo1 = reader.GetString(4),
                            Address1 = reader.GetString(5),
                            PostalCode = reader.GetString(6),
                            City = reader.GetString(7),
                            State = reader.GetString(8)
                        };


                        customerList.Add(customer);
                    }
                }
                
            }
            catch (Exception)
            {
                // rethrow all Exceptions, let the logic layer sort them out
                throw;
            }
            finally
            {
                conn.Close();
            }
            // this list may be empty, if so, the logic layer will need to deal with it
            return customerList;
        
        }



        /// <summary>
        /// Fetches the customer by identifier.
        /// </summary>
        /// <param name="customerID">The customer identifier.</param>
        /// <returns>Customer.</returns>
        public static Customer FetchCustomerByID(int customerID)
        {
            // create a list to hold the returned data
            var customer = new Customer();


            //connection
            var conn = DBConnection.GetDBConnection();

            //commandText
            string cmdText = "sp_CustomerGetByCustomerID";

            //command object
            var cmd = new SqlCommand(cmdText, conn);

            //command type
            cmd.CommandType = CommandType.StoredProcedure;

            //First Parameter

            var custID = new SqlParameter("CustomerId", SqlDbType.VarChar, 100);
            custID.Value = customerID;
            cmd.Parameters.Add(custID);

           

            try
            {
                // open connection
                conn.Open();

                //execute the command and return a data reader
                SqlDataReader reader = cmd.ExecuteReader();

                //has data
                if (reader.HasRows)
                {
                    //now we just need a loop to process the reader
                    while (reader.Read())
                    {
                        customer = new Customer()
                        {


                            CustomerID  = reader.GetInt32(0),
                            FirstName   = reader.GetString(1),
                            LastName    = reader.GetString(2),
                            EmailID     = reader.GetString(3),
                            PhoneNo1    = reader.GetString(4),
                            Address1    = reader.GetString(5),
                            PostalCode  = reader.GetString(6),
                            City        = reader.GetString(7),
                            State       = reader.GetString(8)

                            //CustomerID, FirstName, LastName, EmailId, PhoneNo1, Address1, PostalCode, City, State
                        };
                    }
                }
            }
            catch (Exception)
            {
                // rethrow all Exceptions
                throw;
            }
            finally
            {
                conn.Close();
            }

            return customer;

        }


        /// <summary>
        /// Inserts the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>System.Int32.</returns>
        public static int InsertCustomer(Customer customer)
        {
            int rowCount = 0;

            // begin with a connection
            var conn = DBConnection.GetDBConnection();

            // get some commandText
            string cmdText = "sp_CustomersInsert";

            // create a command object
            var cmd = new SqlCommand(cmdText, conn);

            // here is where things change a bit
            // first, we need to set the command type
            cmd.CommandType = CommandType.StoredProcedure;

            
            // we need to construct and add the parameters

            cmd.Parameters.Add(new SqlParameter("FirstName", SqlDbType.VarChar,50)).Value = customer.FirstName;

            cmd.Parameters.Add(new SqlParameter("LastName", SqlDbType.VarChar,50)).Value = customer.LastName;

			cmd.Parameters.Add(new SqlParameter("EmailID", SqlDbType.VarChar,50)).Value = customer.EmailID;

			cmd.Parameters.Add(new SqlParameter("PhoneNo1", SqlDbType.Char,10)).Value = customer.PhoneNo1;

			cmd.Parameters.Add(new SqlParameter("PhoneNo2", SqlDbType.Char,10)).Value = customer.PhoneNo2 == null ? "" : customer.PhoneNo2;

			cmd.Parameters.Add(new SqlParameter("Address1", SqlDbType.VarChar,50)).Value = customer.Address1;

            cmd.Parameters.Add(new SqlParameter("Address2", SqlDbType.VarChar, 50)).Value = customer.Address2 == null ? "" : customer.Address2;

			cmd.Parameters.Add(new SqlParameter("PostalCode", SqlDbType.Char,5)).Value = customer.PostalCode;

			cmd.Parameters.Add(new SqlParameter("City", SqlDbType.VarChar,50)).Value = customer.City;

			cmd.Parameters.Add(new SqlParameter("State", SqlDbType.Char,2)).Value = customer.State;


            // output parameter
            var o = new SqlParameter("Rowcount", SqlDbType.Int);
            o.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(o);

            try
            {
                // open the connection
                conn.Open();

                // execute  the command
                rowCount = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rowCount;
        }


        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns>System.Int32.</returns>
        public static int UpdateCustomer(Customer customer)
        {
            int rowCount = 0;

            // begin with a connection
            var conn = DBConnection.GetDBConnection();

            // get some commandText
            string cmdText = "sp_CustomersUpdate";

            // create a command object
            var cmd = new SqlCommand(cmdText, conn);

            // here is where things change a bit
            // first, we need to set the command type
            cmd.CommandType = CommandType.StoredProcedure;


            // we need to construct and add the parameters
            
            cmd.Parameters.Add(new SqlParameter("CustomerID", SqlDbType.Int)).Value = customer.CustomerID;
            
            cmd.Parameters.Add(new SqlParameter("FirstName", SqlDbType.VarChar, 50)).Value = customer.FirstName;

            cmd.Parameters.Add(new SqlParameter("LastName", SqlDbType.VarChar, 50)).Value = customer.LastName;

            cmd.Parameters.Add(new SqlParameter("EmailID", SqlDbType.VarChar, 50)).Value = customer.EmailID;

            cmd.Parameters.Add(new SqlParameter("PhoneNo1", SqlDbType.Char, 10)).Value = customer.PhoneNo1;

            cmd.Parameters.Add(new SqlParameter("PhoneNo2", SqlDbType.Char, 10)).Value = customer.PhoneNo2;

            cmd.Parameters.Add(new SqlParameter("Address1", SqlDbType.VarChar, 50)).Value = customer.Address1;

            cmd.Parameters.Add(new SqlParameter("Address2", SqlDbType.VarChar, 50)).Value = customer.Address2;

            cmd.Parameters.Add(new SqlParameter("PostalCode", SqlDbType.Char, 5)).Value = customer.PostalCode;

            cmd.Parameters.Add(new SqlParameter("City", SqlDbType.VarChar, 50)).Value = customer.City;

            cmd.Parameters.Add(new SqlParameter("State", SqlDbType.Char, 2)).Value = customer.State;


            // output parameter
            var o = new SqlParameter("Rowcount", SqlDbType.Int);
            o.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(o);

            try
            {
                // open the connection
                conn.Open();

                // execute  the command
                rowCount = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rowCount;
        }



        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <param name="customerID">The customer identifier.</param>
        /// <returns>System.Int32.</returns>
        public static int DeleteCustomer(int customerID)
        {
            int rowCount = 0;

            // begin with a connection
            var conn = DBConnection.GetDBConnection();

            // get some commandText
            string cmdText = "sp_CustomerDelete";

            // create a command object
            var cmd = new SqlCommand(cmdText, conn);

            // here is where things change a bit
            // first, we need to set the command type
            cmd.CommandType = CommandType.StoredProcedure;


            // we need to construct and add the parameters

            cmd.Parameters.Add(new SqlParameter("CustomerID", SqlDbType.Int)).Value = customerID;

            // output parameter
            var o = new SqlParameter("Rowcount", SqlDbType.Int);
            o.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(o);

            try
            {
                // open the connection
                conn.Open();

                // execute  the command
                rowCount = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rowCount;
        }

    }
}
