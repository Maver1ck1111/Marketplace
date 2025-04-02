using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public Discount Discount { get; set; } 
        public decimal PriceWithDiscount => Discount != null ? Price - (Price * Discount.Percentage / 100) : Price;
    }
}
