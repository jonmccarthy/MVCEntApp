using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Domain.Abstract;
using PizzaStore.Domain.Entities;

namespace PizzaStore.Domain.Concrete
{
    public class FakeMenuItemsRepository : IMenuItemsRepository
    {
        // Fake hard coded list of Menu Items
        
        private static IQueryable<MenuItem> fakeMenuItems = new List<MenuItem> {
            new MenuItem { ProductName = "Pizza 1", ProductDescription="Description 1", PortionSize="Small", Price=7},
            new MenuItem { ProductName = "Pizza 2", ProductDescription="Description 2", PortionSize="Medium", Price=17},
            new MenuItem { ProductName = "Pizza 3", ProductDescription="Description 3", PortionSize="Large", Price=27}
        }.AsQueryable();

        public IQueryable<MenuItem> MenuItems
        {
            get { return fakeMenuItems; }
        }

        public void SaveMenuItem(MenuItem menuItem)
        {
            // Not Implemented
        }

        public void DeleteItems(MenuItem menuItem)
        {
            // Not Implemented
        }
        
    }
}
