using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class RideType
    {
        public static readonly string normalRide = "Normal";
        public static readonly string premiumRide = "Premium";
        public readonly int costPerTime;
        public readonly double minimumCostPerKilometer;
        public readonly double minimumFare;

        public RideType(string rideType)
        {
            if (rideType.ToLower() == premiumRide)
            {
                costPerTime = 2;
                minimumCostPerKilometer = 15;
                minimumFare = 20;
            }
            else
            {
                costPerTime = 1;
                minimumCostPerKilometer = 10;
                minimumFare = 5;
            }
        }
    }
}
