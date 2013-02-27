using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaStore.Domain.Entities;

namespace PizzaStore.WebUI.Infrastructure
{
    public class CartModelBinder : IModelBinder
    {
        private const string cartSessionKey = "_cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.Model != null)
                throw new InvalidOperationException("Cannot update instances!!");

            Cart cart = (Cart)controllerContext.HttpContext.Session[cartSessionKey];
            if (cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session[cartSessionKey] = cart;
            }
            return cart;
        }

    }
}