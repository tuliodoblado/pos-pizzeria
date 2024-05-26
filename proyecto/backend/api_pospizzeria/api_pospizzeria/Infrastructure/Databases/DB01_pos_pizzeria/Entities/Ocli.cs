using System;
using System.Collections.Generic;

namespace api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;

public partial class Ocli
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public byte[] NationalIdentification { get; set; } = null!;

    public bool Status { get; set; }

    public DateTime DateCreated { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public int? DeletedBy { get; set; }

    public bool? DeletedStatus { get; set; }

    public virtual ICollection<Cli1> Cli1 { get; set; } = new List<Cli1>();

    public virtual ICollection<Oinv> Oinv { get; set; } = new List<Oinv>();

    public virtual ICollection<Oodr> Oodr { get; set; } = new List<Oodr>();

    public virtual Ousr? UpdatedByNavigation { get; set; }
}
