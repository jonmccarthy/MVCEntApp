using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaStore.Domain.Abstract;
using PizzaStore.Domain.Concrete;
using System.ComponentModel;
using PizzaStore.WebUI.Models;

namespace PizzaStore.WebUI.Controllers
{
    public class MenuItemsController : Controller
    {
        public int PageSize = 4; 
        private IMenuItemsRepository menuItemsRepository;

        public MenuItemsController(IMenuItemsRepository menuItemsRepository)
        {
            this.menuItemsRepository = menuItemsRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            var menuItemsToShow = (category == null)
                ? menuItemsRepository.MenuItems
                : menuItemsRepository.MenuItems.Where(x => x.Category == category);

            return View(menuItemsToShow.ToList());
        }

        public FileContentResult GetImage(int MenuItemsID)
        {
            var menuItem = menuItemsRepository.MenuItems.First(x => x.MenuItemsID == MenuItemsID);
            return File(menuItem.ImageData, menuItem.ImageMimeType);
        }

    }
}
