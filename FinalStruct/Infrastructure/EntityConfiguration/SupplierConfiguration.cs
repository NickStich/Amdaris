﻿using Domain.ThirdParty;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfiguration
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

            builder.Property(x => x.Name).HasColumnName("Name")
                   .IsRequired()
                   .HasMaxLength(20);
            builder.Property(x => x.TaxId).HasColumnName("TaxId")
                   .IsRequired()
                   .HasMaxLength(20);
        }
    }
}
