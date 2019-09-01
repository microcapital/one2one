using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OneTwoOne.Module.Core.Data;
using OneTwoOne.Module.Core.Models;

namespace OneTwoOne.Module.Core.Extensions
{
    public class OneTwoOneUserStore : UserStore<User, Role, OneTwoOneDbContext, long, IdentityUserClaim<long>, UserRole,
        IdentityUserLogin<long>,IdentityUserToken<long>, IdentityRoleClaim<long>>
    {
        public OneTwoOneUserStore(OneTwoOneDbContext context, IdentityErrorDescriber describer) : base(context, describer)
        {
        }
    }
}
