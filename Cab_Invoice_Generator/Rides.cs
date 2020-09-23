namespace Cab_Invoice_Generator
{
    /// <summary>
    /// Rides Class
    /// </summary>
    public class Rides
    {
        public double DISTANCE;
        public int TIME;
        public string RIDETYPE;

        public Rides(double inputDistance, int inputTime, string inputRideType)
        {
            this.DISTANCE = inputDistance;
            this.TIME = inputTime;
            this.RIDETYPE = inputRideType;
        }
    }
}
