//-----------------------------------------------------------------------
// <copyright file="Rides.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Cab_Invoice_Generator
{
    /// <summary>
    /// Rides Class
    /// </summary>
    public class Rides
    {
        /// <summary>
        /// distance variable
        /// </summary>    
        public double DISTANCE;

        /// <summary>
        /// time variable
        /// </summary>  
        public int TIME;

        /// <summary>
        /// ride type
        /// </summary>
        public string RIDETYPE;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rides" /> class.
        /// </summary>
        /// <param name="inputDistance">input distance.</param>
        /// <param name="inputTime">input time </param>
        /// <param name="inputRideType">ride type</param>
        public Rides(double inputDistance, int inputTime, string inputRideType)
        {
            this.DISTANCE = inputDistance;
            this.TIME = inputTime;
            this.RIDETYPE = inputRideType;
        }
    }
}
