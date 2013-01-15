namespace Chap5.FactoryPatterns
{
    public class OrderService
    {
        public void Dispatch(Order order)
        {
            IShippingCourier courier = ShippingCourierFactory.CreateShippingCourier(order);

            order.CourierTrackingId = courier.CreateConsignmentLabelFor(order.Address);
        }
    }
}