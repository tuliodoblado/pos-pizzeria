using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Config
{
    public class OodrConfig : IEntityTypeConfiguration<Oodr>
    {
        public void Configure(EntityTypeBuilder<Oodr> entity)
        {
            entity.ToTable("OODR");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDeleted).HasColumnType("datetime");
            entity.Property(e => e.DateDelivery).HasColumnType("datetime");
            entity.Property(e => e.DateOrder).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");
            entity.Property(e => e.IdDeliveryAddress).HasColumnName("ID_DeliveryAddress");
            entity.Property(e => e.IdPaymentMethod).HasColumnName("ID_PaymentMethod");
            entity.Property(e => e.OrderNotes).HasMaxLength(200);
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Taxes).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Oodr)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OODR_OUSR");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.Oodr)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OODR_OCLI");

            entity.HasOne(d => d.IdDeliveryAddressNavigation).WithMany(p => p.Oodr)
                .HasForeignKey(d => d.IdDeliveryAddress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OODR_CLI1");

            entity.HasOne(d => d.IdPaymentMethodNavigation).WithMany(p => p.Oodr)
                .HasForeignKey(d => d.IdPaymentMethod)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OODR_OPMT");
        }
    }
}
