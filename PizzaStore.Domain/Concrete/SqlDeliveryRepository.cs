using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Domain.Abstract;
using PizzaStore.Domain.Entities;
using System.Data.Linq;

namespace PizzaStore.Domain.Concrete
{
    public class SqlDeliveryRepository : IDeliveryRepository
    {
        private Table<DeliveryDetails> deliveryTable;
        //private IOrderRepository orderRepository;

        public SqlDeliveryRepository(string connectionString)
        {
            deliveryTable = (new DataContext(connectionString)).GetTable<DeliveryDetails>();
            //this.orderRepository = orderRepository;
        }

        public IQueryable<DeliveryDetails> DeliveryDetails
        {
            get { return deliveryTable; }
        }

        public void SaveDelivery(DeliveryDetails deliveryDetails)
        {
            // If its a new product, just attach it to the DataContext
            if (deliveryDetails.DeliveryID == 0)
                deliveryTable.InsertOnSubmit(deliveryDetails);
            else if (deliveryTable.GetOriginalEntityState(deliveryDetails) == null)
            {
                // Were updating an existing menu item, but its not attached to the
                // this data context, so attach it and detect the changes
                deliveryTable.Attach(deliveryDetails);
                deliveryTable.Context.Refresh(RefreshMode.KeepCurrentValues, deliveryDetails);
            }
            deliveryTable.Context.SubmitChanges();
        }

        public int CreateDelivery(DeliveryDetails delivery)
        {
            SaveDelivery(delivery);
            return delivery.DeliveryID;
        }

        public void DeleteItems(DeliveryDetails deliveryDetails)
        {
            deliveryTable.DeleteOnSubmit(deliveryDetails);
            deliveryTable.Context.SubmitChanges();
        }
    }
}
