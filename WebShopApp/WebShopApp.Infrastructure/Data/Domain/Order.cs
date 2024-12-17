﻿using System.ComponentModel.DataAnnotations;

namespace WebShopApp.Infrastructure.Data
{
    public class Order
    {

        public int Id { get; set; }
        
        [Required]
         public DateTime OrderDate { get; set; }
        
        [Required]
        public int ProducctId { get; set; }
        public virtual Product Product { get; set; } = null!;
        
        [Required]
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPrice { get { return this.Quantity * this.Price - this.Quantity * this.Price * this.Discount / 100; } }
    }
}
