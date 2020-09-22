using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class InvoiceGenerator
    {
        public double CalculateFare(double distance, int time, string type = "Normal")
        {
            RideType rideType = new RideType(type);
            double totalFare = distance * rideType.minimumCostPerKilometer + time * rideType.costPerTime;
            if (totalFare < rideType.minimumFare)
            {
                return rideType.minimumFare;
            }
            return totalFare;
        }

        public InvoiceSummary GetInvoiceSummary(string userId)
        {      
          InvoiceSummary invoiceSummary = new InvoiceSummary();
            double totalFare = 0;
            int numberOfRides = 0;

            if (UserAccount.account.ContainsKey(userId))
            {
               
                foreach (Rides ride in UserAccount.account[userId])
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time, ride.rideType);
                    numberOfRides++;
                }
                
            }
            invoiceSummary.TotalNumberOfRides = numberOfRides;
            invoiceSummary.TotalFare = totalFare;
            invoiceSummary.CalculateAvergaeFare();
            return invoiceSummary;

        }
    }
}
