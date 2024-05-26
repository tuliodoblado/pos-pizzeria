using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Config
{
    public class OinvConfig : IEntityTypeConfiguration<Oinv>
    {
        public void Configure(EntityTypeBuilder<Oinv> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_INV1");

            entity.ToTable("OINV");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Correlative)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDeleted).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Discounts).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");
            entity.Property(e => e.IdOrder).HasColumnName("ID_Order");
            entity.Property(e => e.IdPaymentMethod).HasColumnName("ID_PaymentMethod");
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Taxes).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.Oinv)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OINV_OCLI");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.Oinv)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OINV_OODR");

            entity.HasOne(d => d.IdPaymentMethodNavigation).WithMany(p => p.Oinv)
                .HasForeignKey(d => d.IdPaymentMethod)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OINV_OPMT");
        }
    }
}
