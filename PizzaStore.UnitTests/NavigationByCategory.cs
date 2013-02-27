using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PizzaStore.Domain.Entities;
using PizzaStore.WebUI.Controllers;
using PizzaStore.WebUI.Models;

namespace PizzaStore.UnitTests
{
    [TestFixture]
    public class NavigationByCategory
    {
        [Test]
        public void NavMenu_Includes_Alphabetical_List_Of_Distinct_Categories()
        {
            // Arrange: given 4 menu items in 3 categories 
            var mockMenuItemsRepository = UnitTestHelpers.MockMenuItemsRepository(
                new MenuItem { Category = "Sides", ProductName = "ProductA" },
                new MenuItem { Category = "Pizza", ProductName = "ProductB" },
                new MenuItem { Category = "Chips", ProductName = "ProductC" },
                new MenuItem { Category = "Drinks", ProductName = "ProductD" }
            );

            // Act: ... when we render the navigation menu
            var result = new NavController(mockMenuItemsRepository).Menu(null);

            // Assert: ... then the linnks to categories
            var categoryLinks = ((IEnumerable<NavLink>)result.ViewData.Model)
                .Where(x => x.RouteValues["category"] != null);

            // ... are distinct categories in alphabetical order
            CollectionAssert.AreEqual(
                new[] { "Animal", "Mineral", "Vegetable" },
                categoryLinks.Select(x => x.RouteValues["category"])
            );

            // ... and contain enough information to link to that category
            foreach (var link in categoryLinks)
            {
                link.RouteValues["controller"].ShouldEqual("MenuItems");
                link.RouteValues["action"].ShouldEqual("List");
                link.RouteValues["page"].ShouldEqual(1);
                link.Text.ShouldEqual(link.RouteValues["category"]);
            }
        } // End Method

        [Test]
        public void navMenu_Show_Home_Link_At_Top()
        {
            // Arrange: Given any respository
            var mockMenuItemsRepository = UnitTestHelpers.MockMenuItemsRepository();

            //Act: ... when we render the navigation menu
            var result = new NavController(mockMenuItemsRepository).Menu(null);

            // Act: ... then the top link is set to Home
            var topLink = ((IEnumerable<NavLink>)result.ViewData.Model).First();
            topLink.RouteValues["controller"].ShouldEqual("MenuItems");
            topLink.RouteValues["action"].ShouldEqual("List");
            topLink.RouteValues["page"].ShouldEqual(1);
            topLink.RouteValues["category"].ShouldEqual(null);
            topLink.Text.ShouldEqual("Home");
        }

        [Test]
        public void NavMenu_Highlights_Current_Category()
        {
            // Arrange: Given two categories...
            var mockMenuItemsRepository = UnitTestHelpers.MockMenuItemsRepository(
                new MenuItem { Category = "Sides", ProductName = "ProductA" },
                new MenuItem { Category = "Pizza", ProductName = "ProductB" }
            );

            // Act: ... when we render the navigation menu
            var result = new NavController(mockMenuItemsRepository).Menu("B");


            // Assert: ... then only the current category is highlighted
            var highlightedLinks = ((IEnumerable<NavLink>)result.ViewData.Model).Where(x => x.IsSelected).ToList();
            highlightedLinks.Count.ShouldEqual(1);
            highlightedLinks[0].Text.ShouldEqual("B");
        }
    }
}
