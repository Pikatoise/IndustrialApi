using Loading.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loading.DAL.Configurations
{
    public class RegionTypeConfiguration: IEntityTypeConfiguration<RegionType>
    {
        public void Configure(EntityTypeBuilder<RegionType> builder)
        {
            builder.ToTable("regiontypes");

            builder.HasKey(t => t.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("int")
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .IsRequired();

            builder.HasMany<Region>(rt => rt.Regions)
                .WithOne(r => r.RegionType)
                .HasForeignKey(r => r.RegionTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
