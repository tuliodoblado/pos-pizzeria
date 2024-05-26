using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Config
{
    public class OusrConfig : IEntityTypeConfiguration<Ousr>
    {
        public void Configure(EntityTypeBuilder<Ousr> entity)
        {
            entity.ToTable("OUSR");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Comments).HasMaxLength(50);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDeleted).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.IdRol).HasColumnName("ID_Rol");
            entity.Property(e => e.LastName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.NameUser)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(325)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Ousr)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OUSR_OROL");
        }
    }
}
