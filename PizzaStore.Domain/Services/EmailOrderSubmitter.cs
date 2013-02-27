using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Domain.Entities;
using System.Net.Mail;
using PizzaStore.Domain.Abstract;

namespace PizzaStore.Domain.Services
{
    public class EmailOrderSubmitter : IOrderSubmitter
    {
        private string mailTo;
        private IOrderRepository orderRepository;
        private IOrderItemRepository orderItemRepository;
        private IDeliveryRepository deliveryRepository;

        public EmailOrderSubmitter(string mailTo, IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IDeliveryRepository deliveryRepository)
        {
            this.mailTo = mailTo;
            this.orderRepository = orderRepository;
            this.orderItemRepository = orderItemRepository;
            this.deliveryRepository = deliveryRepository;
        }

        public int SubmitOrder(Cart cart, DeliveryDetails deliveryDetails, int CustID, String CustEmail)
        {
            // Need to pass the CustomerID in here!!!
            int orderKey = orderRepository.CreateOrder(CustID);
            deliveryDetails.FKOrderID = orderKey;
            int deliveryKey = deliveryRepository.CreateDelivery(deliveryDetails);
            orderItemRepository.CreateOrderList(orderKey,cart);
            
            using (var smtpClient = new SmtpClient())
            using (var mailMessage = BuildMailMessage(cart, deliveryDetails, CustEmail, orderKey))
            {
                smtpClient.Send(mailMessage);
            }
            return orderKey;
        }

        private MailMessage BuildMailMessage(Cart cart, DeliveryDetails deliveryDetails, String CustEmail, int OrderKey)
        {
            StringBuilder body = new StringBuilder();
            body.AppendLine("A new order has been submitted");
            body.AppendLine(" ");
            body.AppendLine("Items:");
            body.AppendLine("Item       --        Quantity        --      Price");
            foreach (var line in cart.Lines)
            {
                var subtotal = line.MenuItem.Price * line.Quantity;
                body.AppendLine(line.MenuItem.ProductName + "    --    " + line.Quantity + "    --    " + line.MenuItem.Price);
            }
            body.AppendLine(" ");
            body.AppendLine("Total order value: " + cart.ComputeTotalValue());
            body.AppendLine(" ");
            body.AppendLine("Deliver to:");
            body.AppendLine(deliveryDetails.Firstname + " " + deliveryDetails.Surname);
            body.AppendLine(deliveryDetails.Address1);
            body.AppendLine(deliveryDetails.Address2);
            body.AppendLine(deliveryDetails.Address3);
            body.AppendLine(deliveryDetails.County);
            body.AppendLine(deliveryDetails.Country);
            body.AppendLine("Contact No: " + deliveryDetails.ContactPhone);
            body.AppendLine("To View Order: http://localhost:49209/OrderDisplay/CustomerDisplayOrders?orderID=" + OrderKey);
            return new MailMessage("jonathan.mccarthy.ire@gmail.com",   // From
                                   CustEmail,                      // To
                                   "New order submitted!",      // Subject
                                   body.ToString());            // Body
        }
    }
}
