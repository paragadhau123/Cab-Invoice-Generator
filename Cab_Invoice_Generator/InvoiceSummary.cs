namespace Cab_Invoice_Generator
{
    public class InvoiceSummary
    {
        public int TotalNumberOfRides { get; set; }
        public double TotalFare { get; set; }
        public double AverageFarePerRide { get; set; }

        public void CalculateAvergaeFare()
        {
            AverageFarePerRide = TotalFare / TotalNumberOfRides;
        }
    }
}