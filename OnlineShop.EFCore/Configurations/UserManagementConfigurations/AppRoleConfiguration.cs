using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Domain.Aggregates.UserManagement;
using PublicTools.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.EFCore.Configurations.UserManagementConfigurations
{
    public class AppRoleConfiguration:IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder) 
        {
            builder.ToTable(nameof(AppRole)).
                HasData(
                new AppRole()
                {
                    Id = DatabaseConstants.DefaultRoles.GodAdminId,
                    Name = DatabaseConstants.DefaultRoles.GodAdminName,
                    NormalizedName = DatabaseConstants.DefaultRoles.GodAdminNormalizedName,
                    ConcurrencyStamp = DatabaseConstants.DefaultRoles.GodAdminConcurrencyStamp,
                },
                 new AppRole()
                 {
                     Id = DatabaseConstants.DefaultRoles.AdminId,
                     Name = DatabaseConstants.DefaultRoles.AdminName,
                     NormalizedName = DatabaseConstants.DefaultRoles.AdminNormalizedName,
                     ConcurrencyStamp = DatabaseConstants.DefaultRoles.AdminConcurrencyStamp,
                 },
                  new AppRole()
                  {
                      Id = DatabaseConstants.DefaultRoles.SupportId,
                      Name = DatabaseConstants.DefaultRoles.SupporName,
                      NormalizedName = DatabaseConstants.DefaultRoles.SupporNormalizedName,
                      ConcurrencyStamp = DatabaseConstants.DefaultRoles.SupporConcurrencyStamp,
                  }

                  );
        }
    }
}
