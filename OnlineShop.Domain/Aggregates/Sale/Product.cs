using onlineshop.domain.frameworks.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Aggregates.Sale
{
    public class Product : mainentitybase,IDbSetEntity
    {
        public ProductCategory productCategory { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
