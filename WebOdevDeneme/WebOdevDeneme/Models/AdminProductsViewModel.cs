using WebOdevDeneme.Entity;

namespace WebOdevDeneme.Models
{
    public class AdminProductsViewModel
    {
        public List<Product> Products { get; set; }
        public ICollection<ProductType> ProductTypes { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
    public class AdminProductEditViewModel
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Size { get; set; }
        public int ProductTypeId { get; set; }
        public string? ImgURL { get; set; }
    }
}
