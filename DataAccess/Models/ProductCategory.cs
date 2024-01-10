using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("Product_Category")]
public partial class ProductCategory
{
    [Key]
    public long IdProductCategory { get; set; }

    [Column("category_name")]
    [StringLength(500)]
    public string CategoryName { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [InverseProperty("IdproductCategoryNavigation")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
