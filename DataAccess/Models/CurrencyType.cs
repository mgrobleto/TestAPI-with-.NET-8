using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("Currency_Type")]
public partial class CurrencyType
{
    [Key]
    [Column("IDCurrencyType")]
    public long IdcurrencyType { get; set; }

    [Column("currency_name")]
    [StringLength(200)]
    public string CurrencyName { get; set; } = null!;

    [InverseProperty("IdcurrencyTypeNavigation")]
    public virtual ICollection<ProductPriceCost> ProductPriceCosts { get; set; } = new List<ProductPriceCost>();
}
