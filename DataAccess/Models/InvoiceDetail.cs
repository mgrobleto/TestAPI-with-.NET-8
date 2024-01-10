using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("Invoice_Detail")]
public partial class InvoiceDetail
{
    [Key]
    [Column("IDInvoiceDetail")]
    public long IdinvoiceDetail { get; set; }

    [Column("IDInvoice")]
    public long Idinvoice { get; set; }

    [Column("IDProduct")]
    public long Idproduct { get; set; }

    [Column("IDProducPriceCost")]
    public long IdproducPriceCost { get; set; }

    [Column("product_name")]
    [StringLength(100)]
    [Unicode(false)]
    public string? ProductName { get; set; }

    [Column("unitPrice", TypeName = "decimal(18, 4)")]
    public decimal UnitPrice { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("totalSale", TypeName = "decimal(18, 4)")]
    public decimal TotalSale { get; set; }

    [ForeignKey("Idinvoice")]
    [InverseProperty("InvoiceDetails")]
    public virtual Invoice IdinvoiceNavigation { get; set; } = null!;

    [ForeignKey("IdproducPriceCost")]
    [InverseProperty("InvoiceDetails")]
    public virtual ProductPriceCost IdproducPriceCostNavigation { get; set; } = null!;

    [ForeignKey("Idproduct")]
    [InverseProperty("InvoiceDetails")]
    public virtual Product IdproductNavigation { get; set; } = null!;
}
