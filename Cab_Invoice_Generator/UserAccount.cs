//-----------------------------------------------------------------------
// <copyright file="UserAccount.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Cab_Invoice_Generator
{
    using System.Collections.Generic;

    /// <summary>
    /// UserAccount Class
    /// </summary>
    public class UserAccount
    {
        /// <summary>
        /// creating object of dictionary
        /// </summary>
        public static Dictionary<string, List<Rides>> ACCOUNTS = new Dictionary<string, List<Rides>>();

        /// <summary>
        /// for adding rides
        /// </summary>
        /// <param name="key">set key</param>
        /// <param name="inputRides">input of rides</param>
        public static void AddRides(string key, List<Rides> inputRides)
        {
            if (ACCOUNTS.ContainsKey(key))
            {
                foreach (Rides ride in inputRides)
                {
                    ACCOUNTS[key].Add(ride);
                }
            }
            else
            {
                ACCOUNTS.Add(key, inputRides);
            }
        }
    }
}
