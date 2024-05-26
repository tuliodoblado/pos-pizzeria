using System;
using System.Collections.Generic;

namespace api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;

public partial class Oinv
{
    public int Id { get; set; }

    public int IdOrder { get; set; }

    public int IdCustomer { get; set; }

    public int IdPaymentMethod { get; set; }

    public DateTime InvoiceDate { get; set; }

    public string Correlative { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public decimal? Taxes { get; set; }

    public decimal? Discounts { get; set; }

    public decimal NetAmount { get; set; }

    public string Status { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public int? DeletedBy { get; set; }

    public bool? DeletedStatus { get; set; }

    public virtual Ocli IdCustomerNavigation { get; set; } = null!;

    public virtual Oodr IdOrderNavigation { get; set; } = null!;

    public virtual Opmt IdPaymentMethodNavigation { get; set; } = null!;
}
