using System;
using System.Collections.Generic;

namespace api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;

public partial class Cli1
{
    public int Id { get; set; }

    public int IdCustomer { get; set; }

    public string DeliveryAddress { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? PostalCode { get; set; }

    public string State { get; set; } = null!;

    public string? ReferenceAddress { get; set; }

    public bool Status { get; set; }

    public DateTime DateCreated { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? DateUpdated { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? DateDeleted { get; set; }

    public int? DeletedBy { get; set; }

    public bool? DeletedStatus { get; set; }

    public virtual Ocli IdCustomerNavigation { get; set; } = null!;

    public virtual ICollection<Oodr> Oodr { get; set; } = new List<Oodr>();
}
