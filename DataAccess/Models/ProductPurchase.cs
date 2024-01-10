using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("Product_Purchase")]
[Index("Idproduct", Name = "unq_Product_Order_IDProduct", IsUnique = true)]
[Index("Idprovider", Name = "unq_Product_Order_IDProvider", IsUnique = true)]
public partial class ProductPurchase
{
    [Key]
    [Column("IDPurchase")]
    public long Idpurchase { get; set; }

    [Column("IDProvider")]
    public long Idprovider { get; set; }

    [Column("IDProduct")]
    public long Idproduct { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("price_per_unit", TypeName = "decimal(18, 2)")]
    public decimal PricePerUnit { get; set; }

    [Column("total_price", TypeName = "decimal(18, 2)")]
    public decimal TotalPrice { get; set; }

    [Column("ordered_at", TypeName = "datetime")]
    public DateTime OrderedAt { get; set; }

    [ForeignKey("Idproduct")]
    [InverseProperty("ProductPurchase")]
    public virtual Product IdproductNavigation { get; set; } = null!;

    [ForeignKey("Idprovider")]
    [InverseProperty("ProductPurchase")]
    public virtual Provider IdproviderNavigation { get; set; } = null!;
}
