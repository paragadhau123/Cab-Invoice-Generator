namespace Cab_Invoice_Generator
{
    /// <summary>
    /// RideType Class
    /// </summary>
    public class RideType
    {
        public static readonly string NORMALRIDE = "Normal";
        public static readonly string PREMIUMRIDE = "Premium";
        public readonly int COSTPERTIME;
        public readonly double MINIMUMCOSTPERKILOMETER;
        public readonly double MINIMUMFARE;

        public RideType(string rideType)
        {
            if (rideType.ToLower() == PREMIUMRIDE)
            {
                this.COSTPERTIME = 2;
                this.MINIMUMCOSTPERKILOMETER = 15;
                this.MINIMUMFARE = 20;
            }
            else
            {
                this.COSTPERTIME = 1;
                this.MINIMUMCOSTPERKILOMETER = 10;
                this.MINIMUMFARE = 5;
            }
        }
    }
}
