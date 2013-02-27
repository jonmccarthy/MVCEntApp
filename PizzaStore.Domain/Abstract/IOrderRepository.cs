using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Domain.Entities;

namespace PizzaStore.Domain.Abstract
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
        int CreateOrder(int customerID);
        void DeleteItems(Order orders);
        int ValidateOrderView(int OrderID);
    }
}
