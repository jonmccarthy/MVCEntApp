using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaStore.Domain.Abstract;
using PizzaStore.Domain.Entities;
using PizzaStore.WebUI.Models;

namespace PizzaStore.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository customerRepository;
        private EmailCustomer emailCustomer;

        public CustomerController(ICustomerRepository customerRepository, EmailCustomer emailCustomer)
        {
            this.customerRepository = customerRepository;
            this.emailCustomer = emailCustomer;
        }

        public ViewResult Index()
        {
            return View(customerRepository.Customers.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer customer)
        {
            string email = customer.Email;
            string password = customer.LoginPassword;

            //var customer_find = customerRepository.Customers.First(x => x.Email == email);
            //Customer c_find = customerRepository.Customers.First(x => x.Email == customer.Email);

            int test = customerRepository.FindCustomer(email, password);
            string emailAddr = customerRepository.GetCustomerEmail(test);

            if (test > 0)
            {
                Session["CustID"] = test;
                Session["EmailAddr"] = emailAddr;
                Response.Redirect("/Cart/Index");
            }
            
            return View();
        }

        public ViewResult Edit(int id)
        {
            var customer = customerRepository.Customers.First(x => x.CustomerID == id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            TryUpdateModel(customer);

            if (ModelState.IsValid)
            {
                customerRepository.SaveCustomer(customer);
                TempData["message"] = customer.Firstname + " " + customer.Surname + " has been saved!";
                Response.Redirect("/Customer/Display?id=" + customer.CustomerID);
                emailCustomer.SendCustEmail(customer.Firstname,customer.Email, customer.CustomerID);
                Session["CustID"] = customer.CustomerID;
                Session["EmailAddr"] = customer.Email;
                return RedirectToAction("Index");
            }
            else  // validation error - redisplay same view
                return View(customer);

        }

        public ViewResult Create()
        {
            return View("Edit", new Customer());
        }

        public ViewResult Display(int id)
        {
            if (id != Convert.ToInt32(Session["CustID"]))
            {
                Response.Redirect("/Customer/Login");
            }
            var customer = customerRepository.Customers.First(x => x.CustomerID == id);
            return View(customer);
        }

    }
}
