using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap5.FactoryPatterns
{
    public static class ShippingCourierFactory
    {
        public static IShippingCourier CreateShippingCourier(Order order)
        {
            if (order.TotalCost > 100 || order.WeightInKg > 5)
            {
                return new DHL();
            }
            return new RoyalMailCourier();
        }
    }
}
