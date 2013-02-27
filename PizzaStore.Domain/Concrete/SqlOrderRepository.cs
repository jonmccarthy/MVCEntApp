using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Domain.Abstract;
using PizzaStore.Domain.Entities;
using System.Data.Linq;

namespace PizzaStore.Domain.Concrete
{
    public class SqlOrderRepository : IOrderRepository
    {
        private Table<Order> orderTable;
        //private IOrderRepository orderRepository;

        public SqlOrderRepository(string connectionString)
        {
            orderTable = (new DataContext(connectionString)).GetTable<Order>();
            //this.orderRepository = orderRepository;
        }

        public IQueryable<Order> Orders
        {
            get { return orderTable; }
        }

        public void SaveOrder(Order order)
        {
            // If its a new product, just attach it to the DataContext
            if (order.OrdersID == 0)
                orderTable.InsertOnSubmit(order);
            else if (orderTable.GetOriginalEntityState(order) == null)
            {
                // Were updating an existing menu item, but its not attached to the
                // this data context, so attach it and detect the changes
                orderTable.Attach(order);
                orderTable.Context.Refresh(RefreshMode.KeepCurrentValues, order);
            }
            orderTable.Context.SubmitChanges();
        }

        public int CreateOrder(int customerID)
        {
            // ---------------------
            Order order = new Order
            {
                OrdersID = 0,
                FKMenuCustomerID = customerID,
                DateOrder = DateTime.Now
            };
            SaveOrder(order);
            return order.OrdersID;
        }

        public void CompleteOrder(Order order)
        {
            orderTable.Attach(order);
            orderTable.Context.Refresh(RefreshMode.KeepCurrentValues, order);
            orderTable.Context.SubmitChanges();
        }

        public void DeleteItems(Order orders)
        {
            orderTable.DeleteOnSubmit(orders);
            orderTable.Context.SubmitChanges();
        }

        public int ValidateOrderView(int OrderID)
        {
            int CustID = 0;
            try
            {
                Order o = orderTable.First(x => x.OrdersID == OrderID);
                CustID = o.FKMenuCustomerID;
            }
            catch { }
            return CustID;
        }
    }
}
