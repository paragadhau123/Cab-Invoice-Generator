using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
   public class UserAccount
    {
        public static Dictionary<string, List<Rides>> account = new Dictionary<string, List<Rides>>();

        public static void AddRides(string key, List<Rides> inputRides)
        {
            if (account.ContainsKey(key))
            {
                foreach (Rides ride in inputRides)
                {
                    account[key].Add(ride);
                }
            }
            else
            {
                account.Add(key, inputRides);
            }
        }
    }
}
