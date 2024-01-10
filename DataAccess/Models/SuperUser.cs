using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

[Table("Super_User")]
public partial class SuperUser
{
    [Key]
    [Column("IDSuperUser")]
    public long IdsuperUser { get; set; }

    [Column("firstName")]
    [StringLength(150)]
    public string FirstName { get; set; } = null!;

    [Column("lastName")]
    [StringLength(150)]
    public string LastName { get; set; } = null!;

    [Column("email")]
    [StringLength(50)]
    public string Email { get; set; } = null!;

    [Column("password")]
    [StringLength(20)]
    public string Password { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("modified_at", TypeName = "datetime")]
    public DateTime? ModifiedAt { get; set; }

    [Column("isActive")]
    public bool? IsActive { get; set; }

    [Column("IDRole")]
    public long Idrole { get; set; }

    [ForeignKey("Idrole")]
    [InverseProperty("SuperUsers")]
    public virtual Role IdroleNavigation { get; set; } = null!;
}
