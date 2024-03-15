using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Aggregates.UserManagement;
using PublicTools.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.EFCore.Configurations.UserManagementConfigurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable(nameof(AppUser))
           .HasData(
           new AppUser
           {
               Id = DatabaseConstants.GodAdminUsers.SheydaUserId,
               FirstName = DatabaseConstants.GodAdminUsers.SheydaFirstName,
               LastName = DatabaseConstants.GodAdminUsers.SheydaLasttName,
               UserName=DatabaseConstants.GodAdminUsers.SheydaCellphone,
               PasswordHash = DatabaseConstants.GodAdminUsers.SheydaPassword.GetHashCode().ToString(),
               CellPhone = DatabaseConstants.GodAdminUsers.SheydaCellphone
           }

           );

            // builder.ToTable(table => table.HasCheckConstraint(
            //DatabaseConstants.CheckConstraints.CellphoneOnlyNumericalTitle,
            // DatabaseConstants.CheckConstraints.CellphoneOnlyNumerical
            //));

            builder.Property(p => p.FirstName).IsRequired();
            builder.Property(p => p.LastName).IsRequired();

            builder.Property(p => p.CellPhone).IsRequired();
            builder.HasIndex(p => p.CellPhone).IsUnique();


            builder.Property(p => p.IsActivated).IsRequired().HasDefaultValue(true);
            builder.Property(p => p.DateCreatedLatin).IsRequired().HasDefaultValue(System.DateTime.Now);
            builder.Property(p => p.IsModified).HasDefaultValue(false);
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
        }
    }
}
