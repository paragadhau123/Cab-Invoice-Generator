using NUnit.Framework;
using Cab_Invoice_Generator;
namespace Cab_Invoice_Generator_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenDistanceaAndTime_ShouldReturnTotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }

        [Test]
        public void GivenDistanceaAndTime_ShouldReturnMinumumFare()
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
            Rides[] rides = { new Rides(2.0, 5),
                new Rides(0.1, 1)
            };
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rides);
            double expected = 30;
            Assert.AreEqual(expected, invoiceSummary.TotalFare);

        }

        [Test]
        public void GivenMultipleRides_ShouldReturnInvoiceSummary()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();

            Rides[] rides = { new Rides(2.0, 5),
                new Rides(0.1, 1)
            };
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expected = new InvoiceSummary
            {
                TotalNumberOfRides = 2,
                TotalFare = 30,
                AverageFarePerRide = 15
            };
            object.Equals(expected, invoiceSummary);
        }
    }
}