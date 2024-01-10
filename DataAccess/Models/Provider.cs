using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("Provider")]
public partial class Provider
{
    [Key]
    [Column("IDProvider")]
    public long Idprovider { get; set; }

    [Column("provider_name")]
    [StringLength(200)]
    public string ProviderName { get; set; } = null!;

    [Column("provider_phone_number")]
    public int ProviderPhoneNumber { get; set; }

    [Column("provider_address")]
    [StringLength(500)]
    public string? ProviderAddress { get; set; }

    [InverseProperty("IdproviderNavigation")]
    public virtual ProductPurchase? ProductPurchase { get; set; }
}
