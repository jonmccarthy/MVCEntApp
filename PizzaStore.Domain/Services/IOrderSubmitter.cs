using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Domain.Entities;

namespace PizzaStore.Domain.Services
{
    public interface IOrderSubmitter
    {
        int SubmitOrder(Cart cart, DeliveryDetails deliveryDetails, int CustID, String CustEmail);
    }
}
