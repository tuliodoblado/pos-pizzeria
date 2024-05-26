using api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api_pospizzeria.Infrastructure.Databases.DB01_pos_pizzeria.Config
{
    public class Cli1Config : IEntityTypeConfiguration<Cli1>
    {
        public void Configure(EntityTypeBuilder<Cli1> entity)
        {
            entity.ToTable("CLI1");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateDeleted).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.DeliveryAddress).IsUnicode(false);
            entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");
            entity.Property(e => e.PostalCode).HasMaxLength(20);
            entity.Property(e => e.ReferenceAddress)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.State).HasMaxLength(40);
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.Cli1)
                .HasForeignKey(d => d.IdCustomer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CLI1_OCLI");
        }
    }
}
