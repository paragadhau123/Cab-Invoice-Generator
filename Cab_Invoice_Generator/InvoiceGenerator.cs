//-----------------------------------------------------------------------
// <copyright file="InvoiceGenerator.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Cab_Invoice_Generator
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// InvoiceGenerator Class
    /// </summary>
    public class InvoiceGenerator
    {
        /// <summary>
        /// User id regular expression pattern
        /// </summary>
        public readonly string USERIDPATTERN = "^[A-Z]{1}[a-z]{2,5}[0-9]{2,5}$";

        /// <summary>
        /// Method to validate first name
        /// </summary>
        /// <param name="distance">total distance</param>
        /// <param name="time">total time</param>
        /// <param name="type">define type</param>
        /// <returns>total fare</returns>
        public double CalculateFare(double distance, int time, string type)
        {
            RideType rideType = new RideType(type);
            double totalFare = (distance * rideType.MINIMUMCOSTPERKILOMETER) + (time * rideType.COSTPERTIME);
            if (totalFare < rideType.MINIMUMFARE)
            {
                return rideType.MINIMUMFARE;
            }

            return totalFare;
        }

        /// <summary>
        /// Method to validate first name
        /// </summary>
        /// <param name="userId">total distance</param>
        /// <returns>Invoice Summary</returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {      
          InvoiceSummary invoiceSummary = new InvoiceSummary();
            double totalFare = 0;
            int numberOfRides = 0;
            if (Regex.Match(userId, this.USERIDPATTERN).Success)
            {
                if (UserAccount.ACCOUNTS.ContainsKey(userId))
                {
                    foreach (Rides ride in UserAccount.ACCOUNTS[userId])
                    {
                        totalFare += this.CalculateFare(ride.DISTANCE, ride.TIME, ride.RIDETYPE);
                        numberOfRides++;
                    }
                }
            }

            invoiceSummary.TotalNumberOfRides = numberOfRides;
            invoiceSummary.TotalFare = totalFare;
            invoiceSummary.CalculateAvergaeFare();
            return invoiceSummary;
        }
    }
}
