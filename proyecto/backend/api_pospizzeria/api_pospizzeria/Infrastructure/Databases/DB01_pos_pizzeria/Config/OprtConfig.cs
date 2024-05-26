using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Config
{
    public class OprtConfig : IEntityTypeConfiguration<Oprt>
    {
        public void Configure(EntityTypeBuilder<Oprt> entity)
        {
            entity.ToTable("OPRT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDeleted).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e.IdCategory).HasColumnName("ID_Category");
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Oprt)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OPRT_OUSR");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Oprt)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OPRT_OPCT");
        }
    }
}
