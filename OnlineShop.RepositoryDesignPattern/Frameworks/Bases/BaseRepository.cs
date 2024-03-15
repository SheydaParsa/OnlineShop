using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using OnlineShop.RepositoryDesignPattern.Frameworks.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Aggregates.UserManagement;
using ResponseFramework;
using Microsoft.EntityFrameworkCore;
using PublicTools.Resources;


namespace OnlineShop.RepositoryDesignPattern.Frameworks.Bases
{
    public class BaseRepository<TDbContext, TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
                                                                          where TEntity : class
                                                                          where TDbContext : IdentityDbContext<AppUser, AppRole, string,
                                                                              IdentityUserClaim<string>, AppUserRole, IdentityUserLogin<string>,
                                                                              IdentityRoleClaim<string>, IdentityUserToken<string>>
    {

        #region [- ctor -]
        public BaseRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }
        #endregion

        #region [- props -]

        protected virtual TDbContext DbContext { get; set; }
        protected virtual DbSet<TEntity> DbSet { get; set; }
        #endregion

        #region [DeleteAsync(TPrimaryKey id)]
        public virtual async Task<IResponse<object>> DeleteAsync(TPrimaryKey id)
        {
            var entityToDelete = DbSet.FindAsync(id).Result;
            if (entityToDelete == null) return new ResponseFramework.Response<object>(MessageResources.Error_FailProcess);
            DbSet.Remove(entityToDelete);
            await SaveChanges();
            return new ResponseFramework.Response<object>(entityToDelete);
        }
        #endregion

        #region [DeleteAsync(TEntity entityToDelete)]
        public virtual async Task<IResponse<object>> DeleteAsync(TEntity entityToDelete)
        {
            if (DbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
            await SaveChanges();
            return new ResponseFramework.Response<object>(entityToDelete);
        }
        #endregion

        #region [FindByIdAsync(TPrimaryKey? id)]
        public virtual async Task<IResponse<TEntity>> FindByIdAsync(TPrimaryKey? id)
        {
            var q = await DbSet.FindAsync(id);
            return q == null ? new ResponseFramework.Response<TEntity>(MessageResources.Error_FailProcess) : new ResponseFramework.Response<TEntity>(q);
        }
        #endregion

        #region [InsertAsync(TEntity entity)]
        public virtual async Task<IResponse<object>> InsertAsync(TEntity entity)
        {
            await using (DbContext)
            {
                DbSet.Add(entity);
                await SaveChanges();
                return new ResponseFramework.Response<object>(entity);
            }
        }
        #endregion

        #region [SaveChanges()]
        public async Task SaveChanges()
        {
            await DbContext.SaveChangesAsync();
        }
        #endregion

        #region [Select()]
        public virtual async Task<IResponse<List<TEntity>>> Select()
        {
            var q = await DbSet.AsNoTracking().ToListAsync();
            var response = new ResponseFramework.Response<List<TEntity>>(new List<TEntity>()) { Result = q };
            return response;
        }
        #endregion

        #region [UpdateAsync(TEntity entity)]
        public virtual async Task<IResponse<object>> UpdateAsync(TEntity entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
            return new ResponseFramework.Response<object>(entity);
        } 
        #endregion
    }
}
