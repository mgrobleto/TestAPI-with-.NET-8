using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("Invoice")]
public partial class Invoice
{
    [Key]
    [Column("IDInvoice")]
    public long Idinvoice { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    [StringLength(150)]
    public string? CreatedBy { get; set; }

    [Column("invoiceNumber")]
    [StringLength(100)]
    public string InvoiceNumber { get; set; } = null!;

    [Column("customerName")]
    [StringLength(150)]
    [Unicode(false)]
    public string CustomerName { get; set; } = null!;

    [Column("subTotalLocal", TypeName = "decimal(18, 4)")]
    public decimal SubTotalLocal { get; set; }

    [Column("ivaLocal", TypeName = "decimal(18, 2)")]
    public decimal IvaLocal { get; set; }

    [Column("totalLocal", TypeName = "decimal(18, 2)")]
    public decimal TotalLocal { get; set; }

    [Column("IDPaymentType")]
    public long IdpaymentType { get; set; }

    [Column("IDCustomer")]
    public long Idcustomer { get; set; }

    [Column("IDInvoiceState")]
    public long IdinvoiceState { get; set; }

    [Column("updated_at")]
    public DateOnly? UpdatedAt { get; set; }

    [Column("updated_by")]
    [StringLength(150)]
    public string? UpdatedBy { get; set; }

    [ForeignKey("Idcustomer")]
    [InverseProperty("Invoices")]
    public virtual Customer IdcustomerNavigation { get; set; } = null!;

    [ForeignKey("IdinvoiceState")]
    [InverseProperty("Invoices")]
    public virtual InvoiceState IdinvoiceStateNavigation { get; set; } = null!;

    [ForeignKey("IdpaymentType")]
    [InverseProperty("Invoices")]
    public virtual PaymentType IdpaymentTypeNavigation { get; set; } = null!;

    [InverseProperty("IdinvoiceNavigation")]
    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
