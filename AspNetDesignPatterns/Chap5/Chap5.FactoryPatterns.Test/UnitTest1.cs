using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chap5.FactoryPatterns.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UKShippingCourierFactory_Should_Create_DHL_Shipping_Courier_For_An_Order_With_A_TotalCost_Of_Over_100()
        {
            Order order = new Order() {TotalCost = 101};
            IShippingCourier courier = ShippingCourierFactory.CreateShippingCourier(order); 
            Assert.IsInstanceOfType(courier, typeof(DHL));
        }

        [TestMethod]
        public void UKShippingCourierFactory_Should_Create_DHL_Shipping_Courier_For_An_Order_With_A_Weight_In_KG_Over_5()
        {
            Order order = new Order() {WeightInKg = 6};
            IShippingCourier courier = ShippingCourierFactory.CreateShippingCourier(order); 
            Assert.IsInstanceOfType(courier, typeof(DHL));
        }

       
    }
}
