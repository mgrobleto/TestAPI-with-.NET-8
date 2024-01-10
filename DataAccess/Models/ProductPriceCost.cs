using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("Product_Price_Cost")]
public partial class ProductPriceCost
{
    [Key]
    [Column("IDProducPriceCost")]
    public long IdproducPriceCost { get; set; }

    [Column("IDProduct")]
    public long Idproduct { get; set; }

    [Column("IDCurrencyType")]
    public long IdcurrencyType { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Cost { get; set; }

    [ForeignKey("IdcurrencyType")]
    [InverseProperty("ProductPriceCosts")]
    public virtual CurrencyType IdcurrencyTypeNavigation { get; set; } = null!;

    [ForeignKey("Idproduct")]
    [InverseProperty("ProductPriceCosts")]
    public virtual Product IdproductNavigation { get; set; } = null!;

    [InverseProperty("IdproducPriceCostNavigation")]
    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
