﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebOdevDeneme.Entity
{
    public class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Size { get; set; }
        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }
        //public ProductType ProductType { get; set; }
        public string? ImgURL { get; set; }
        public ICollection<Order>? Orders { get; set; }

    }
}
