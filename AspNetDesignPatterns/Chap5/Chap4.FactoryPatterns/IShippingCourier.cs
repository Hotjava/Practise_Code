using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap5.FactoryPatterns
{
    public interface IShippingCourier
    {
         string CreateConsignmentLabelFor(Address address);
    }

    public class RoyalMailCourier:IShippingCourier
    {
        public string CreateConsignmentLabelFor(Address address)
        {
            return "RMXXXX-XXXX-XXXX";
        }
    }

    public  class DHL:IShippingCourier
    {
        public string CreateConsignmentLabelFor(Address address)
        {
            return "DHL-XXXX-XXXX-XXXX";

        }
    }
}
