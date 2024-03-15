using OnlineShop.Domain.Aggregates.Sale;
using OnlineShop.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineShop.RepositoryDesignPattern.Services.Sale
{
    public class OnlineShopRepository :
        Frameworks.Bases.BaseRepository<OnlineShopDbContext, Product, int>
    {
        #region [- ctor -]
        public OnlineShopRepository(OnlineShopDbContext dbContext) : base(dbContext)
        {

        }
        #endregion
    }
}
