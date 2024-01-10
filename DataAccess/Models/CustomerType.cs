using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("Customer_Type")]
public partial class CustomerType
{
    [Key]
    [Column("IDCustomerType")]
    public long IdcustomerType { get; set; }

    [Column("customer_type")]
    [StringLength(300)]
    public string CustomerType1 { get; set; } = null!;

    [InverseProperty("IdcustomerTypeNavigation")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
