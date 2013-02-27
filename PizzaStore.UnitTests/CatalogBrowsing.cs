using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PizzaStore.Domain.Abstract;
using PizzaStore.Domain.Entities;
using PizzaStore.WebUI.Controllers;
using PizzaStore.WebUI.Models;

namespace PizzaStore.UnitTests
{
    [TestFixture]
    public class CatalogBrowsing
    {
        [Test]
        public void Can_View_A_Single_Page_Of_Products()
        {
            // Arrange: If there are 5 products in the repository
            IMenuItemsRepository repository = UnitTestHelpers.MockMenuItemsRepository(
                new MenuItem { ProductName = "P1" },
                new MenuItem { ProductName = "P2" },
                new MenuItem { ProductName = "P3" },
                new MenuItem { ProductName = "P4" },
                new MenuItem { ProductName = "P5" }
                );
            var controller = new MenuItemsController(repository);
            controller.PageSize = 3; // this property dosen't exist yet, but by accessing it, were implicitly forming a requirement for it to exist
 
            //Act: ... then when the user asks for the second page (PageSize=3)...
            var result = controller.List(null, 2);

            // Assert: ... they'll just see the last two products
            var displayedMenuItems = (IList<MenuItem>)result.ViewData.Model;
            displayedMenuItems.Count.ShouldEqual(2);
            displayedMenuItems[0].ProductName.ShouldEqual("P4");
            displayedMenuItems[1].ProductName.ShouldEqual("P5");
        }

        [Test]
        public void Can_View_MenuItems_From_All_Categories()
        {
            // Arrange: If two products are in two different categories...
            IMenuItemsRepository repository = UnitTestHelpers.MockMenuItemsRepository(
                new MenuItem { ProductName = "Artemis", Category = "Pizzas" },
                new MenuItem { ProductName = "Neptune", Category = "Pizzas" }
            );
            var controller = new MenuItemsController(repository);

            // Act: ... then when we ask for the "All Menu Items" Category
            var result = controller.List(null, 1);

            // Arrange: ... we get both products
            var viewModel = (MenuItemsListViewModel)result.ViewData.Model;
            viewModel.MenuItems.Count.ShouldEqual(2);
            viewModel.MenuItems[0].ProductName.ShouldEqual("Artemis");
            viewModel.MenuItems[0].ProductName.ShouldEqual("Neptune");
        }

        [Test]
        public void Can_View_MenuItems_From_A_single_Category()
        {
            // Arrange: If two menu items are in two different categories...
            IMenuItemsRepository repository = UnitTestHelpers.MockMenuItemsRepository(
                new MenuItem { ProductName = "Artemis", Category = "Pizzas" },
                new MenuItem { ProductName = "Neptune", Category = "Pizzas" }
            );
            var controller = new MenuItemsController(repository);

            // Act: ... then when we ask for the "All Menu Items" Category
            var result = controller.List("Roman", 1);

            // Arrange: ... we get both products
            var viewModel = (MenuItemsListViewModel)result.ViewData.Model;
            viewModel.MenuItems.Count.ShouldEqual(1);
            viewModel.MenuItems[0].ProductName.ShouldEqual("Neptune");
            viewModel.MenuItems[0].ProductName.ShouldEqual("Roman");
        }
    }
}
