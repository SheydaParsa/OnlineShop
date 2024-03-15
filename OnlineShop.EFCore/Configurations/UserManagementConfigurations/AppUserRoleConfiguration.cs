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
    public class AppUserRoleConfiguration:IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder) 
        {
            builder.ToTable(nameof(AppUserRole)).
                HasData(
                new AppUserRole() { UserId = DatabaseConstants.GodAdminUsers.SheydaUserId, RoleId = DatabaseConstants.DefaultRoles.GodAdminId }

                );
            builder.HasKey(p=>new { 
                p.UserId, 
                p.RoleId 
            });
        }
    }
}
