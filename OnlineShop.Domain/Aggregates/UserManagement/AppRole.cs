using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Aggregates.UserManagement
{
    public class AppRole : IdentityRole, IActiveEntity, IDbSetEntity, ISoftDeletedEntity, IDescribedEntity
    {
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateSoftDeletedLatin { get; set; }
        public string? DateSoftDeletedPersian { get; set; }
        public string? EntityDescription { get; set; }
    }
}
