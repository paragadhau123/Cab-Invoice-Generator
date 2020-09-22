using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class Rides
    {
        public double distance;
        public int time;

        public Rides(double inputDistance, int inputTime)
        {
            distance = inputDistance;
            time = inputTime;
        }
    }
}
