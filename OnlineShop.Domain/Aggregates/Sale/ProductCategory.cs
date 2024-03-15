using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Aggregates.Sale
{
    public class ProductCategory:SimpleEntityBase,IDbSetEntity
    {
        public int? ParentCategoryId { get; set; }
        public List<Product> Products { get; set; }
    }
}
