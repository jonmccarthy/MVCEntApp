using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Domain.Entities;

namespace PizzaStore.Domain.Abstract
{
    public interface IMenuItemsRepository
    {
        IQueryable<MenuItem> MenuItems { get; }
        void SaveMenuItem(MenuItem menuItem);
        void DeleteItems(MenuItem menuItem);
    }
}
