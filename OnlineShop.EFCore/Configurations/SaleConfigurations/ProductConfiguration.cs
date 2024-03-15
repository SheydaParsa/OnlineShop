using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Aggregates.Sale;
using PublicTools.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.EFCore.Configurations.SaleConfigurations
{
    public class ProductConfiguration
    {
        public void Configure(EntityTypeBuilder<Product>builder)
        {
            builder.ToTable(nameof(Product), DatabaseConstants.Schemas.Sale);
            builder.HasKey(p=>p.Id);
            builder.Property(p=>p.Title).IsRequired();
            builder.Property(p=>p.Code).IsRequired();
            builder.Property(p=>p.UnitPrice).IsRequired();
            builder.Property(p=>p.IsActivated).IsRequired().HasDefaultValue(true);

        }
    }
}
