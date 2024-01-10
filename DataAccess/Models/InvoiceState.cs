using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("Invoice_State")]
public partial class InvoiceState
{
    [Key]
    [Column("IDInvoiceState")]
    public long IdinvoiceState { get; set; }

    [Column("state")]
    [StringLength(200)]
    public string State { get; set; } = null!;

    [InverseProperty("IdinvoiceStateNavigation")]
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
