using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PizzaStore.Domain.Abstract;
using PizzaStore.Domain.Entities;
using Moq;

namespace PizzaStore.UnitTests
{
    public static class UnitTestHelpers
    {
        public static void ShouldEqual<T>(this T actualValue, T expectedValue)
        {
            Assert.AreEqual(expectedValue, actualValue);
        }

        public static IMenuItemsRepository MockMenuItemsRepository(params MenuItem[] prods)
        {
            // Generate an implementer of IMenuItemsRepository at runtime using Moq
            var mockMenuItemsRepos = new Mock<IMenuItemsRepository>();
            mockMenuItemsRepos.Setup(x => x.MenuItems).Returns(prods.AsQueryable());
            return mockMenuItemsRepos.Object;
        }
    }
}
