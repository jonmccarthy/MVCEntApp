using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaStore.Domain.Entities;

namespace PizzaStore.WebUI.Models
{
    public class MenuItemsListViewModel
    {
        public IList<MenuItem> MenuItems { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}