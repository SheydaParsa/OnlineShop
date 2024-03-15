using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Aggregates.UserManagement;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Frameworks.Abstracts;
using OnlineShop.EFCore.Frameworks;
using PublicTools.Constants;
using System.Reflection;

namespace OnlineShop.EFCore
{
    public class OnlineShopDbContext : IdentityDbContext<AppUser, AppRole, string,
        IdentityUserClaim<string>, AppUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public OnlineShopDbContext(DbContextOptions options) : base(options)
        {
        }

        #region [- ConfigureConventions(ModelConfigurationBuilder configurationBuilder) -]
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {

        }
        #endregion

        #region [- OnModelCreating(ModelBuilder modelBuilder) -]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DatabaseConstants.Schemas.UserManagement);

            #region [- ApplyConfigurationsFromAssembly() -]
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            #endregion

            #region [- RegisterAllEntities() -]
            modelBuilder.RegisterAllEntities<IDbSetEntity>(typeof(IDbSetEntity).Assembly);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
