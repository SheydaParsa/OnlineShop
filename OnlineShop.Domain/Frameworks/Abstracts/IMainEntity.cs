using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Frameworks.Abstracts
{
    public interface IMainEntity : IEntity<Guid>, ICodeEntity<long>, ITitledEntity, IDescribedEntity, IActiveEntity, ICreatedEntity, IModifiedEntity, ISoftDeletedEntity
    {
    }
}
