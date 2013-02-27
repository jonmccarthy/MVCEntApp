using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lines = new List<CartLine>();
        public IList<CartLine> Lines { get { return lines.AsReadOnly(); } }

        public void AddItem(MenuItem menuItem, int quantity)
        {
            var line = lines.FirstOrDefault(x => x.MenuItem.MenuItemsID == menuItem.MenuItemsID);
            if (line == null)
                lines.Add(new CartLine { MenuItem = menuItem, Quantity = quantity });
            else
                line.Quantity += quantity;
        }

        public decimal ComputeTotalValue() 
        {
            return lines.Sum(l => l.MenuItem.Price * l.Quantity);
        }

        public void Clear() 
        {
            lines.Clear();
        }

        public void RemoveLine(MenuItem menuItem)
        {
            lines.RemoveAll(l => l.MenuItem.MenuItemsID == menuItem.MenuItemsID);
        }
    }

    public class CartLine
    {
        public MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
    }
}
