namespace Cab_Invoice_Generator
{   
    public class InvoiceGenerator
    {
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

        public InvoiceSummary GetInvoiceSummary(string userId)
        {      
          InvoiceSummary invoiceSummary = new InvoiceSummary();
            double totalFare = 0;
            int numberOfRides = 0;

            if (UserAccount.ACCOUNTS.ContainsKey(userId))
            {
                foreach (Rides ride in UserAccount.ACCOUNTS[userId])
                {
                    totalFare += this.CalculateFare(ride.DISTANCE, ride.TIME, ride.RIDETYPE);
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
