using Domain.ThirdParty;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfiguration
{
    public class ThirdPartyConfiguration : IEntityTypeConfiguration<ThirdPartyPerson>
    {
        public void Configure(EntityTypeBuilder<ThirdPartyPerson> builder)
        {
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property(x => x.TaxId).HasColumnName("CUI")
                   .IsRequired()
                   .HasMaxLength(20);
        }
    }
}
