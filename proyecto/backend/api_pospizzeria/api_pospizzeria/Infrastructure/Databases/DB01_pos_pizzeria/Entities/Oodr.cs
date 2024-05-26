using System;
using System.Collections.Generic;

namespace api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;

public partial class Oodr
{
    public int Id { get; set; }

    public int IdCustomer { get; set; }

    public int IdDeliveryAddress { get; set; }

    public int IdPaymentMethod { get; set; }

    public DateTime DateOrder { get; set; }

    public DateTime DateDelivery { get; set; }

    public string OrderStatus { get; set; } = null!;

    public string OrderNotes { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public decimal Taxes { get; set; }

    public DateTime DateCreated { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public int? DeletedBy { get; set; }

    public bool? DeletedStatus { get; set; }

    public virtual Ousr CreatedByNavigation { get; set; } = null!;

    public virtual Ocli IdCustomerNavigation { get; set; } = null!;

    public virtual Cli1 IdDeliveryAddressNavigation { get; set; } = null!;

    public virtual Opmt IdPaymentMethodNavigation { get; set; } = null!;

    public virtual ICollection<Odr1> Odr1 { get; set; } = new List<Odr1>();

    public virtual ICollection<Oinv> Oinv { get; set; } = new List<Oinv>();
}
