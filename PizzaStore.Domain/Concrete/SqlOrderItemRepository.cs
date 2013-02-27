using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Domain.Entities;
using System.Data.Linq;
using PizzaStore.Domain.Abstract;

namespace PizzaStore.Domain.Concrete
{
    public class SqlOrderItemRepository : IOrderItemRepository
    {
        private Table<OrderItem> orderItemTable;
        //private IOrderRepository orderRepository;

        public SqlOrderItemRepository(string connectionString)
        {
            orderItemTable = (new DataContext(connectionString)).GetTable<OrderItem>();
            //this.orderRepository = orderRepository;
        }

        public IQueryable<OrderItem> OrderItems
        {
            get { return orderItemTable; }
        }

        public void SaveOrderItem(OrderItem orderItem)
        {
            // If its a new product, just attach it to the DataContext
            if (orderItem.OrderItemsID == 0)
                orderItemTable.InsertOnSubmit(orderItem);
            else if (orderItemTable.GetOriginalEntityState(orderItem) == null)
            {
                // Were updating an existing menu item, but its not attached to the
                // this data context, so attach it and detect the changes
                orderItemTable.Attach(orderItem);
                orderItemTable.Context.Refresh(RefreshMode.KeepCurrentValues, orderItem);
            }
            orderItemTable.Context.SubmitChanges();
        }

        public void CreateOrderItem(int orderID, string PName, string PDescription, int Qty, decimal PPrice)
        {
            OrderItem orderItem = new OrderItem
            {
                FKOrdersID = orderID,
                ProductName = PName,
                ProductDescription = PDescription,
                Quantity = Qty,
                Price = PPrice
            };
            SaveOrderItem(orderItem);
        }

        public void CreateOrderList(int orderID, Cart cart)
        {
            foreach (var line in cart.Lines)
            {
                CreateOrderItem(orderID, line.MenuItem.ProductName, line.MenuItem.ProductDescription, line.Quantity, line.MenuItem.Price);
            }
        }

        public void DeleteItems(OrderItem orderItem)
        {
            orderItemTable.DeleteOnSubmit(orderItem);
            orderItemTable.Context.SubmitChanges();
        }
    }
}
