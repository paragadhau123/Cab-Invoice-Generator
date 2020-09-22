using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class Rides
    {
        public double distance;
        public int time;
        public string rideType;

        public Rides(double inputDistance, int inputTime, string inputRideType = "Normal")
        {
            distance = inputDistance;
            time = inputTime;
            rideType = inputRideType;
        }
    }
}
