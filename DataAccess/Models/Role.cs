using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("Role")]
public partial class Role
{
    [Key]
    [Column("IDRole")]
    public long Idrole { get; set; }

    [Column("role")]
    [StringLength(50)]
    public string Role1 { get; set; } = null!;

    [InverseProperty("IdroleNavigation")]
    public virtual ICollection<SuperUser> SuperUsers { get; set; } = new List<SuperUser>();
}
