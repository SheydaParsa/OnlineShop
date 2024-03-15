using ResponseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.RepositoryDesignPattern.Frameworks.Abstracts
{
    public interface IRepository<TEntity,in TPrimaryKey> where TEntity : class
    {
        Task<IResponse<object>> InsertAsync(TEntity entity);
        Task<IResponse<object>> UpdateAsync(TEntity entity);
        Task<IResponse<object>> DeleteAsync(TPrimaryKey id);
        Task<IResponse<object>> DeleteAsync(TEntity entity);
        Task<IResponse<List<TEntity>>> Select();
        Task<IResponse<TEntity>> FindByIdAsync(TPrimaryKey? id);
        Task SaveChanges();
    }

}
