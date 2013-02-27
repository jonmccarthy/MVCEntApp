using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaStore.Domain.Abstract;
using PizzaStore.Domain.Concrete;
using PizzaStore.Domain.Entities;

namespace PizzaStore.WebUI.Controllers
{
    public class ProductViewModel
    {
        public List<Order> Orders { get; private set; }
        public List<OrderItem> OrderItems { get; private set; }
        public List<DeliveryDetails> DeliveryDetails { get; private set; }

        public ProductViewModel(List<Order> orders, List<OrderItem> orderItems, List<DeliveryDetails> deliveryDetails)
        {
            this.Orders = orders;
            this.OrderItems = orderItems;
            this.DeliveryDetails = deliveryDetails;
        }
    }

    public class OrderViewModel
    {
        public List<OrderItem> OrderItems { get; private set; }
        public List<DeliveryDetails> DeliveryDetails { get; private set; }

        public OrderViewModel(List<OrderItem> orderItems, List<DeliveryDetails> deliveryDetails)
        {
            this.OrderItems = orderItems;
            this.DeliveryDetails = deliveryDetails;
        }
    }

    public class OrderDisplayController : Controller
    {
        private IOrderDisplayRepository orderDisplay;
        private IOrderRepository orderRepository;
        private IOrderItemRepository orderItemRepository;
        private IDeliveryRepository deliveryRepository;

        public OrderDisplayController(IOrderDisplayRepository orderDisplay, IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IDeliveryRepository deliveryRepository)
        {
            this.orderDisplay = orderDisplay;
            this.orderRepository = orderRepository;
            this.orderItemRepository = orderItemRepository;
            this.deliveryRepository = deliveryRepository;
        }

        [Authorize(Users = "StoreUser")]
        public ActionResult ListOrders()
        {
            return View(orderDisplay.Orders.Where(x => x.FKDeliveryID == 0).ToList());
        }

        [Authorize(Users = "StoreUser")]
        public ActionResult Index()
        {
            return View(new ProductViewModel(orderDisplay.ListOrderJMC.ToList(), orderDisplay.ListOrderItemJMC.ToList(), orderDisplay.ListDeliveryDetailJMC.ToList()));
        }

        [Authorize(Users = "StoreUser")]
        public ActionResult DisplayOrders(int orderID)
        {
            var oi = orderDisplay.OrderItems.Where(x => x.FKOrdersID == orderID).ToList();
            var dl = orderDisplay.DeliveryDetails.Where(x => x.FKOrderID == orderID).ToList();
            return View(new OrderViewModel(oi, dl));
        }

        public ActionResult CustomerDisplayOrders(int orderID)
        {
            int user_check = orderRepository.ValidateOrderView(orderID);
            if (user_check != Convert.ToInt32(Session["CustID"]))
            {
                Response.Redirect("/Customer/Login");
            }
            var oi = orderDisplay.OrderItems.Where(x => x.FKOrdersID == orderID).ToList();
            var dl = orderDisplay.DeliveryDetails.Where(x => x.FKOrderID == orderID).ToList();
            return View(new OrderViewModel(oi, dl));
        }

        [Authorize(Users = "StoreUser")]
        public ActionResult CompleteOrder(int orderID)
        {
            Order order = orderRepository.Orders.First(x => x.OrdersID == orderID);
            order.FKDeliveryID = 1;
            TryUpdateModel(order);
            orderRepository.SaveOrder(order);
            return RedirectToAction("ListOrders");
        }

        [Authorize(Users = "StoreUser")]
        public ActionResult DeleteOrder(int orderID)
        {
            Order order = orderRepository.Orders.First(x => x.OrdersID == orderID);
            order.FKDeliveryID = 2;
            TryUpdateModel(order);
            orderRepository.SaveOrder(order);
            return RedirectToAction("ListOrders");
        }

    }
}
