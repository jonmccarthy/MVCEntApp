using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaStore.Domain.Abstract;
using PizzaStore.WebUI.Models;

namespace PizzaStore.WebUI.Controllers
{
    public class AdminNavController : Controller
    {
        private IMenuItemsRepository menuItemsRepository;
        public AdminNavController(IMenuItemsRepository menuItemsRepository)
        {
            this.menuItemsRepository = menuItemsRepository;
        }

        public ViewResult Menu(string category)
        {
            // Just so we don't have to write this code twice
            Func<string, NavLink> makeLink = categoryName => new NavLink
            {
                Text = categoryName ?? "All",
                RouteValues = new System.Web.Routing.RouteValueDictionary(new
                {
                    controller = "Admin",
                    action = "List",
                    category = categoryName,
                    page = 1
                }),
                IsSelected = (categoryName == category)
            };
            

            // Put a Home link at the top
            List<NavLink> navLinks = new List<NavLink>();
            navLinks.Add(makeLink(null));

            // Add a link for each distinct category
            var categories = menuItemsRepository.MenuItems.Select(x => x.Category);
            foreach (string categoryName in categories.Distinct().OrderBy(x => x))
                navLinks.Add(makeLink(categoryName));

            return View(navLinks);
        }

    }
}
