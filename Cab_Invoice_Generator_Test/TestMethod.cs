using NUnit.Framework;
using Cab_Invoice_Generator;
using System.Collections.Generic;

namespace Cab_Invoice_Generator_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }

        [Test]
        public void GivenLessDistanceAndTime_ShouldReturnMinFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            double distance = 0.1;
            int time = 1;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 5;
            Assert.AreEqual(expected, fare);
        }

        [Test]
        public void GivenMultipleRides_ShouldReturnTotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            string userId = "parag";
            Rides firstRide = new Rides(2.0, 5);
            Rides secondRide = new Rides(0.1, 1);
            List<Rides> rides = new List<Rides> { firstRide, secondRide };
            UserAccount.AddRides(userId, rides);
            InvoiceSummary invoiceSummary = invoiceGenerator.GetInvoiceSummary(userId);
            double expected = 30;
            Assert.AreEqual(expected, invoiceSummary.TotalFare);
        }

        [Test]
        public void GivenUSerId_ShouldReturnInvoiceSummary()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            string userId = "parag";
            Rides firstRide = new Rides(3.0, 5);
            Rides secondRide = new Rides(1, 1);
            List<Rides> rides = new List<Rides> { firstRide, secondRide };
            UserAccount.AddRides(userId, rides);
            InvoiceSummary invoiceSummary = invoiceGenerator.GetInvoiceSummary(userId);
            InvoiceSummary expected = new InvoiceSummary
            {
                TotalNumberOfRides = 2,
                TotalFare = 46,
                AverageFarePerRide = 23
            };
            object.Equals(expected, invoiceSummary);
        }

        [Test]
        public void GivenPremiumRide_ShouldReturnInvoiceSummary()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            string userId = "parag";
            Rides firstRide = new Rides(3.0, 5, "Premium");
            Rides secondRide = new Rides(1, 1, "Normal");
            List<Rides> rides = new List<Rides> { firstRide, secondRide };
            UserAccount.AddRides(userId, rides);
            InvoiceSummary invoiceSummary = invoiceGenerator.GetInvoiceSummary(userId);
            InvoiceSummary expected = new InvoiceSummary
            {
                TotalNumberOfRides = 2,
                TotalFare = 66,
                AverageFarePerRide = 33
            };
            Assert.AreEqual(expected.TotalFare, invoiceSummary.TotalFare);
        }
    }
}