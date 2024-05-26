using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Config
{
    public class Odr1Config : IEntityTypeConfiguration<Odr1>
    {
        public void Configure(EntityTypeBuilder<Odr1> entity)
        {
            entity.ToTable("ODR1");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDeleted).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.IdOrder).HasColumnName("ID_Order");
            entity.Property(e => e.IdProducts).HasColumnName("ID_Products");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.Odr1)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ODR1_OODR");

            entity.HasOne(d => d.IdProductsNavigation).WithMany(p => p.Odr1)
                .HasForeignKey(d => d.IdProducts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ODR1_OPRT");
        }
    }
}
