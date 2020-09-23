namespace Cab_Invoice_Generator
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// InvoiceGenerator Class
    /// </summary>
    public class InvoiceGenerator
    {
        public readonly string NAMEPATTERN = "^[A-Z]{1}[a-z]{2,5}[0-9]{2,5}$";

        /// <summary>
        /// Method to validate first name
        /// </summary>
        /// <param name="distance">total distance</param>
        /// <param name="time">total time</param>
        /// <param name="type">normal or primium</param>
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
        /// <returns>InvoiceSummary</returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {      
          InvoiceSummary invoiceSummary = new InvoiceSummary();
            double totalFare = 0;
            int numberOfRides = 0;
            if (Regex.Match(userId, this.NAMEPATTERN).Success)
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
