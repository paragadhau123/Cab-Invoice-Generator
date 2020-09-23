namespace Cab_Invoice_Generator
{
    using System.Collections.Generic;

    public class UserAccount
    {
        public static Dictionary<string, List<Rides>> ACCOUNTS = new Dictionary<string, List<Rides>>();

        public static void AddRides(string key, List<Rides> inputRides)
        {
            if (ACCOUNTS.ContainsKey(key))
            {
                foreach (Rides ride in inputRides)
                {
                    ACCOUNTS[key].Add(ride);
                }
            }
            else
            {
                ACCOUNTS.Add(key, inputRides);
            }
        }
    }
}
