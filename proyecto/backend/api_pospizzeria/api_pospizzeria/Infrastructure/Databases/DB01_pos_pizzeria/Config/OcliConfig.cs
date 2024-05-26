using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Config
{
    public class OcliConfig : IEntityTypeConfiguration<Ocli>
    {
        public void Configure(EntityTypeBuilder<Ocli> entity)
        {
            entity.ToTable("OCLI");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDeleted).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.NationalIdentification).HasMaxLength(35);
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.Ocli)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_OCLI_OUSR");
        }
    }
}
