// ***********************************************************************
// Assembly         : BusinessLogic
// Author           : PDUBEY
// Created          : 11-20-2015
//
// Last Modified By : PDUBEY
// Last Modified On : 11-20-2015
// ***********************************************************************
// <copyright file="HashMethods.cs" company="">
//     Copyright ©  2015
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLogic
{
    /// <summary>
    /// Class HashMethods.
    /// </summary>
    public static class HashMethods
    {
        /// <summary>
        /// Hashes the MD5.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>System.String.</returns>
        public static string HashMd5(this string source)
        {
            // create a byte array
            byte[] data;

            // create a .NET Hash provider object
            using(MD5 md5hash = MD5.Create())
            {
                // hash the input 
                data = md5hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }

            // create an output stringBuilder
            var s = new StringBuilder();
            
            // loop through the hash creating letters for the stringbuilder
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            // return the hexadecimal string representation of the hash
            return s.ToString();
        }

        /// <summary>
        /// Hashes the sha1.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>System.String.</returns>
        public static string HashSha1(this string source)
        {
            // create a byte array
            byte[] data;

            // create a .NET Hash provider object
            using (SHA1 sha1hash = SHA1.Create())
            {
                // hash the input 
                data = sha1hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }

            // create an output stringBuilder
            var s = new StringBuilder();

            // loop through the hash creating letters for the stringbuilder
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            // return the hexadecimal string representation of the hash
            return s.ToString();
        }

        /// <summary>
        /// Hashes the sha256.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>System.String.</returns>
        public static string HashSha256(this string source)
        {
            // create a byte array
            byte[] data;

            // create a .NET Hash provider object
            using (SHA256 sha256hash = SHA256.Create())
            {
                // hash the input 
                data = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }

            // create an output stringBuilder
            var s = new StringBuilder();

            // loop through the hash creating letters for the stringbuilder
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            // return the hexadecimal string representation of the hash
            return s.ToString();
        }

        /// <summary>
        /// Hashes the sha512.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>System.String.</returns>
        public static string HashSha512(this string source)
        {
            // create a byte array
            byte[] data;

            // create a .NET Hash provider object
            using (SHA512 sha512hash = SHA512.Create())
            {
                // hash the input 
                data = sha512hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }

            // create an output stringBuilder
            var s = new StringBuilder();

            // loop through the hash creating letters for the stringbuilder
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            // return the hexadecimal string representation of the hash
            return s.ToString();
        }

        /// <summary>
        /// Verifies the MD5 hash.
        /// </summary>
        /// <param name="compareString">The compare string.</param>
        /// <param name="hashString">The hash string.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool VerifyMd5Hash(this string compareString, string hashString)
        // compareString is presumed to be an ordinary string to check
        // against a stored hash value representation pulled from a database
        {
            // use a string comparer to compare values
            var c = StringComparer.OrdinalIgnoreCase;

            // do the comparison in the return statement
            return (0 == c.Compare(compareString.HashMd5(), hashString));
        }

        /// <summary>
        /// Verifies the sha1 hash.
        /// </summary>
        /// <param name="compareString">The compare string.</param>
        /// <param name="hashString">The hash string.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool VerifySha1Hash(this string compareString, string hashString)
        // compareString is presumed to be an ordinary string to check
        // against a stored hash value representation pulled from a database
        {
            // use a string comparer to compare values
            var c = StringComparer.OrdinalIgnoreCase;

            // do the comparison in the return statement
            return (0 == c.Compare(compareString.HashSha1(), hashString));
        }

        /// <summary>
        /// Verifies the sha256 hash.
        /// </summary>
        /// <param name="compareString">The compare string.</param>
        /// <param name="hashString">The hash string.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool VerifySha256Hash(this string compareString, string hashString)
        // compareString is presumed to be an ordinary string to check
        // against a stored hash value representation pulled from a database
        {
            // use a string comparer to compare values
            var c = StringComparer.OrdinalIgnoreCase;

            // do the comparison in the return statement
            return (0 == c.Compare(compareString.HashSha256(), hashString));
        }

        /// <summary>
        /// Verifies the sha512 hash.
        /// </summary>
        /// <param name="compareString">The compare string.</param>
        /// <param name="hashString">The hash string.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool VerifySha512Hash(this string compareString, string hashString)
        // compareString is presumed to be an ordinary string to check
        // against a stored hash value representation pulled from a database
        {
            // use a string comparer to compare values
            var c = StringComparer.OrdinalIgnoreCase;

            // do the comparison in the return statement
            return (0 == c.Compare(compareString.HashSha512(), hashString));
        }
    }
}
