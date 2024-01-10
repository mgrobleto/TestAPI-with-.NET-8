using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("Customer")]
public partial class Customer
{
    [Key]
    [Column("IDCustomer")]
    public long Idcustomer { get; set; }

    [Column("IDCustomerType")]
    public long IdcustomerType { get; set; }

    [Column("full_name")]
    [StringLength(150)]
    public string FullName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(150)]
    public string LastName { get; set; } = null!;

    [Column("phone_number")]
    [StringLength(100)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [Column("address")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Address { get; set; }

    [StringLength(100)]
    public string? IdCardNo { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("modify_at", TypeName = "datetime")]
    public DateTime? ModifyAt { get; set; }

    [ForeignKey("IdcustomerType")]
    [InverseProperty("Customers")]
    public virtual CustomerType IdcustomerTypeNavigation { get; set; } = null!;

    [InverseProperty("IdcustomerNavigation")]
    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
