using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Domain.Abstract;
using PizzaStore.Domain.Entities;
using System.Data.Linq;

namespace PizzaStore.Domain.Concrete
{
    public class SqlMenuItemsRepository : IMenuItemsRepository
    {
            private Table<MenuItem> menuItemsTable;

            public SqlMenuItemsRepository (string connectionString)
            {
                menuItemsTable = (new DataContext(connectionString)).GetTable<MenuItem>();
            }

            public IQueryable<MenuItem> MenuItems
            {
                get { return menuItemsTable; }
            }

            public void SaveMenuItem(MenuItem menuItem)
            {
                // If its a new product, just attach it to the DataContext
                if (menuItem.MenuItemsID == 0)
                    menuItemsTable.InsertOnSubmit(menuItem);
                else if (menuItemsTable.GetOriginalEntityState(menuItem) == null)
                {
                    // Were updating an existing menu item, but its not attached to the
                    // this data context, so attach it and detect the changes
                    menuItemsTable.Attach(menuItem);
                    menuItemsTable.Context.Refresh(RefreshMode.KeepCurrentValues, menuItem);
                }
                menuItemsTable.Context.SubmitChanges();
            }

            public void DeleteItems(MenuItem menuItem)
            {
                menuItemsTable.DeleteOnSubmit(menuItem);
                menuItemsTable.Context.SubmitChanges();
            }
        
    }
}
