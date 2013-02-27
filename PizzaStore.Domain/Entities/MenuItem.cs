using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;


namespace PizzaStore.Domain.Entities
{
    [Table(Name = "MenuItems")]
    public class MenuItem
    {
        //[HiddenInput(DisplayValue = false)] // Can't use this it links the Domain model to the MVC model
        [ScaffoldColumn(false)]
        [Column(IsPrimaryKey = true, IsDbGenerated = true, AutoSync = AutoSync.OnInsert)]
        public int MenuItemsID { get; set; }

        [Required(ErrorMessage="Please enter a category!")]
        [Column] public string Category { get; set; }

        [Required(ErrorMessage = "Please enter a name!")]
        [Column] public string ProductName { get; set; }

        [Required(ErrorMessage = "Please enter a description!")]
        [DataType(DataType.MultilineText)]
        [Column] public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Please enter a portion size!")]
        [Column] public string PortionSize { get; set; }

        [Column] public string ImageName { get; set; }

        [Column] public byte[] ImageData { get; set; }

        [ScaffoldColumn(false)]
        [Column] public string ImageMimeType { get; set; }

        [Column] public int MultiplePricing { get; set; }
        
        //[Required(ErrorMessage = "Please enter a price!")]
        [Column] public decimal Price { get; set; }

        [Column] public decimal PriceSmall { get; set; }
        [Column] public decimal PriceMedium { get; set; }
        [Column] public decimal PriceLarge { get; set; } 
    }
}
