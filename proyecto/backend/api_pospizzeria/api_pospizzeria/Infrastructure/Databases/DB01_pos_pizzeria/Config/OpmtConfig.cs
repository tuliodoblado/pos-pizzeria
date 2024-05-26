using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Config
{
    public class OpmtConfig: IEntityTypeConfiguration<Opmt>
    {
        public void Configure(EntityTypeBuilder<Opmt> entity)
        {
            entity.ToTable("OPMT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDeleted).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Details).HasMaxLength(200);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ServiceProvider)
                .HasMaxLength(70)
                .IsUnicode(false);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Opmt)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OPMT_OUSR");
        }
    }
}
