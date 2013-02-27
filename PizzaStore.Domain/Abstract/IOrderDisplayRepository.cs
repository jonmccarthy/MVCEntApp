using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Domain.Entities;

namespace PizzaStore.Domain.Abstract
{
    public interface IOrderDisplayRepository
    {
        //IList<Order> ListAllJMC();
        IQueryable<Order> Orders { get; }
        IQueryable<OrderItem> OrderItems { get; }
        IQueryable<DeliveryDetails> DeliveryDetails { get; }
        List<Order> ListOrderJMC { get; }
        List<OrderItem> ListOrderItemJMC { get; }
        List<DeliveryDetails> ListDeliveryDetailJMC { get; }
    }
}
