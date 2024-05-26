using System;
using System.Collections.Generic;

namespace api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;

public partial class Opmt
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Details { get; set; }

    public string ServiceProvider { get; set; } = null!;

    public bool Status { get; set; }

    public DateTime DateCreated { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public int? DeletedBy { get; set; }

    public bool? DeletedStatus { get; set; }

    public virtual Ousr CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Oinv> Oinv { get; set; } = new List<Oinv>();

    public virtual ICollection<Oodr> Oodr { get; set; } = new List<Oodr>();
}
