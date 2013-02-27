using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaStore.Domain.Abstract;
using PizzaStore.Domain.Entities;
using PizzaStore.WebUI.Models;
using PizzaStore.Domain.Services;

namespace PizzaStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IMenuItemsRepository menuItemsRepository;
        private IOrderSubmitter orderSubmitter;
        int CustID = 1;
        string CustEmail = "";
        
        public CartController(IMenuItemsRepository menuItemsRepository, IOrderSubmitter orderSubmitter)
        {
            this.menuItemsRepository = menuItemsRepository;
            this.orderSubmitter = orderSubmitter;
        }

        public RedirectToRouteResult AddToCart(Cart cart, int menuItemsID, string returnUrl)
        {
            MenuItem menuItem = menuItemsRepository.MenuItems.FirstOrDefault(p => p.MenuItemsID == menuItemsID);
            cart.AddItem(menuItem,1);
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int menuItemsID, string returnUrl)
        {
            MenuItem menuItem = menuItemsRepository.MenuItems.FirstOrDefault(p => p.MenuItemsID == menuItemsID);
            cart.RemoveLine(menuItem);
            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public ViewResult Summary(Cart cart)
        {
            return View(cart);
        }

        public ViewResult CheckOut()
        {
            if (Session["CustID"] == null)
            {
                Response.Redirect("/Customer/Login");
            }
            else
            {
                return View(new DeliveryDetails());
            }
            return View(new DeliveryDetails());
        }

        [HttpPost]

        public ActionResult CheckOut(Cart cart, DeliveryDetails deliveryDetails)
        {
            // Empty carts can't be checked out
            if (cart.Lines.Count == 0)
                ModelState.AddModelError("Cart", "Sorry, your cart is empty!");

            if (ModelState.IsValid)
            {
                if (Session["CustID"] == null)
                {
                    CustID = 1;
                }
                else
                {
                    CustID =  Convert.ToInt32(Session["CustID"]);
                    CustEmail = Session["EmailAddr"].ToString();
                }
                int orderid = orderSubmitter.SubmitOrder(cart, deliveryDetails, CustID, CustEmail);
                cart.Clear();
                Response.Redirect("/OrderDisplay/CustomerDisplayOrders?orderID=" + orderid);
                return View("Completed");
            }
            else // Something was invalid
                return View(deliveryDetails);
          
        }

    }
}
