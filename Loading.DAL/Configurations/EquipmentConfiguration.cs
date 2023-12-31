﻿using Loading.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loading.DAL.Configurations
{
    public class EquipmentConfiguration: IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("equipments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("INTEGER")
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.ManufacturerId)
                .HasColumnName("manufacturerid");

            builder.HasOne<Manufacturer>(e => e.Manufacturer)
                .WithMany(m => m.Equipments)
                .HasForeignKey(e => e.ManufacturerId);
        }
    }
}
