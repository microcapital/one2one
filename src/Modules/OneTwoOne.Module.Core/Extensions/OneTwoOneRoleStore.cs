using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OneTwoOne.Module.Core.Data;
using OneTwoOne.Module.Core.Models;

namespace OneTwoOne.Module.Core.Extensions
{
    public class OneTwoOneRoleStore: RoleStore<Role, OneTwoOneDbContext, long, UserRole, IdentityRoleClaim<long>>
    {
        public OneTwoOneRoleStore(OneTwoOneDbContext context) : base(context)
        {
        }
    }
}
