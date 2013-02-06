using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Text;

namespace SportsStore.Domain.Entities
{
    public class CartModelBinder:IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Cart cart = (Cart) controllerContext.HttpContext.Session[sessionKey];

            if (cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session.Add(sessionKey, cart);
            }
            return cart;
        }
    }
}
