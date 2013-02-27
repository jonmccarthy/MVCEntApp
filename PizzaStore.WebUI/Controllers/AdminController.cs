using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaStore.Domain.Abstract;
using PizzaStore.Domain.Entities;

namespace PizzaStore.WebUI.Controllers
{
    //[Authorize(Users = "jmccarthy")]
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        public int PageSize = 4;
        private IMenuItemsRepository menuItemsRepository;
        public AdminController(IMenuItemsRepository menuItemsRepository)
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

        public ViewResult Home()
        {
            return View();
        }

        public ViewResult Index()
        {
            return View(menuItemsRepository.MenuItems.ToList());
        }

        public ViewResult Edit(int id)
        {
            var menuItem = menuItemsRepository.MenuItems.First(x => x.MenuItemsID == id);
            return View(menuItem);
        }

        [HttpPost]
        public ActionResult Edit(int MenuItemsID, HttpPostedFileBase image)
        {
            MenuItem menuItem = MenuItemsID == 0
                ? new MenuItem()
                : menuItemsRepository.MenuItems.First(x => x.MenuItemsID == MenuItemsID);
            TryUpdateModel(menuItem);

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    menuItem.ImageMimeType = image.ContentType;
                    menuItem.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(menuItem.ImageData, 0, image.ContentLength);
                }
                menuItemsRepository.SaveMenuItem(menuItem);
                TempData["message"] = menuItem.ProductName + " has been saved!";
                return RedirectToAction("List");
            }
            else  // validation error - redisplay same view
                return View(menuItem);

        }

        public ViewResult Create()
        {
            return View("Edit", new MenuItem());
        }

        public RedirectToRouteResult Delete(int id)
        {
            var menuItem = menuItemsRepository.MenuItems.First(x => x.MenuItemsID == id);
            menuItemsRepository.DeleteItems(menuItem);
            TempData["message"] = menuItem.ProductName + " was deleted";
            return RedirectToAction("List");
        }
    }
}
