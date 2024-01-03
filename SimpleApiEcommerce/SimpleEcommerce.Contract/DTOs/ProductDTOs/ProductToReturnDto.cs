using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEcommerce.Contract.DTOs.ProductDTOs
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int MinimumQuantity { get; set; }
        public double DiscountRate { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
    }
}