using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("Product")]
public partial class Product
{
    [Key]
    [Column("IDProduct")]
    public long Idproduct { get; set; }

    [Column("IDProductCategory")]
    public long IdproductCategory { get; set; }

    [Column("product_name")]
    [StringLength(500)]
    public string ProductName { get; set; } = null!;

    [Column("product_description")]
    [StringLength(500)]
    public string ProductDescription { get; set; } = null!;

    [Column("product_stock")]
    public int? ProductStock { get; set; }

    [ForeignKey("IdproductCategory")]
    [InverseProperty("Products")]
    public virtual ProductCategory IdproductCategoryNavigation { get; set; } = null!;

    [InverseProperty("IdproductNavigation")]
    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    [InverseProperty("IdproductNavigation")]
    public virtual ICollection<ProductPriceCost> ProductPriceCosts { get; set; } = new List<ProductPriceCost>();

    [InverseProperty("IdproductNavigation")]
    public virtual ProductPurchase? ProductPurchase { get; set; }
}
