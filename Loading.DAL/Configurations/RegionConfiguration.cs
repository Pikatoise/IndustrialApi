using Loading.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loading.DAL.Configurations
{
    public class RegionConfiguration: IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("regions");

            builder.HasKey(x => x.Code);

            builder.Property(x => x.Code)
                .HasColumnName("code")
                .HasColumnType("text")
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .IsRequired();

            builder.HasOne(r => r.RegionType)
                .WithMany(rt => rt.Regions)
                .HasForeignKey(r => r.RegionTypeId);
        }
    }
}
