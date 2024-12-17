using System.ComponentModel.DataAnnotations;

namespace WebShopApp.Infrastructure.Data
{
    public class Brand
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string BrandName { get; set; } = null!;
        public virtual IEnumerable<Product> products { get; set; } = new List<Product>();
    }
}
