using System;
using System.Collections.Generic;

namespace api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;

public partial class Oprt
{
    public int Id { get; set; }

    public int IdCategory { get; set; }

    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string? Image { get; set; }

    public int AvailableStock { get; set; }

    public bool? Featured { get; set; }

    public bool Status { get; set; }

    public DateTime DateCreated { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public int? DeletedBy { get; set; }

    public bool? DeletedStatus { get; set; }

    public virtual Ousr CreatedByNavigation { get; set; } = null!;

    public virtual Opct IdCategoryNavigation { get; set; } = null!;

    public virtual ICollection<Odr1> Odr1 { get; set; } = new List<Odr1>();
}
