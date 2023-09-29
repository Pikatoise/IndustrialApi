using Loading.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loading.DAL.Configurations
{
    public class ManufacturerConfiguration: IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable("manufacturers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .IsRequired();

            builder.HasMany<Equipment>(m => m.Equipments)
                .WithOne(e => e.Manufacturer)
                .HasForeignKey(m => m.ManufacturerId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
