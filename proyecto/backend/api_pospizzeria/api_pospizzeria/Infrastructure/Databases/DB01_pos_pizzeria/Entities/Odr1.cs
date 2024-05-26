using System;
using System.Collections.Generic;

namespace api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;

public partial class Odr1
{
    public int Id { get; set; }

    public int IdOrder { get; set; }

    public int IdProducts { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Subtotal { get; set; }

    public DateTime DateCreated { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public int? DeletedBy { get; set; }

    public bool? DeletedStatus { get; set; }

    public virtual Oodr IdOrderNavigation { get; set; } = null!;

    public virtual Oprt IdProductsNavigation { get; set; } = null!;
}
