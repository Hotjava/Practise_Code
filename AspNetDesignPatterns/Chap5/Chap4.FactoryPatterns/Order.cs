using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap5.FactoryPatterns
{
    public class Order
    {
        public string CourierTrackingId { get; set; }
        public decimal TotalCost { get; set; }
        public Decimal WeightInKg { get; set; }

        public Address Address { get; set; }
    }

    public class Address
    {
        public string CountryCode { get; set; }
    }
}
