//-----------------------------------------------------------------------
// <copyright file="TestMethod.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Cab_Invoice_Generator_Test
{
    using System.Collections.Generic;
    using Cab_Invoice_Generator;
    using NUnit.Framework;

    /// <summary>
    /// Tests Class
    /// </summary>
    public class TestMethod
    {
        /// <summary>
        /// User id variable
        /// </summary>
        public readonly string USERID = "Parag123";

        /// <summary>
        /// Distance variable
        /// </summary>
        public readonly double DISTANCE = 2.0;

        /// <summary>
        /// Time variable
        /// </summary>
        public readonly int TIME = 5;

        /// <summary>
        /// Type variable
        /// </summary>
        public readonly string TYPE = "Normal";

        /// <summary>
        /// InvoiceGenerator object 
        /// </summary>
        public InvoiceGenerator INVOICEGENERATOR = null;

        /// <summary>
        ///  Method SetUp
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.INVOICEGENERATOR = new InvoiceGenerator();
        }

        /// <summary>
        /// Test Method to Find Total Fare
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFare()
        {
            double fare = this.INVOICEGENERATOR.CalculateFare(this.DISTANCE, this.TIME, this.TYPE);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }

        /// <summary>
        /// Test Method to Find Total Fare
        /// </summary>
        [Test]
        public void GivenLessDistanceAndTime_ShouldReturnMinFare()
        {
            double fare = this.INVOICEGENERATOR.CalculateFare(0.1, 1, this.TYPE);
            double expected = 5;
            Assert.AreEqual(expected, fare);
        }

        /// <summary>
        /// Test Method to Find Total Fare
        /// </summary>
        [Test]
        public void GivenMultipleRides_ShouldReturnTotalFare()
        {
            Rides firstRide = new Rides(2.0, 5, "Premium");
            Rides secondRide = new Rides(0.1, 1, "Normal");
            List<Rides> rides = new List<Rides> { firstRide, secondRide };
            UserAccount.AddRides(this.USERID, rides);
            InvoiceSummary invoiceSummary = this.INVOICEGENERATOR.GetInvoiceSummary(this.USERID);
            double expected = 30;
            Assert.AreEqual(expected, invoiceSummary.TotalFare);
        }

        /// <summary>
        /// Test Method to Find Total Fare
        /// </summary>
        [Test]
        public void GivenUSerId_ShouldReturnInvoiceSummary()
        {
         Rides firstRide = new Rides(2.0, 5, "Premium");
         Rides secondRide = new Rides(0.1, 1, "Normal");
        List<Rides> rides = new List<Rides> { firstRide, secondRide };
            UserAccount.AddRides(this.USERID, rides);
            InvoiceSummary invoiceSummary = this.INVOICEGENERATOR.GetInvoiceSummary(this.USERID);
            InvoiceSummary expected = new InvoiceSummary
            {
                TotalNumberOfRides = 2,
                TotalFare = 90.0,
                AverageFarePerRide = 23
            };
           Assert.AreEqual(expected.TotalFare, invoiceSummary.TotalFare);
        }

        /// <summary>
        /// Test Method to Find Total Fare
        /// </summary>
        [Test]
        public void GivenPremiumRide_ShouldReturnInvoiceSummary()
        {
        Rides firstRide = new Rides(2.0, 5, "Premium");
        Rides secondRide = new Rides(0.1, 1, "Normal");
        List<Rides> rides = new List<Rides> { firstRide, secondRide };
            UserAccount.AddRides(this.USERID, rides);
            InvoiceSummary invoiceSummary = this.INVOICEGENERATOR.GetInvoiceSummary(this.USERID);
            InvoiceSummary expected = new InvoiceSummary
            {
                TotalNumberOfRides = 2,
                TotalFare = 60.0,
                AverageFarePerRide = 23
            };
            Assert.AreEqual(expected.TotalFare, invoiceSummary.TotalFare);
        }
    }
}