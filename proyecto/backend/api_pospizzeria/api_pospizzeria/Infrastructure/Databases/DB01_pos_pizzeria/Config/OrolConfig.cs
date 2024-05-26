using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Config
{
    public class OrolConfig: IEntityTypeConfiguration<Orol>
    {
        public void Configure(EntityTypeBuilder<Orol> entity)
        {
            entity.ToTable("OROL");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDeleted).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(60);
            entity.Property(e => e.NameRole)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Status).HasColumnName("status");
        }
    }
}
