using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Config
{
    public class OpctConfig : IEntityTypeConfiguration<Opct>
    {
        public void Configure(EntityTypeBuilder<Opct> entity)
        {
            entity.ToTable("OPCT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDeleted).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .IsUnicode(false);
        }
    }
}
