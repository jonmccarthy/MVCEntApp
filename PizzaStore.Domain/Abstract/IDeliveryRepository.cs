using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Domain.Entities;

namespace PizzaStore.Domain.Abstract
{
    public interface IDeliveryRepository
    {
        IQueryable<DeliveryDetails> DeliveryDetails { get; }
        void SaveDelivery(DeliveryDetails deliveryDetails);
        int CreateDelivery(DeliveryDetails delivery);
        void DeleteItems(DeliveryDetails deliveryDetails);
    }
}
