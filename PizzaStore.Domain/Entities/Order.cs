using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq;

namespace PizzaStore.Domain.Entities
{
    [Table(Name = "Orders")]
    public class Order
    {
        [ScaffoldColumn(false)]
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int OrdersID { get; set; }
        
        [Column] public int FKMenuCustomerID { get; set; }
        [Column] public int FKDeliveryID { get; set; }
        [Column] public DateTime DateOrder { get; set; }
    }
}
