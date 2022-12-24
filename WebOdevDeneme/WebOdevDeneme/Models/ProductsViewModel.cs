using WebOdevDeneme.Entity;

namespace WebOdevDeneme.Models
{
    public class ProductsViewModel
    {
        public List<Product> Products { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<ProductType> ProductTypes { get; set; }
    }
}
