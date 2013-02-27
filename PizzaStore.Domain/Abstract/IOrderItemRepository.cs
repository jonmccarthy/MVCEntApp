using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Domain.Entities;

namespace PizzaStore.Domain.Abstract
{
    public interface IOrderItemRepository
    {
        IQueryable<OrderItem> OrderItems { get; }
        void SaveOrderItem(OrderItem orderItem);
        void CreateOrderItem(int orderID, string PName, string PDescription, int Qty, decimal PPrice);
        void CreateOrderList(int orderID, Cart cart);
        void DeleteItems(OrderItem orderItem);
    }
}
