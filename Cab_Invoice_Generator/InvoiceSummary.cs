namespace Cab_Invoice_Generator
{
    /// <summary>
    /// InvoiceSummary Class
    /// </summary>
    public class InvoiceSummary
    {
        public int TotalNumberOfRides { get; set; }

        public double TotalFare { get; set; }

        public double AverageFarePerRide { get; set; }

        public void CalculateAvergaeFare()
        {
            this.AverageFarePerRide = this.TotalFare / this.TotalNumberOfRides;
        }
    }
}