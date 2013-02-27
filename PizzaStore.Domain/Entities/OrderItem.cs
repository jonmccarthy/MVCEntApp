using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;

namespace PizzaStore.Domain.Entities
{
    [Table(Name = "OrderItems")]
    public class OrderItem
    {
        [ScaffoldColumn(false)]
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int OrderItemsID { get; set; }

        [Column] public int FKOrdersID { get; set; }
        [Column] public string ProductName { get; set; }
        [Column] public string ProductDescription { get; set; }
        [Column] public int Quantity { get; set; }
        [Column] public decimal Price { get; set; }
    }
}
