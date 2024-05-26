using System;
using System.Collections.Generic;

namespace api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;

public partial class Ousr
{
    public int Id { get; set; }

    public int IdRol { get; set; }

    public string NameUser { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Comments { get; set; }

    public bool Status { get; set; }

    public DateTime DateCreated { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public int? DeletedBy { get; set; }

    public bool? DeletedStatus { get; set; }

    public virtual Orol IdRolNavigation { get; set; } = null!;

    public virtual ICollection<Ocli> Ocli { get; set; } = new List<Ocli>();

    public virtual ICollection<Oodr> Oodr { get; set; } = new List<Oodr>();

    public virtual ICollection<Opmt> Opmt { get; set; } = new List<Opmt>();

    public virtual ICollection<Oprt> Oprt { get; set; } = new List<Oprt>();
}
