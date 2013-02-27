using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Domain.Abstract;
using PizzaStore.Domain.Entities;
using System.Data.Linq;

namespace PizzaStore.Domain.Concrete
{
    public class SqlOrderDisplayRepository : IOrderDisplayRepository
    {
        private Table<Order> ordersTable;
        private Table<OrderItem> orderItemsTable;
        private Table<DeliveryDetails> deliveryDetailsTable;

        public List<Order> ListOrder { get; set; }
        public List<OrderItem> ListOrderItem { get; set; }
        public List<DeliveryDetails> ListDeliveryDetail { get; set; }



        public SqlOrderDisplayRepository(string connectionString)
        {
            ordersTable = (new DataContext(connectionString)).GetTable<Order>();
            orderItemsTable = (new DataContext(connectionString)).GetTable<OrderItem>();
            deliveryDetailsTable = (new DataContext(connectionString)).GetTable<DeliveryDetails>();

            ListOrder = ordersTable.ToList();
            ListOrderItem = orderItemsTable.ToList();
            ListDeliveryDetail = deliveryDetailsTable.ToList();
        }

        public IQueryable<Order> Orders
        {
            get { return ordersTable; }
        }

        public IQueryable<OrderItem> OrderItems
        {
            get { return orderItemsTable; }
        }

        public IQueryable<DeliveryDetails> DeliveryDetails
        {
            get { return deliveryDetailsTable; }
        }

        public List<Order> ListOrderJMC
        {
            get { return ListOrder; }
        }

        public List<OrderItem> ListOrderItemJMC
        {
            get { return ListOrderItem; }
        }

        public List<DeliveryDetails> ListDeliveryDetailJMC
        {
            get { return ListDeliveryDetail; }
        }

    }
}
