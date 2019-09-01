using Microsoft.AspNetCore.Identity;
using OneTwoOne.Infrastructure.Models;
using System.Collections.Generic;

namespace OneTwoOne.Module.Core.Models
{
    public class Role : IdentityRole<long>, IEntityWithTypedId<long>
    {
        public IList<UserRole> Users { get; set; } = new List<UserRole>();
    }
}
