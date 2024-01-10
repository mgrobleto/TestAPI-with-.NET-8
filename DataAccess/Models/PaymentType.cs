using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("Payment_Type")]
public partial class PaymentType
{
    [Key]
    [Column("IDPaymentType")]
    public long IdpaymentType { get; set; }

    [Column("payment_type")]
    [StringLength(200)]
    public string PaymentType1 { get; set; } = null!;

    [InverseProperty("IdpaymentTypeNavigation")]
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
