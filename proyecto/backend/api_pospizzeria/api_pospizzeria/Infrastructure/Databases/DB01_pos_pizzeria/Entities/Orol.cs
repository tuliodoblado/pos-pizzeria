using System;
using System.Collections.Generic;

namespace api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;

public partial class Orol
{
    public int Id { get; set; }

    public string NameRole { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool Status { get; set; }

    public DateTime DateCreated { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public int? DeletedBy { get; set; }

    public bool? DeletedStatus { get; set; }

    public virtual ICollection<Ousr> Ousr { get; set; } = new List<Ousr>();
}
