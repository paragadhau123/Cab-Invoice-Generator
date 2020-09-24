//-----------------------------------------------------------------------
// <copyright file="RideType.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Cab_Invoice_Generator
{
    /// <summary>
    /// RideType Class
    /// </summary>
    public class RideType
    {
        /// <summary>
        /// normal ride
        /// </summary>
        public static readonly string NORMALRIDE = "Normal";

        /// <summary>
        /// premium ride
        /// </summary>
        public static readonly string PREMIUMRIDE = "Premium";

        /// <summary>
        /// cost per time
        /// </summary>
        public readonly int COSTPERTIME;

        /// <summary>
        /// min and max cost per km
        /// </summary>
        public readonly double MINIMUMCOSTPERKILOMETER;

        /// <summary>
        /// min fare
        /// </summary>
        public readonly double MINIMUMFARE;

        /// <summary>
        /// Initializes a new instance of the <see cref="RideType" /> class.
        /// </summary>
        /// <param name="rideType">type of ride.</param>
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
